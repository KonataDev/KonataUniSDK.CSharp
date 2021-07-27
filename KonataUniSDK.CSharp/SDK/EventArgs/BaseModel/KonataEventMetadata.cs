using System;
using System.Collections.Generic;
using KonataCSharp.SDK.Core;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    public class KonataEventMetadata
    {
        internal KonataEventMetadata(byte[] bytes)
        {
            var byteReader = new ByteReader(bytes);
            protocolVersion = byteReader.TakeInt16();
            sessionId = byteReader.TakeInt16();
            hasReturnValue = byteReader.TakeInt16() == 1;
            parameterNumber = byteReader.TakeInt16();
            byteReader.TakeBytes(4);
            var eventNamelen = byteReader.TakeInt8();
            eventName = byteReader.TakeString(eventNamelen);

            parameters = new Dictionary<string, byte[]>();

            // it's a result value from server
            if (eventName == "" && !hasReturnValue && parameterNumber == 1)
            {
                byteReader.TakeBytes(1);
                parameters.Add("ResultData", byteReader.TakeBytes((int) byteReader.TakeUInt32()));
                return;
            }

            for (var i = 0; i < parameterNumber; ++i)
                parameters.Add(byteReader.TakeString(byteReader.TakeInt8()),
                    byteReader.TakeBytes((int) byteReader.TakeUInt32()));

            var checkNum = byteReader.TakeAllBytes();

            if (checkNum.Length != 1 || byteReader.Checksum())
                throw new ApplicationException("Incorrect checkNum.");
        }

        internal ushort protocolVersion { get; }

        internal ushort sessionId { get; }

        internal bool hasReturnValue { get; }

        private ushort parameterNumber { get; }

        internal string eventName { get; }

        internal Dictionary<string, byte[]> parameters { get; }
    }
}