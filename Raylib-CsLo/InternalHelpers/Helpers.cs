// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.InternalHelpers;

using System;
using System.Runtime.InteropServices;

public static unsafe class Helpers
{
    public static string Utf8ToString<T>(T* utf8Text) where T : unmanaged
    {
        return Marshal.PtrToStringUTF8((IntPtr)utf8Text) ?? "";
    }

    // TODO implement
    public static T[] PrtToArray<T>(T* ptrToArray) where T : unmanaged
    {
        throw new NotImplementedException();
    }
}
