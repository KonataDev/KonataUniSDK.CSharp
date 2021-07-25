using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.Core
{
    internal static class SocketClient
    {
        private static int _connSeq;
        private static Socket socket { get; set; }

        private static ConcurrentDictionary<int, TaskCompletionSource<uint>> connPending { get; } = new();

        private static object connLock { get; } = new();

        internal static void Connect(int port)
        {
            var ipe = new IPEndPoint(IPAddress.Loopback, port);
            socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);

            Read();
        }

        private static int NewSequence()
        {
            Interlocked.CompareExchange(ref _connSeq, 0, ushort.MaxValue);
            Interlocked.Increment(ref _connSeq);
            return _connSeq;
        }

        private static void Read()
        {
            while (true)
            {
                var recvlen = 0;
                var buffer = new byte[4];

                // Parse the body length

                while (recvlen < 4)
                    recvlen += socket.Receive(buffer, recvlen, buffer.Length - recvlen, SocketFlags.None);

                var pktlen = BitConverter.ToInt32(buffer) - 4;

                // data buffer
                var databuffer = new byte[pktlen];

                // Read data
                var recvpktlen = socket.Receive(databuffer, 0, pktlen, SocketFlags.None);

                while (recvpktlen < pktlen)
                    recvpktlen += socket.Receive(databuffer, recvpktlen, pktlen - recvpktlen, SocketFlags.None);

                //Console.WriteLine("RecvData:\t" + BitConverter.ToString(databuffer).Replace("-", ""));

                ThreadPool.QueueUserWorkItem(_ => EventHandle(databuffer));
            }

            // ReSharper disable once FunctionNeverReturns
        }

        public static async Task<uint> Send(string apiName, Dictionary<string, object> e)
        {
            var task = new TaskCompletionSource<uint>();

            var sequence = NewSequence();

            // Put async task
            if (!connPending.TryAdd(sequence, task))
            {
                connPending[sequence].SetCanceled();
                connPending.TryRemove(sequence, out _);

                // Retry then failed
                if (!connPending.TryAdd(sequence, task)) return default;
            }

            //Send
            lock (connLock)
            {
                var writer = new ByteWriter();
                writer.WriteInt16(1);
                writer.WriteInt16((ushort) sequence);
                writer.WriteInt16(0);
                writer.WriteInt16((ushort) e.Count);
                writer.WriteInt16(0);
                writer.WriteInt16(0);
                writer.WriteInt8((byte) apiName.Length);
                writer.WriteString(apiName);

                foreach (var (key, value) in e)
                {
                    writer.WriteInt8((byte) key.Length);
                    writer.WriteString(key);
                    writer.WriteWithLength(value);
                }

                var result = writer.GetResult();

                //Console.WriteLine("SendData:\t" + BitConverter.ToString(result).Replace("-", ""));

                socket.Send(result);
            }

            // Wait for result
            return await task.Task;
        }

        private static void EventHandle(byte[] bytes)
        {
            var konataEventMetadata = new KonataEventMetadata(bytes);
            var eventargs = konataEventMetadata.KonataEventArgsConverter();

            if (eventargs is ResultEventArgs re)
            {
                if (connPending.TryGetValue(konataEventMetadata.sessionId, out var task)) task.SetResult(re.resultData);

                return;
            }


            //Console.WriteLine("RecvEventType:\t" + eventargs);

            //eventHandler

            switch (eventargs)
            {
                case StartupEventArgs eventArgs:
                    konataEventMetadata.returnValue =
                        !Init.Container.CanResolve<IOnStartup>()
                        || Init.Container.Resolve<IOnStartup>().OnStartup(eventArgs);
                    break;

                case EnabledEventArgs eventArgs:
                    konataEventMetadata.returnValue =
                        !Init.Container.CanResolve<IOnEnabled>()
                        || Init.Container.Resolve<IOnEnabled>().OnEnabled(eventArgs);
                    break;

                case DisabledEventArgs eventArgs:
                    if (Init.Container.CanResolve<IOnDisabled>())
                        Init.Container.Resolve<IOnDisabled>()
                            .OnDisabled(eventArgs);
                    break;

                case DestroyEventArgs eventArgs:
                    if (Init.Container.CanResolve<IOnDestroy>())
                        Init.Container.Resolve<IOnDestroy>()
                            .OnDestroy(eventArgs);
                    break;

                case PrivateMessageEventArgs eventArgs:
                    konataEventMetadata.returnValue = Init.Container.CanResolve<IPrivateMessage>()
                        ? Init.Container.Resolve<IPrivateMessage>()
                            .OnPrivateMessage(eventArgs)
                        : KonataEventReturnType.Ignore;
                    break;

                case GroupMessageEventArgs eventArgs:
                    konataEventMetadata.returnValue = Init.Container.CanResolve<IGroupMessage>()
                        ? Init.Container.Resolve<IGroupMessage>()
                            .OnGroupMessage(eventArgs)
                        : KonataEventReturnType.Ignore;
                    break;

                case GroupAdminChangeEventArgs eventArgs:
                    konataEventMetadata.returnValue = Init.Container.CanResolve<IGroupAdminChange>()
                        ? Init.Container.Resolve<IGroupAdminChange>()
                            .OnGroupAdminChange(eventArgs)
                        : KonataEventReturnType.Ignore;
                    break;
            }

            if (konataEventMetadata.returnValue != null)
                socket.Send(konataEventMetadata.EncodeKonataReply());
        }
    }
}