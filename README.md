# Types.Hexadecimal

[![Build](https://ci.appveyor.com/api/projects/status/w1j859w3vdi5ym9q?svg=true)](https://ci.appveyor.com/project/skthomasjr/types-hexadecimal)
[![Release](https://img.shields.io/github/release/skthomasjr/Types.Hexadecimal.svg?maxAge=2592000)](https://github.com/skthomasjr/Types.Hexadecimal/releases)
[![NuGet](https://img.shields.io/nuget/v/Types.Hexadecimal.svg)](https://www.nuget.org/packages/Types.Hexadecimal)
[![License](https://img.shields.io/github/license/skthomasjr/Types.Hexadecimal.svg?maxAge=2592000)](LICENSE.md)
[![Author](https://img.shields.io/badge/author-Scott%20K.%20Thomas%2C%20Jr.-blue.svg?maxAge=2592000)](https://www.linkedin.com/in/skthomasjr)
[![Join the chat at https://gitter.im/skthomasjr/Types.Hexadecimal](https://badges.gitter.im/skthomasjr/Types.Hexadecimal.svg)](https://gitter.im/skthomasjr/Types.Hexadecimal?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Types.Hexadecimal is a library providing simple types and extensions to support hexadecimal (hex) numeral system. Two types are provided to support hexadecimal operations HexByte which represents a single byte value and Hex which represents an arbitrarily large signed integer made up of a collection of HexBytes. HexByte is represented with a two character hex string in the hex range of "00" to "ff". Hex is represented as an even lengthed string such as "0a2f4b998e" where every two characters is a HexByte. 

HexByte supports implicit and explicit casts to the following types:
- String (string)
- Byte (byte)
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
HexByte hexByte = "af"; // 0xaf
// or
HexByte hexByte = 175; // 0xaf
```
HexByte supports add(+) and subtract(-) operation with the following types:
- HexByte
- String (string)
- Byte (byte)
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
var hexByte = (HexByte)"af" - 1; // 0xae
// or
var hexByte = (HexByte)175 + 1; // 0xb0
```
Hex supports implicit and explicit casts to the following types:
- String (string)
- Byte\[\] (byte\[\])
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
Hex hex = "afaf"; // 0xaf, 0xaf
// or
Hex hex = 44975; // 0xaf, 0xaf
```
Hex supports add(+) and subtract(-) operation with the following types:
- Hex
- String (string)
- Byte\[\] (byte\[\])
- Byte (byte)
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
var hex = (Hex)"afaf" - 1; // 0xaf, 0xae
// or
var hex = (Hex)44975 + 1; // 0xaf, 0xb0
```
