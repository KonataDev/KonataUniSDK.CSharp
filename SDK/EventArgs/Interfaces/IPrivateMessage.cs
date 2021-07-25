using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IPrivateMessage : IKonataEvent
    {
        /// <summary>
        ///     处理私聊消息事件
        /// </summary>
        KonataEventReturnType OnPrivateMessage(PrivateMessageEventArgs eventArgs);
    }
}