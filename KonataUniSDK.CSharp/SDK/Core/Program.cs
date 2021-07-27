using System;

namespace KonataCSharp.SDK.Core
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (_, e) => Console.WriteLine(e);

            Reflection.InterfaceInitialize();

            for (var i = 0; i < args.Length; ++i)
                if (args[i] == "--port" && i < args.Length)
                {
                    SocketClient.Connect(Convert.ToInt32(args[i + 1]));
                    // break;
                }

            throw new ApplicationException("Port is not set. please set the port as \"--port 2333\".");
        }
    }
}