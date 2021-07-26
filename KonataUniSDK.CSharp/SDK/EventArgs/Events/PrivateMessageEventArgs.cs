using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [Interface(typeof(IPrivateMessage))]
    public class PrivateMessageEventArgs : KonataEventArgs
    {
        internal PrivateMessageEventArgs(KonataEventMetadata data) : base(data)
        {
            Bot = ByteConverter.Cast<uint>(data.parameters["Bot"]);
            FromQq = ByteConverter.Cast<uint>(data.parameters["Friend"]);
            Message = new QqMessage(ByteConverter.Cast<string>(data.parameters["Message"]),
                ByteConverter.Cast<uint>(data.parameters["MessageId"]));
        }

        public uint Bot { get; }
        public uint FromQq { get; }
        public QqMessage Message { get; }
    }
}