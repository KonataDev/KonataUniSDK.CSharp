using System;

namespace KonataCSharp.SDK.Core
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Init.InterfaceReflector();

            for (var i = 0; i < args.Length; ++i)
                if (args[i] == "--port" && i < args.Length)
                {
                    SocketClient.Connect(Convert.ToInt32(args[i + 1]));
                    break;
                }

            throw new ApplicationException("port is not set. please set port as \"--port 2333\".");
        }
    }
}