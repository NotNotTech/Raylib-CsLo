// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.Toolkit.HighPerformance.Buffers;

namespace Raylib_CsLo.InternalHelpers;

public unsafe static class Helpers
{
	/// <summary>
	/// help convert a utf8 vector to string
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="utf8Text"></param>
	/// <returns></returns>
	public static string Utf8ToString<T>(T* utf8Text) where T:unmanaged
	{
		return Marshal.PtrToStringUTF8((IntPtr)utf8Text);
	}
	//public static string ToString(string text) => text;

	//public static string ToString(object obj) => obj.ToString();
	

}

