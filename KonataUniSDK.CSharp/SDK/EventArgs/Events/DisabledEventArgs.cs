using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnDisabled))]
    public class DisabledEventArgs : KonataEventArgs
    {
        internal DisabledEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}