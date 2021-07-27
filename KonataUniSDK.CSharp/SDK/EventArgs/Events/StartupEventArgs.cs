using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IOnStartup))]
    [EventName("OnStartup")]
    public class StartupEventArgs : KonataEventArgs
    {
        public StartupEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}