
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

    // TODO implement
    public static T* ArrayToPtr<T>(T[] ptrToArray) where T : unmanaged
    {
        throw new NotImplementedException();
    }
}
