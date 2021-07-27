using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnDisabled))]
    [EventName("OnDisabled")]
    public class DisabledEventArgs : KonataEventArgs
    {
        public DisabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}