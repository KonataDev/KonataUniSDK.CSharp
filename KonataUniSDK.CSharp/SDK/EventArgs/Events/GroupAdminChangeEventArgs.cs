using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IGroupAdminChange))]
    [EventName("OnGroupPromoteAdmin")]
    public class GroupAdminChangeEventArgs : KonataEventArgs
    {
        public enum GroupAdminChangeType : uint
        {
            Demote,
            Promote
        }

        public GroupAdminChangeEventArgs(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            Group = ByteConverter.Cast<uint>(data.parameters["Group"]);
            Member = ByteConverter.Cast<uint>(data.parameters["Member"]);
            Toggle = (GroupAdminChangeType) ByteConverter.Cast<uint>(data.parameters["Toggle"]);
        }

        public uint Bot { get; }
        public uint Group { get; }
        public uint Member { get; }
        public GroupAdminChangeType Toggle { get; }
    }
}