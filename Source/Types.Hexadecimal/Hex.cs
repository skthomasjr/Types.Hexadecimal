#region using directives

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;

#endregion

namespace Types.Hexadecimal
{
    /// <summary>
    ///     Represents a static string of <see cref="HexByte" />.
    /// </summary>
    public struct Hex : IComparable, IComparable<Hex>, IEquatable<Hex>, IConvertible
    {
        #region fields and constants

        private HexByte[] data;

        #endregion

        #region methods and other members

        /// <exclude />
        public static Hex operator +(Hex hex, Hex value)
        {
            return hex.ToBigInteger() + value.ToBigInteger();
        }

        /// <exclude />
        public static Hex operator +(Hex hex, byte[] value)
        {
            return hex + (Hex)value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, byte value)
        {
            return hex + (Hex)value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, string value)
        {
            return hex + (Hex) value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, short value)
        {
            return hex + (Hex) value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, int value)
        {
            return hex + (Hex) value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, long value)
        {
            return hex + (Hex) value;
        }

        /// <exclude />
        public static Hex operator +(Hex hex, BigInteger value)
        {
            return hex + (Hex) value;
        }

        /// <exclude />
        public static explicit operator byte[](Hex value)
        {
            return value.data.Select(h => h.ToByte()).ToArray();
        }

        /// <exclude />
        public static explicit operator short(Hex value)
        {
            if (value.data.Length > 2)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "The Hex value specified is too large to be converted to an Int16.");

            return BitConverter.ToInt16(PaddedBytes(value, 2), 0);
        }

        /// <exclude />
        public static explicit operator int(Hex value)
        {
            if (value.data.Length > 4)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "The Hex value specified is too large to be converted to an Int32.");

