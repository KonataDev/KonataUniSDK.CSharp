using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    [EventName("")]
    internal class ResultEventArgs : KonataEventArgs
    {
        public ResultEventArgs(KonataEventMetadata data) : base(data)
        {
            resultData = ByteConverter.Cast<uint>(data.parameters["ResultData"]);
        }

        internal uint resultData { get; }
    }
}