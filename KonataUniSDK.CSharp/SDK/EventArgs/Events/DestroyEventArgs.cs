using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnDestroy))]
    [EventName("OnDestroy")]
    public class DestroyEventArgs : KonataEventArgs
    {
        public DestroyEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}