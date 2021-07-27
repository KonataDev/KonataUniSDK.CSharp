using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IGroupPoke))]
    [EventName("OnGroupPoke")]
    public class GroupPokeEventArgs : KonataEventArgs
    {
        public GroupPokeEventArgs(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            FromGroup = ByteConverter.Cast<uint>(data.parameters["GroupUin"]);
            Target = ByteConverter.Cast<uint>(data.parameters["MemberUin"]);
            Operator = ByteConverter.Cast<uint>(data.parameters["OperatorUin"]);
            ActionPrefix = ByteConverter.Cast<string>(data.parameters["ActionPrefix"]);
            ActionSuffix = ByteConverter.Cast<string>(data.parameters["ActionSuffix"]);
        }

        public uint Bot { get; }
        public uint FromGroup { get; }
        public uint Target { get; }
        public uint Operator { get; }
        public string ActionPrefix { get; }
        public string ActionSuffix { get; }
    }
}