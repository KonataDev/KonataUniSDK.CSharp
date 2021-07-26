using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnDestroy))]
    public class DestroyEventArgs : KonataEventArgs
    {
        internal DestroyEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}