using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IOnDestroy : IKonataEvent
    {
        /// <summary>
        ///     处理插件销毁事件
        /// </summary>
        void OnDestroy(DestroyEventArgs eventArgs);
    }
}