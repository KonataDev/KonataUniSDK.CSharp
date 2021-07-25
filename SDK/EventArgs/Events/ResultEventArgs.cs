using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.BaseModel;

namespace KonataCSharp.SDK.EventArgs.Events
{
    internal class ResultEventArgs : KonataEventArgs
    {
        internal ResultEventArgs(KonataEventMetadata data) : base(data)
        {
            resultData = ByteConverter.Cast<uint>(data.parameters["ResultData"]);
        }

        internal uint resultData { get; }
    }
}