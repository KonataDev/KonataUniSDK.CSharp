using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnStartup))]
    public class StartupEventArgs : KonataEventArgs
    {
        internal StartupEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}