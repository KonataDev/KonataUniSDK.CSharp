using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IGroupMessage))]
    [EventName("OnGroupMessage")]
    public class GroupMessageEventArgs : KonataEventArgs
    {
        public GroupMessageEventArgs(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            FromGroup = ByteConverter.Cast<uint>(data.parameters["Group"]);
            FromMember = ByteConverter.Cast<uint>(data.parameters["Member"]);
            Message = new QqMessage(ByteConverter.Cast<string>(data.parameters["Message"]),
                ByteConverter.Cast<uint>(data.parameters["MessageId"]));
        }

        public uint Bot { get; }
        public uint FromGroup { get; }
        public uint FromMember { get; }
        public QqMessage Message { get; }
    }
}