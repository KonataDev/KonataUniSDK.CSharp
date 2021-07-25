using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class StartupEventArgs : KonataEventArgs
    {
        internal StartupEventArgs(KonataEventMetadata data) : base(data)
        {
        }
    }
}