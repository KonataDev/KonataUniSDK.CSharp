using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IGroupMessage : IKonataEvent
    {
        /// <summary>
        ///     处理群聊消息事件
        /// </summary>
        KonataEventReturnType OnGroupMessage(GroupMessageEventArgs eventArgs);
    }
}