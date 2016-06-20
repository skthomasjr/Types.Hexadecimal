#region using directives

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;

#endregion

namespace Types.HexByte
{
    /// <summary>
    ///     Represents a static string of <see cref="HexByte" />.
    /// </summary>
    public struct Hex
    {
        #region fields and constants

        private HexByte[] data;

        #endregion

        #region methods and other members

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
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        /// <exclude />
        public static implicit operator Hex(int value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        /// <exclude />
        public static implicit operator Hex(long value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
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

        #endregion
    }
}