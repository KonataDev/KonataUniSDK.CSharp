using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IGroupMuteMember))]
    public class GroupMuteMemberEvent : KonataEventArgs
    {
        internal GroupMuteMemberEvent(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            FromGroup = ByteConverter.Cast<uint>(data.parameters["GroupUin"]);
            Target = ByteConverter.Cast<uint>(data.parameters["MemberUin"]);
            Operator = ByteConverter.Cast<uint>(data.parameters["OperatorUin"]);
            TimeSeconds = ByteConverter.Cast<uint>(data.parameters["TimeSeconds"]);
        }

        public uint Bot { get; }
        public uint FromGroup { get; }
        public uint Target { get; }
        public uint Operator { get; }
        public uint TimeSeconds { get; }
    }
}