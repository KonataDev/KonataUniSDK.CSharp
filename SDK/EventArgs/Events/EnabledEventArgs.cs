using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class EnabledEventArgs : KonataEventArgs
    {
        internal EnabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}