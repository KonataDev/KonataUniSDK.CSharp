using System.ComponentModel;

namespace KonataCSharp.SDK.EventArgs.Enums
{
    public enum GroupGrantSpecialTitleReturnType
    {
        [Description("Operation successfully.")]
        Success = 0,

        [Description("Operation failed.")] Failed = -1,

        [Description("Lack the permission.")] Denied = -2
    }
}