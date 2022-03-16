// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
public static class TypeConverter
{
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
            "PhysicsBody" => "PhysicsBodyData",
            "RenderTexture2D" => "RenderTexture",
            "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
            "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "Texture2D" => "Texture",
            "Texture2D*" => "Texture*",
            "TextureCubemap" => "Texture",
            "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",
            "unsigned char" => "byte",
            "unsigned char*" => "byte*",
            "unsigned int" => "uint",
            "unsigned int*" => "uint*",
            "unsigned long long" => "ulong",
            "void*" => "void*",

            "..." => "__arglist", // var args array
            _ => type,
        };
    }

    // Uses the above output as input
    // Used in gen of Safe Cs types
    public static string FromCToSafeCs(string type)
    {
        string unsafeType = FromCToUnsafeCs(type);
        return unsafeType switch
        {
            "byte*" => "byte[]",
            "Camera" => "ref Camera",
            "Camera*" => "Camera",
            "Camera3D" => "ref Camera3D",
            "Camera3D*" => "Camera3D",
            "Color*" => "Color[]",
            "Image*" => "ref Image",
            "int*" => "int*",
            "Matrix4x4*" => "Matrix4x4[]",
            "sbyte*" => "string",
            "Vector2*" => "Vector2[]",
            "void*" => "IntPtr",

            "__arglist" => "params object[]",
            _ => unsafeType,
        };
    }
}
