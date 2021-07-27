using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnEnabled))]
    [EventName("OnEnabled")]
    public class EnabledEventArgs : KonataEventArgs
    {
        public EnabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}