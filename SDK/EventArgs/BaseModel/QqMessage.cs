namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    public class QqMessage
    {
        internal QqMessage(string message, uint messageId)
        {
            Message = message;
            MessageId = messageId;
        }

        private string Message { get; }

        public uint MessageId { get; }

        public override string ToString()
        {
            return Message;
        }

        public static implicit operator string(QqMessage msg)
        {
            return msg.Message;
        }
    }
}