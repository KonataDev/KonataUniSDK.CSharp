using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IOnEnabled : IKonataEvent
    {
        /// <summary>
        ///     处理插件开启事件
        /// </summary>
        bool OnEnabled(EnabledEventArgs eventArgs);
    }
}