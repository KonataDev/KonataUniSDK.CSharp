using System;
using System.Text;

namespace KonataCSharp.SDK.Core
{
    internal static class ByteConverter
    {
        internal static T Cast<T>(byte[] data)
        {
            var type = typeof(T);

            return (T) (Type.GetTypeCode(type) switch
            {
                TypeCode.Boolean => Convert.ChangeType(BitConverter.ToBoolean(data, 0), type),
                TypeCode.Char => Convert.ChangeType(BitConverter.ToChar(data, 0), type),
                TypeCode.SByte => Convert.ChangeType((sbyte) data[0], type),
                TypeCode.Int16 => Convert.ChangeType(BitConverter.ToInt16(data, 0), type),
                TypeCode.Int32 => Convert.ChangeType(BitConverter.ToInt32(data, 0), type),
                TypeCode.Int64 => Convert.ChangeType(BitConverter.ToInt64(data, 0), type),
                TypeCode.Single => Convert.ChangeType(BitConverter.ToSingle(data, 0), type),
                TypeCode.Double => Convert.ChangeType(BitConverter.ToDouble(data, 0), type),
                TypeCode.Byte => Convert.ChangeType(data[0], type),
                TypeCode.UInt16 => Convert.ChangeType(BitConverter.ToUInt16(data, 0), type),
                TypeCode.UInt32 => Convert.ChangeType(BitConverter.ToUInt32(data, 0), type),
                TypeCode.UInt64 => Convert.ChangeType(BitConverter.ToUInt64(data, 0), type),
                TypeCode.String => Convert.ChangeType(Encoding.UTF8.GetString(data), type),
                _ => default
            });
        }
    }
}