using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    public class GroupMessageEventArgs : KonataEventArgs
    {
        internal GroupMessageEventArgs(KonataEventMetadata data) : base(data)
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