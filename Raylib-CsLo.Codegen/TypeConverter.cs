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
            "Camera" => "Camera3D",
            "Camera*" => "Camera3D*",
            "char" => "sbyte",
            "char*" => "sbyte*",
            "char**" => "sbyte**",
            "const GlyphInfo*" => "GlyphInfo*",
            "GuiStyle" => "uint*",
            "int*" => "int*",
            "LoadFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>",
            "LoadFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "Matrix" => "Matrix4x4",
            "Matrix*" => "Matrix4x4*",
            "RenderTexture2D" => "RenderTexture",
            "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
            "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "Texture2D" => "Texture",
            "Texture2D*" => "Texture*",
            "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",
            "unsigned char*" => "byte*",
            "unsigned int" => "uint",
            "unsigned int*" => "uint*",
            "void*" => "void*",

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
            "Vector2*" => "Vector2[]",
            "Matrix4x4*" => "Matrix4x4[]",
            "Camera*" => "Camera",
            "Camera" => "ref Camera",
            "Camera3D" => "ref Camera3D",
            "Image*" => "ref Image",
            "Camera3D*" => "Camera3D",
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
