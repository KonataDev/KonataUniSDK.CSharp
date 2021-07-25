using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IOnStartup : IKonataEvent
    {
        /// <summary>
        ///     处理插件初始化事件
        /// </summary>
        bool OnStartup(StartupEventArgs eventArgs);
    }
}