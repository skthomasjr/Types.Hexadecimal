#region using directives

using System;
using System.Diagnostics.Contracts;
using System.Numerics;

#endregion

namespace Types.Hexadecimal
{
    /// <summary>
    ///     Represents a <see cref="byte" /> that can be manipulated as hexadecimal.
    /// </summary>
    [Serializable]
    public struct HexByte : IComparable, IComparable<HexByte>, IEquatable<HexByte>, IConvertible
    {
        #region fields and constants

        private byte data;

        #endregion

        #region properties and indexers

        /// <summary>
        ///     The maximum value that a HexByte may represent: 0xff.
        /// </summary>
        /// <value>The maximum value.</value>
        public static HexByte MaxValue { get; } = 0xff;

        /// <summary>
        ///     The minimum value that a HexByte may represent: 0x00.
        /// </summary>
        /// <value>The maximum value.</value>
        public static HexByte MinValue { get; } = 0x00;

        #endregion

        #region methods and other members

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, HexByte value)
        {
            return hexByte.data + value.data;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, byte value)
        {
            return hexByte + (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, string value)
        {
            return hexByte + (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, short value)
        {
            return hexByte + (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, int value)
        {
            return hexByte + (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, long value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator +(HexByte hexByte, BigInteger value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static explicit operator byte(HexByte value)
        {
            return value.data;
        }

        /// <exclude />
        public static explicit operator int(HexByte value)
        {
            return value.data;
        }

        /// <exclude />
        public static explicit operator long(HexByte value)
        {
            return value.data;
        }

        /// <exclude />
        public static explicit operator BigInteger(HexByte value)
        {
            return value.data;
        }

        /// <exclude />
        public static explicit operator string(HexByte value)
        {
            return value.data.ToString("X2").ToLowerInvariant();
        }

        /// <exclude />
        public static implicit operator HexByte(byte value)
        {
            return new HexByte {data = value};
        }

        /// <exclude />
        public static implicit operator HexByte(int value)
        {
            if (value < 0 || value > 255)
                throw new OverflowException("Value was either too large or too small for a HexByte.");

            return new HexByte {data = (byte) value};
        }

        /// <exclude />
        public static implicit operator HexByte(long value)
        {
            if (value < 0 || value > 255)
                throw new OverflowException("Value was either too large or too small for a HexByte.");

            return new HexByte {data = (byte) value};
        }

        /// <exclude />
        public static implicit operator HexByte(BigInteger value)
        {
            if (value < 0 || value > 255)
                throw new OverflowException("Value was either too large or too small for a HexByte.");

            return new HexByte {data = (byte) value};
        }

        /// <exclude />
        public static implicit operator HexByte(string value)
        {
            if (value.Length == 0) value = "00";
            if (value.Length == 1) value = $"0{value}";
            return new HexByte {data = Convert.ToByte(value, 16)};
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, HexByte value)
        {
            return hexByte.data - value.data;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, string value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, byte value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, short value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, int value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, long value)
        {
            return hexByte - (HexByte) value;
        }

        /// <exclude />
        public static HexByte operator -(HexByte hexByte, BigInteger value)
        {
            return hexByte - (HexByte) value;
        }

        /// <summary>
        ///     Determines if two HexByte objects are equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns><c>true</c> if the objects are equal, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is HexByte)) return false;

            return data == ((HexByte) obj).data;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return data;
        }

        /// <summary>
        ///     Returns a <see cref="String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="String" /> that represents this instance.</returns>
        [Pure]
        public override string ToString()
        {
            return (string) this;
        }

        /// <summary>
        ///     Returns a <see cref="Byte" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="Byte" /> that represents this instance.</returns>
        [Pure]
        public byte ToByte()
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

            if (!(value is HexByte)) throw new ArgumentException("The comparison argument must be a HexByte.");

            return data - ((HexByte) value).data;
        }

        #endregion

        #region implementations for IComparable<HexByte>

        /// <exclude />
        int IComparable<HexByte>.CompareTo(HexByte value)
        {
            return ((IComparable) this).CompareTo(value);
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
            return Convert.ToBoolean(data);
        }

        /// <exclude />
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(data);
        }

        /// <exclude />
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(data);
        }

        /// <exclude />
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return data;
        }

        /// <exclude />
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(data);
        }

        /// <exclude />
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(data);
        }

        /// <exclude />
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(data);
        }

        /// <exclude />
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(data);
        }

        /// <exclude />
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(data);
        }

        /// <exclude />
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(data);
        }

        /// <exclude />
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(data);
        }

        /// <exclude />
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(data);
        }

        /// <exclude />
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(data);
        }

        /// <exclude />
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("A cast of HexByte to/from DateTime is invalid.");
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

        #region implementations for IEquatable<HexByte>

        /// <summary>
        ///     Determines if two HexByte objects are equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns><c>true</c> if the objects are equal, <c>false</c> otherwise.</returns>
        public bool Equals(HexByte obj)
        {
            return data == obj.data;
        }

        #endregion
    }
}