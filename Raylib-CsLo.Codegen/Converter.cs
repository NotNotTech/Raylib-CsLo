// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

public static class Converter
{
    // Used in gen of DllImport
    public static string FromCToUnsafeCs(string type)
    {
        type = type.Replace("const ", "");
        return type switch
        {
            "LoadFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>",
            "LoadFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
            "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
            "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",

            "Camera" => "Camera3D",
            "Camera*" => "Camera3D*",
            "const GlyphInfo*" => "GlyphInfo*",
            "float16" => "Float16",
            "float3" => "Float3",
            "GuiStyle" => "uint*",
            "Matrix" => "Matrix4x4",
            "Matrix*" => "Matrix4x4*",
            "PhysicsBody" => "PhysicsBodyData",
            "PhysicsBody*" => "PhysicsBodyData",
            "PhysicsShapeType" => "PhysicsShape",
            "PhysicsShapeType*" => "PhysicsShape*",
            "rAudioBuffer" => "RAudioBuffer",
            "rAudioBuffer*" => "RAudioBuffer*",
            "RenderTexture2D" => "RenderTexture",
            "rlDrawCall*" => "RlDrawCall*",
            "rlFramebufferAttachType" => "RlFramebufferAttachType",
            "rlRenderBatch" => "RlRenderBatch",
            "rlRenderBatch*" => "RlRenderBatch*",
            "rlVertexBuffer*" => "RlVertexBuffer*",
            "Texture" => "Texture2D",
            "Texture*" => "Texture2D*",
            "TextureCubemap" => "Texture2D",

            "char" => "sbyte",
            "char*" => "sbyte*",
            "char**" => "sbyte**",
            "int*" => "int*",
            "unsigned char" => "byte",
            "unsigned char*" => "byte*",
            "unsigned int" => "uint",
            "unsigned int*" => "uint*",
            "unsigned long long" => "ulong",
            "unsigned short" => "ushort",
            "unsigned short*" => "ushort*",
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
            "Camera" => "Camera",
            "Camera*" => "ref Camera",
            "Camera3D" => "Camera3D",
            "Camera3D*" => "ref Camera3D",
            "Color*" => "Color[]",
            "Image*" => "ref Image",
            "int*" => "int*",
            "Matrix4x4*" => "Matrix4x4[]",
            "PhysicsBodyData" => "PhysicsBodyData",
            "sbyte*" => "string",
            "Vector2*" => "Vector2[]",
            "void*" => "IntPtr",

            "__arglist" => "params object[]",
            _ => unsafeType,
        };
    }

    public static string FromSnakeToPascalCase(string value)
    {
        string[] words = value.Split('_');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 1)
            {
                words[i] = words[i][0] + words[i][1..].ToLowerInvariant();
            }
        }
        return string.Join("", words);
    }
}
