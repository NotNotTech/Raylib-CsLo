// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright © Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Raylib_CsLo.InternalHelpers;

/// <summary>
/// helper marshalling struct convert byte sized CBOOL's to/from dotnet
/// <para>You should be able to ignore this type.   treat it just as you would a normal bool.</para>
/// </summary>
[DebuggerDisplay("{ToString(),raw}")]
public readonly partial struct Bool : IEquatable<Bool>
{
	[MarshalAs(UnmanagedType.U1)]
	private readonly byte _val;

	public Bool(bool value)
	{
		this._val = Convert.ToByte(value);
	}

	public Bool(byte value)
	{
		_val = value;
	}

	public bool Equals(Bool other)
	{
		return _val == other._val;
	}

	public override string ToString()
	{
		return Convert.ToBoolean(_val).ToString();
	}

	public static implicit operator bool(Bool cb) => Convert.ToBoolean(cb._val);
	public static implicit operator Bool(bool value) => new(value);
	public static implicit operator byte(Bool cb) => Convert.ToByte(cb._val);
	public static implicit operator Bool(byte value) => new(value);

}
