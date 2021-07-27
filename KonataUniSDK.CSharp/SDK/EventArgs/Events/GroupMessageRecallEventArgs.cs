using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IGroupMessageRecall))]
    [EventName("OnGroupMessageRecall")]
    public class GroupMessageRecallEventArgs : KonataEventArgs
    {
        public GroupMessageRecallEventArgs(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            FromGroup = ByteConverter.Cast<uint>(data.parameters["GroupUin"]);
            Target = ByteConverter.Cast<uint>(data.parameters["MemberUin"]);
            Operator = ByteConverter.Cast<uint>(data.parameters["OperatorUin"]);
            RecallSuffix = ByteConverter.Cast<string>(data.parameters["RecallSuffix"]);
        }

        public uint Bot { get; }
        public uint FromGroup { get; }
        public uint Target { get; }
        public uint Operator { get; }
        public string RecallSuffix { get; }
    }
}