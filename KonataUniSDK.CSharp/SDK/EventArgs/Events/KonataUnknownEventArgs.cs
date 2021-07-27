using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IUnknownEvent))]
    public class KonataUnknownEventArgs : KonataEventArgs
    {
        public KonataUnknownEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}