using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class DestroyEventArgs : KonataEventArgs
    {
        internal DestroyEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}