            return BitConverter.ToInt32(PaddedBytes(value, 4), 0);
        }

        /// <exclude />
        public static explicit operator long(Hex value)
        {
            if (value.data.Length > 8)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "The Hex value specified is too large to be converted to an Int64.");

            return BitConverter.ToInt32(PaddedBytes(value, 8), 0);
        }

        /// <exclude />
        public static explicit operator BigInteger(Hex value)
        {
            return new BigInteger(((byte[]) value).Reverse().ToArray());
        }

        /// <exclude />
        public static explicit operator string(Hex value)
        {
            return value.data.Select(h => h.ToString()).Aggregate((current, next) => $"{current}{next}");
        }

        /// <exclude />
        public static implicit operator Hex(byte[] value)
        {
            return new Hex {data = value.Select(b => (HexByte) b).ToArray()};
        }

        /// <exclude />
        public static implicit operator Hex(short value)
        {
            var bytes = BitConverter.GetBytes(value).Reverse();
            return TrimPadding(bytes);
        }

        /// <exclude />
        public static implicit operator Hex(int value)
        {
            var bytes = BitConverter.GetBytes(value).Reverse();
            return TrimPadding(bytes);
        }

        /// <exclude />
        public static implicit operator Hex(long value)
        {
            var bytes = BitConverter.GetBytes(value).Reverse();
            return TrimPadding(bytes);
        }

        /// <exclude />
        public static implicit operator Hex(BigInteger value)
        {
            return value.ToByteArray().Reverse().ToArray();
        }

        /// <exclude />
        public static implicit operator Hex(string value)
        {
            return new Hex
            {
                data = Enumerable.Range(0, value.Length)
                    .Where(index => index%2 == 0)
                    .Select(index => (HexByte) value.Substring(index, 2))
                    .ToArray()
            };
        }

        /// <exclude />
        public static Hex operator -(Hex hex, Hex value)
        {
            return hex.ToBigInteger() - value.ToBigInteger();
        }

        /// <exclude />
        public static Hex operator -(Hex hex, byte[] value)
        {
            return hex - (Hex)value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, byte value)
        {
            return hex - (Hex)value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, string value)
        {
            return hex - (Hex) value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, short value)
        {
            return hex - (Hex) value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, int value)
        {
            return hex - (Hex) value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, long value)
        {
            return hex - (Hex) value;
        }

        /// <exclude />
        public static Hex operator -(Hex hex, BigInteger value)
        {
            return hex - (Hex) value;
        }

        private static byte[] PaddedBytes(Hex hex, int targetSize)
        {
            var paddedBytes = new List<byte>((byte[]) hex);
            paddedBytes.Reverse();

            for (var i = 0; i < targetSize - hex.data.Length; i++)
            {
                paddedBytes.Add(0x00);
            }

            return paddedBytes.ToArray();
        }

        private static byte[] TrimPadding(IEnumerable<byte> bytes)
        {
            var byteList = bytes.ToList();
            while (byteList.First() == 0x00)
            {
                byteList.RemoveAt(0);
            }
            return byteList.ToArray();
        }

        /// <summary>
        ///     Determines if two Hex objects are equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns><c>true</c> if the objects are equal, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Hex)) return false;

            return data == ((Hex) obj).data;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        [Pure]
        public override string ToString()
        {
            return (string) this;
        }

        /// <summary>
        ///     Enumerates the <see cref="HexByte" /> in the <see cref="Hex" />.
        /// </summary>
        /// <returns>IEnumerable&lt;HexBytes&gt;.</returns>
        public IEnumerable<HexByte> AsEnumerable()
        {
            foreach (var hexByte in data)
            {
                yield return hexByte;
            }
        }

        /// <summary>
        ///     Returns a <see cref="BigInteger" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="BigInteger" /> that represents this instance.</returns>
        [Pure]
        public BigInteger ToBigInteger()
        {
            return (BigInteger) this;
        }

        /// <summary>
        ///     Returns an array of <see cref="Byte" /> that represents this instance.
        /// </summary>
        /// <returns>An array of <see cref="Byte" /> that represents this instance.</returns>
        [Pure]
        public byte[] ToByteArray()
        {
            return data.Select(b => (byte) b).ToArray();
        }

        /// <summary>
        ///     Returns an array of <see cref="HexByte" /> that represents this instance.
        /// </summary>
        /// <returns>An array of <see cref="HexByte" /> that represents this instance.</returns>
        [Pure]
        public HexByte[] ToHexByteArray()
        {
            return data;
        }

        /// <summary>
        ///     Returns a <see cref="Int32" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="Int32" /> that represents this instance.</returns>
        [Pure]
        public int ToInt32()
        {
            return (int) this;
        }

        /// <summary>
        ///     Returns a <see cref="Int64" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="Int64" /> that represents this instance.</returns>
        [Pure]
        public long ToInt64()
        {
            return (long) this;
        }

        #endregion

        #region implementations for IComparable

        /// <exclude />
        int IComparable.CompareTo(object value)
        {
            if (value == null) return 1;

            if (!(value is Hex)) throw new ArgumentException("The comparison argument must be a Hex.");

            return ((BigInteger) this).CompareTo(value);
        }

        #endregion

        #region implementations for IComparable<Hex>

        /// <exclude />
        int IComparable<Hex>.CompareTo(Hex value)
        {
            return ((BigInteger) this).CompareTo(value);
        }

        #endregion

        #region implementations for IConvertible

        /// <exclude />
        [Pure]
        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        /// <exclude />
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of Hex to/from Boolean is invalid.");
        }

        /// <exclude />
        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of Hex to/from Char is invalid.");
        }

        /// <exclude />
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of Hex to/from SByte is invalid.");
        }

        /// <exclude />
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of Hex to/from Byte is invalid.");
        }

        /// <exclude />
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16((short) this);
        }

        /// <exclude />
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16((short) this);
        }

        /// <exclude />
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32((int) this);
        }

        /// <exclude />
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32((int) this);
        }

        /// <exclude />
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64((long) this);
        }

        /// <exclude />
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64((long) this);
        }

        /// <exclude />
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle((BigInteger) this);
        }

        /// <exclude />
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble((BigInteger) this);
        }

        /// <exclude />
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal((BigInteger) this);
        }

        /// <exclude />
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of Hex to/from DateTime is invalid.");
        }

        /// <exclude />
        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString();
        }

        /// <exclude />
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(this, conversionType, provider);
        }

        #endregion

        #region implementations for IEquatable<Hex>

        /// <summary>
        ///     Determines if two Hex objects are equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns><c>true</c> if the objects are equal, <c>false</c> otherwise.</returns>
        public bool Equals(Hex obj)
        {
            return data == obj.data;
        }

        #endregion
    }
}