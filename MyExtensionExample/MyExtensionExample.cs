using System;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace MyExtensionExample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            KonataCSharp.SDK.Core.Program.Main(args);
        }
    }

    internal class MyExtensionExample : IGroupMessage, IGroupMuteMember
    {
        public KonataEventReturnType OnGroupMessage(GroupMessageEventArgs e)
        {
            Console.WriteLine("Recv GroupMessage:\t" + e.Message);

            if (e.Message == "/ping")
            {
                var newmsgid = e.Api.SendGroupMessage(e.Bot, e.FromGroup, "Hi! I'm Konata. -Test").Result;

                Console.WriteLine("Send msgid:\t" + newmsgid);
            }

            return KonataEventReturnType.Ignore;
        }

        public KonataEventReturnType OnGroupMuteMember(GroupMuteMemberEventArgs eventArgs)
        {
            Console.WriteLine("OnGroupMuteMember:\t FromGroup:\t" + eventArgs.FromGroup + "\tSeconds:\t" +
                              eventArgs.TimeSeconds);

            return KonataEventReturnType.Ignore;
        }
    }
}