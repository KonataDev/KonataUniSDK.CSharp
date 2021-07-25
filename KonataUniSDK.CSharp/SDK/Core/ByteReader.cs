using System;
using System.IO;
using System.Linq;
using System.Text;

namespace KonataCSharp.SDK.Core
{
    internal class ByteReader
    {
        private static readonly IOException EobException =
            new("Insufficient buffer space");

        private readonly byte[] _buffer;
        private readonly int _bufferLength;
        private int _readPosition;

        internal ByteReader(byte[] data)
        {
            _bufferLength = 0;
            _readPosition = 0;
            if (data != null)
            {
                _bufferLength = data.Length;
                _buffer = data;
            }
        }

        internal byte Checksum()
        {
            var sum = 0;
            
            for (int i = 0; i < _buffer.Length-1; ++i)
            {
                sum += _buffer[1];
            }

            return (byte)(sum & 0xFF);
        }

        internal byte TakeInt8()
        {
            if (CheckAvailable(1))
            {
                var value = _buffer[_readPosition];
                ++_readPosition;
                return value;
            }

            throw EobException;
        }

        internal ushort TakeInt16()
        {
            if (CheckAvailable(2))
            {
                var value = BitConverter.ToUInt16(_buffer, _readPosition);
                _readPosition += 2;
                return value;
            }

            throw EobException;
        }

        internal uint TakeUInt32()
        {
            if (CheckAvailable(4))
            {
                var value = BitConverter.ToUInt32(_buffer, _readPosition);
                _readPosition += 4;
                return value;
            }

            throw EobException;
        }

        internal bool TakeBoolean()
        {
            return TakeUInt32() == 1;
        }

        internal string TakeString(byte length)
        {
            return Encoding.UTF8.GetString(TakeBytes(length));
        }

        internal byte[] TakeBytes(int length)
        {
            if (CheckAvailable(length))
            {
                var value = new byte[length];
                Buffer.BlockCopy(_buffer, _readPosition, value, 0, length);
                _readPosition += length;
                return value;
            }

            throw EobException;
        }

        internal byte[] TakeAllBytes()
        {
            var value = new byte[_bufferLength - _readPosition];
            Buffer.BlockCopy(_buffer, _readPosition, value, 0, value.Length);
            _readPosition = _bufferLength;
            return value;
        }

        private bool CheckAvailable(int length = 0)
        {
            return _readPosition + length <= _bufferLength;
        }
    }
}