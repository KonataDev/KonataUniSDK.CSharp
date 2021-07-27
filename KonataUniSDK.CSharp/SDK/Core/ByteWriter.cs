using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KonataCSharp.SDK.EventArgs.Enums;

namespace KonataCSharp.SDK.Core
{
    internal class ByteWriter
    {
        private IEnumerable<byte> _buffer = new List<byte>();

        private int _length;

        private byte checksum => (byte) (_buffer.Aggregate(0, (current, i) => i + current) & 0xFF);

        private int Write(object value)
        {
            return value switch
            {
                byte i => WriteInt8(i),
                ushort i => WriteInt16(i),
                bool i => WriteUInt32((uint) (i ? 1 : 0)),
                uint i => WriteUInt32(i),
                string i => WriteString(i),
                byte[] i => WriteBytes(i),
                KonataEventReturnType i => WriteUInt32((uint) i),
                _ => throw new ApplicationException("The type of the value is not supported.")
            };
        }

        internal int WriteWithLength(object value)
        {
            WriteUInt32(
                value switch
                {
                    byte => 1,
                    short => 2,
                    bool => 4,
                    uint => 4,
                    KonataEventReturnType => 4,
                    byte[] i => (uint) i.Length,
                    string i => (uint) Encoding.UTF8.GetBytes(i).Length,
                    _ => throw new ApplicationException("The type of the value is not supported.")
                });
            return 4 + Write(value);
        }

        internal int WriteInt8(byte value)
        {
            _buffer = _buffer.Append(value);
            _length++;
            return 1;
        }

        internal int WriteInt16(ushort value)
        {
            _buffer = _buffer.Concat(BitConverter.GetBytes(value));
            _length += 2;
            return 2;
        }

        private int WriteUInt32(uint value)
        {
            _buffer = _buffer.Concat(BitConverter.GetBytes(value));
            _length += 4;
            return 4;
        }

        internal int WriteString(string value)
        {
            return WriteBytes(Encoding.UTF8.GetBytes(value));
        }

        private int WriteBytes(byte[] value)
        {
            _buffer = _buffer.Concat(value);
            _length += value.Length;
            return value.Length;
        }

        internal byte[] GetResult()
        {
            _buffer = BitConverter.GetBytes(_length + 5).Concat(_buffer);
            _buffer = _buffer.Append(checksum);
            _length += 5;
            return _buffer.ToArray();
        }
    }
}