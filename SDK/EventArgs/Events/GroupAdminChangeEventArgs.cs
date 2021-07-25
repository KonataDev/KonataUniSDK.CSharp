using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class GroupAdminChangeEventArgs : KonataEventArgs
    {
        public enum GroupAdminChangeType : uint
        {
            Demote,
            Promote
        }

        internal GroupAdminChangeEventArgs(KonataEventMetadata data) : base(data)
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