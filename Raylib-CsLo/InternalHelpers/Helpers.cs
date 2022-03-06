// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]
// [!!] Copyright ©️ Raylib-CsLo and Contributors.
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info.
// [!!] -------------------------------------------------
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.InternalHelpers;

using System;
using System.Runtime.InteropServices;

public static unsafe class Helpers
{
    /// <summary>
    /// help convert a utf8 vector to string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="utf8Text"></param>
    /// <returns></returns>
    public static string Utf8ToString<T>(T* utf8Text) where T : unmanaged
    {
        return Marshal.PtrToStringUTF8((IntPtr)utf8Text) ?? "";
    }
    //public static string ToString(string text) => text;

    //public static string ToString(object obj) => obj.ToString();


}
