using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnEnabled))]
    public class EnabledEventArgs : KonataEventArgs
    {
        internal EnabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}