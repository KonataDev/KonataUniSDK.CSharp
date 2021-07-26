using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IGroupMessageRecall : IKonataEvent
    {
        /// <summary>
        ///     处理群撤回消息事件
        /// </summary>
        KonataEventReturnType OnGroupMessageRecall(GroupMessageRecallEvent eventArgs);
    }
}