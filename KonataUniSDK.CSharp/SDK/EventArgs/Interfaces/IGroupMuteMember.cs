using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IGroupMuteMember : IKonataEvent
    {
        /// <summary>
        ///     处理群禁言事件
        /// </summary>
        KonataEventReturnType OnGroupMuteMember(GroupMuteMemberEvent eventArgs);
    }
}