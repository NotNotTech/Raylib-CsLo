// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Collections.Generic;

public static class TypeConverter
{
    public static List<string> UnsafePrinted { get; } = new();
    public static List<string> SafePrinted { get; } = new();

    // Used in gen of DllImport
    public static string FromCToUnsafeCs(string type)
    {
        type = type.Replace("const ", "");
        return type switch
        {
            "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",
            "LoadFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>",
            "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
            "LoadFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "char*" => "sbyte*",
            "char" => "sbyte",
            "char**" => "sbyte**",
            "unsigned char*" => "byte*",
            "unsigned int" => "uint",
            "unsigned int*" => "uint*",
            "int*" => "int*",
            "void*" => "void*",
            "RenderTexture2D" => "RenderTexture",
            "Texture2D" => "Texture",
            "Texture2D*" => "Texture*",
            "const GlyphInfo*" => "GlyphInfo*",
            "Camera" => "Camera3D",
            "Camera*" => "Camera3D*",
            "Matrix" => "Matrix4x4",
            "Matrix*" => "Matrix4x4*",
            "..." => "__arglist", // var args array
            _ => LogToUnsafeUnhandled(type),
        };
    }

    // Uses the above output as input
    // Used in gen of Safe Cs types
    public static string FromCToSafeCs(string type)
    {
        string unsafeType = FromCToUnsafeCs(type);
        return unsafeType switch
        {
            "void*" => "IntPtr",
            "byte*" => "byte[]",
            "Color*" => "Color[]",
            "int*" => "int*",
            "sbyte*" => "string",
            "__arglist" => "params object[]",
            _ => LogToSafeUnhandled(unsafeType),
        };
    }

    static string LogToUnsafeUnhandled(string type)
    {
        if (!UnsafePrinted.Contains(type))
        {
            UnsafePrinted.Add(type);
        }
        return type;
    }

    static string LogToSafeUnhandled(string type)
    {
        if (!SafePrinted.Contains(type))
        {
            SafePrinted.Add(type);
        }
        return type;
    }
}
