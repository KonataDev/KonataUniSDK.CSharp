using System;
using System.Collections.Generic;
using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    internal class KonataEventMetadata
    {
        internal KonataEventMetadata(byte[] bytes)
        {
            var byteReader = new ByteReader(bytes);
            protocolVersion = byteReader.TakeInt16();
            sessionId = byteReader.TakeInt16();
            hasReturnValue = byteReader.TakeInt16() == 1;
            parameterNumber = byteReader.TakeInt16();
            unusedParameter1 = byteReader.TakeInt16();
            unusedParameter2 = byteReader.TakeInt16();
            var eventNamelen = byteReader.TakeInt8();
            eventName = byteReader.TakeString(eventNamelen);

            parameters = new Dictionary<string, byte[]>();

            // it's a result value from server
            if (eventName == "" && !hasReturnValue && parameterNumber == 1)
            {
                byteReader.TakeBytes(1);
                parameters.Add("ResultData", byteReader.TakeBytes((int) byteReader.TakeUInt32()));
                return;
            }

            for (var i = 0; i < parameterNumber; ++i)
                parameters.Add(byteReader.TakeString(byteReader.TakeInt8()),
                    byteReader.TakeBytes((int) byteReader.TakeUInt32()));

            var checkNum = byteReader.TakeAllBytes();

            if (checkNum.Length != 1 || checkNum[0] != byteReader.Checksum())
                throw new ApplicationException("incorrect checkNum");
        }

        private ushort protocolVersion { get; }

        internal ushort sessionId { get; }

        private bool hasReturnValue { get; }

        private ushort parameterNumber { get; }

        private ushort unusedParameter1 { get; }

        private ushort unusedParameter2 { get; }

        private string eventName { get; }

        internal Dictionary<string, byte[]> parameters { get; }

        internal object returnValue { get; set; }

        internal KonataEventArgs KonataEventArgsConverter()
        {
            return eventName switch
            {
                "" => new ResultEventArgs(this),
                "OnStartup" => new StartupEventArgs(this),
                "OnEnabled" => new EnabledEventArgs(this),
                "OnDisabled" => new DisabledEventArgs(this),
                "OnDestroy" => new DestroyEventArgs(this),
                "OnPrivateMessage" => new PrivateMessageEventArgs(this),
                "OnGroupMessage" => new GroupMessageEventArgs(this),
                "OnGroupAdminChange" => new GroupMessageEventArgs(this),
                _ => throw new ApplicationException("Not Supported EventArgs")
            };
        }

        internal byte[] EncodeKonataReply()
        {
            var writer = new ByteWriter();
            writer.WriteInt16(protocolVersion);
            writer.WriteInt16(sessionId);
            writer.WriteInt16((ushort) (hasReturnValue ? 1 : 0));
            writer.WriteInt16(1);
            writer.WriteInt16(unusedParameter1);
            writer.WriteInt16(unusedParameter2);
            writer.WriteInt16(0);
            writer.WriteWithLength(returnValue);
            return writer.GetResult();
        }
    }
}