using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.EventArgs.Interfaces
{
    public interface IGroupPoke : IKonataEvent
    {
        /// <summary>
        ///     处理插件开启事件
        /// </summary>
        KonataEventReturnType OnGroupPoke(GroupPokeEvent eventArgs);
    }
}