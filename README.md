# Types.Hexadecimal

[![Build](https://ci.appveyor.com/api/projects/status/w1j859w3vdi5ym9q?svg=true)](https://ci.appveyor.com/project/skthomasjr/types-hexadecimal)
[![Release](https://img.shields.io/github/release/skthomasjr/Types.Hexadecimal.svg?maxAge=2592000)](https://github.com/skthomasjr/Types.Hexadecimal/releases)
[![NuGet](https://img.shields.io/nuget/v/Types.Hexadecimal.svg)](https://www.nuget.org/packages/Types.Hexadecimal)
[![License](https://img.shields.io/github/license/skthomasjr/Types.Hexadecimal.svg?maxAge=2592000)](LICENSE.md)
[![Author](https://img.shields.io/badge/author-Scott%20K.%20Thomas%2C%20Jr.-blue.svg?maxAge=2592000)](https://www.linkedin.com/in/skthomasjr)
[![Join the chat at https://gitter.im/skthomasjr/Types.Hexadecimal](https://badges.gitter.im/skthomasjr/Types.Hexadecimal.svg)](https://gitter.im/skthomasjr/Types.Hexadecimal?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Types.Hexadecimal is a library providing simple types and extensions to support hexadecimal (hex) numeral system.

Hex supports implicit and explicit casts to the following types:
- Byte`[`] (byte`[`])
- String (string)
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
Hex hex = "af"; // 0xaf
// or
Hex hex = 175; // 0xaf
```
Hex supports add(+) and subtract(-) operation with the following types:
- Hex
- String (string)
- Byte`[`] (byte`[`])
- Byte (byte)
- Int16 (short)
- Int32 (int)
- Int64 (long)
- BigInteger
```c#
var hex = (Hex)"af" - 1; // 0xae
// or
var hex = (Hex)175 + 1; // 0xb0
```
