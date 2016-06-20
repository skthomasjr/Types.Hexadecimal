#region using directives

using System;
using System.Linq;
using System.Numerics;

#endregion

namespace Types.Hexadecimal.SampleConsole
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    internal class Program
    {
        #region methods and other members

        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var hex1 = (Hex) 1;
            var hex = (Hex) (short) 23535;

            Console.WriteLine("Cast various types to Hex:");
            Console.WriteLine("");
            Console.WriteLine($"Byte[] to Hex: {(Hex) new byte[] {0x5b, 0xef}}");
            Console.WriteLine($"String to Hex: {(Hex) "5bef"}");
            Console.WriteLine($"Int16 to Hex: {(Hex) (short) 23535}");
            Console.WriteLine($"Int32 to Hex: {(Hex) 23535}");
            Console.WriteLine($"Int64 to Hex: {(Hex) (long) 23535}");
            Console.WriteLine($"BigInteger to Hex: {(Hex) new BigInteger(23535)}");
            Console.WriteLine("");

            Console.WriteLine("Cast Hex to various types:");
            Console.WriteLine("");
            Console.WriteLine(
                $"Hex to Byte[]: {((byte[]) hex).Select(b => b.ToString()).Aggregate((b1, b2) => b1 + ", " + b2)}");
            Console.WriteLine($"Hex to String: {(string) hex}");
            Console.WriteLine($"Hex to Int16: {(short) hex}");
            Console.WriteLine($"Hex to Int32: {(int) hex}");
            Console.WriteLine($"Hex to Int64: {(long) hex}");
            Console.WriteLine($"Hex to BigInteger: {(BigInteger) hex}");
            Console.WriteLine("");

            Console.WriteLine("Adding to Hex:");
            Console.WriteLine("");
            Console.WriteLine($"Hex + 1 as Hex: {hex + hex1}");
            Console.WriteLine($"Hex + 1 as String: {hex + "01"}");
            Console.WriteLine($"Hex + 1 as Byte[]: {hex + new byte[] {0x01}}");
            Console.WriteLine($"Hex + 1 as Byte: {hex + 0x01}");
            Console.WriteLine($"Hex + 1 as Int16: {hex + (short) 1}");
            Console.WriteLine($"Hex + 1 as Int32: {hex + 1}");
            Console.WriteLine($"Hex + 1 as Int64: {hex + (long) 1}");
            Console.WriteLine($"Hex + 1 as BigInteger: {hex + (BigInteger) 1}");
            Console.WriteLine("");

            Console.WriteLine("Subtracting from Hex:");
            Console.WriteLine("");
            Console.WriteLine($"Hex - 1 as Hex: {hex - hex1}");
            Console.WriteLine($"Hex - 1 as String: {hex - "01"}");
            Console.WriteLine($"Hex - 1 as Byte[]: {hex - new byte[] {0x01}}");
            Console.WriteLine($"Hex - 1 as Byte: {hex - 0x01}");
            Console.WriteLine($"Hex - 1 as Int16: {hex - (short) 1}");
            Console.WriteLine($"Hex - 1 as Int32: {hex - 1}");
            Console.WriteLine($"Hex - 1 as Int64: {hex - (long) 1}");
            Console.WriteLine($"Hex - 1 as BigInteger: {hex - (BigInteger) 1}");
            Console.WriteLine("");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}