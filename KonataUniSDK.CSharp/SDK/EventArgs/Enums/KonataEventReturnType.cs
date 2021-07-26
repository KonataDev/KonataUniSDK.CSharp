using System.ComponentModel;

namespace KonataCSharp.SDK.EventArgs.Enums
{
    public enum KonataEventReturnType : uint
    {
        [Description("Ignore this event.")] Ignore = 0,

        [Description("Block this event to the next extension.")] Blocked = 1
    }
}