using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IGroupAdminChange : IKonataEvent
    {
        /// <summary>
        ///     处理群管理员变动事件
        /// </summary>
        KonataEventReturnType OnGroupAdminChange(GroupAdminChangeEventArgs eventArgs);
    }
}