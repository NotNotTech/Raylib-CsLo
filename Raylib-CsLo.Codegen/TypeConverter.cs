// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

public static class TypeConverter
{
    // Used in gen of DllImport
    public static string CToCsNativeTypes(string type)
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
            "..." => "params object[]", // var args array
            _ => type,
        };
    }

    // Used in gen of Safe Cs types
    public static string CToCsTypes(string type)
    {
        return type switch
        {
            "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",
            "LoadFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>",
            "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
            "LoadFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "const char*" => "sbyte*",
            "char*" => "sbyte*",
            "void*" => "IntPtr",
            "char" => "sbyte",
            "char**" => "sbyte**",
            "const char**" => "sbyte**",
            "const unsigned char*" => "byte*",
            "unsigned int" => "uint",
            "unsigned char*" => "byte*",
            "unsigned int*" => "uint*",
            "const void*" => "void*",
            "RenderTexture2D" => "RenderTexture",
            "Texture2D" => "Texture",
            "Texture2D*" => "Texture*",
            "const GlyphInfo*" => "GlyphInfo*",
            "Camera" => "Camera3D",
            "Camera*" => "Camera3D*",
            "Matrix" => "Matrix4x4",
            "Matrix*" => "Matrix4x4*",
            "..." => "params object[]", // var args array
            _ => type,
        };
    }

    // public static string CToCsTypes(string type)
    // {
    //     // remove const
    //     type = type.Replace("const ", "");

    //     // Convert C types to safe types
    //     type = type switch
    //     {
    //         "void*" => "IntPtr",
    //         "char*" => "string",
    //         "char**" => "string[]",
    //         "unsigned char*" => "byte[]",
    //
    //         _ => type
    //     };

    //     type = type.Replace("unsigned ", "u");

    //     // if (type.EndsWith("*"))
    //     // {
    //     //     type = "ref " + type[0..(type.Length - 1)];
    //     // }

    //     return type;
    // }
}
