using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IUnknownEvent : IKonataEvent
    {
        /// <summary>
        ///     处理未知事件
        /// </summary>
        KonataEventReturnType OnUnknownEvent(KonataUnknownEventArgs eventArgs);
    }
}