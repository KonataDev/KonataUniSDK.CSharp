using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class DisabledEventArgs : KonataEventArgs
    {
        internal DisabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}