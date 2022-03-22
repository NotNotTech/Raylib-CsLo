// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using System;
using System.Runtime.InteropServices;

public static unsafe class Helpers
{
    public static string Utf8ToString<T>(T* utf8Text) where T : unmanaged
    {
        return Marshal.PtrToStringUTF8((IntPtr)utf8Text) ?? "";
    }

    public static T[] CopyPtrToArray<T>(T* ptrToArray, int length) where T : unmanaged
    {
        T[] array = new T[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = ptrToArray[i];
        }

        return array;
    }
}
