using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IOnDisabled : IKonataEvent
    {
        /// <summary>
        ///     处理插件关闭事件
        /// </summary>
        void OnDisabled(DisabledEventArgs eventArgs);
    }
}