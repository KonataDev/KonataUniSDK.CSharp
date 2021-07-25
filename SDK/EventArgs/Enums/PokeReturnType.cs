using System.ComponentModel;

namespace KonataCSharp.SDK.EventArgs.Enums
{
    public enum PokeReturnType
    {
        [Description("Operation successfully.")]
        Success = 0,

        [Description("Operation failed.")] Failed = -1,

        [Description("Member disabled him this function.")]
        Denied = -2
    }
}