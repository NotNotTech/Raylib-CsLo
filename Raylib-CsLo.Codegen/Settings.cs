// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Settings
{
    public const string NamespaceName = "Raylib_CsLo";

    public static string OutputFolder { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo/codegen/";
    public static string BindingsFolder { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo.Codegen/bindings/";

    public const string Utf8ToStringFunction = "Helpers.Utf8ToString";
    public const string PrtToArrayFunction = "Helpers.CopyPtrToArray";

    public const string CodeHeader = "// Copyright ©️ Raylib-CsLo and Contributors.\n// This file is licensed to you under the MPL-2.0.\n// See the LICENSE file in the project root for more info.\n// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo\n\n// Warning This file is auto generated and changes will be lost";

    public static readonly string[] FunctionsToHandleManually =
    {
        "DecodeDataBase64",
        "EncodeDataBase64",
        "GetCodepoint",
        "GetDirectoryFiles",
        "GetDroppedFiles",
        "GetGestureDetected",
        "LoadFileData",
        "LoadImageColors",
        "LoadImagePalette",
        "LoadModelAnimations",
        "rlReadScreenPixels",
        "SetLoadFileDataCallback",
        "SetLoadFileTextCallback",
        "SetSaveFileDataCallback",
        "SetSaveFileTextCallback",
        "SetTraceLogCallback",
        "UpdateAudioStream",
        "UpdateCamera",
        "UpdateTexture",

        // Removed do not implement
        "TextAppend",
        "TextFormat",
        "TextJoin",
        "TextLength",
        "TextSplit",
        "TraceLog",
        "UnloadImageColors",
    };

    public static readonly string[] StructsOverride =
    {
        "Matrix",
        "Quaternion",
        "Rectangle",
        "Texture",
        "Vector2",
        "Vector3",
        "Vector4",
    };

    public static readonly string[] DefinesOverride =
    {
        "KEY_RIGHT",
        "KEY_LEFT",
        "KEY_DOWN",
        "KEY_UP",
        "KEY_BACKSPACE",
        "KEY_ENTER",
    };

    // Overrides a parameter of a function with the name to be the safe enum type instead of int
    public static readonly Dictionary<string, (string type, string name)> ParamTypeEnumOverride = new()
    {
        { "BeginBlendMode", ("BlendMode", "mode") },
        { "ClearWindowState", ("ConfigFlags", "flags") },
        { "DrawTextCodepoints", ("IntPtr", "codepoints") },
        { "GetGamepadAxisMovement", ("GamepadAxis", "axis") },
        { "ImageFormat", ("PixelFormat", "newFormat") },
        { "IsGamepadButtonDown", ("GamepadButton", "button") },
        { "IsGamepadButtonPressed", ("GamepadButton", "button") },
        { "IsGamepadButtonReleased", ("GamepadButton", "button") },
        { "IsGamepadButtonUp", ("GamepadButton", "button") },
        { "IsGestureDetected", ("Gesture", "gesture") },
        { "IsKeyDown", ("KeyboardKey", "key") },
        { "IsKeyPressed", ("KeyboardKey", "key") },
        { "IsKeyReleased", ("KeyboardKey", "key") },
        { "IsKeyUp", ("KeyboardKey", "key") },
        { "IsMouseButtonDown", ("MouseButton", "button") },
        { "IsMouseButtonPressed", ("MouseButton", "button") },
        { "IsMouseButtonReleased", ("MouseButton", "button") },
        { "IsMouseButtonUp", ("MouseButton", "button") },
        { "IsWindowState", ("ConfigFlags", "flag") },
        { "LoadFontData", ("IntPtr", "fontChars") },
        { "LoadFontEx", ("IntPtr", "fontChars") },
        { "LoadFontFromMemory", ("IntPtr", "fontChars") },
        { "LoadImageRaw", ("PixelFormat", "format") },
        { "LoadTextureCubemap", ("CubemapLayout", "layout") },
        { "SetCameraMode", ("CameraMode", "mode") },
        { "SetConfigFlags", ("ConfigFlags", "flags") },
        { "SetExitKey", ("KeyboardKey", "key") },
        { "SetGesturesEnabled", ("Gesture", "flags") },
        { "SetMaterialTexture", ("MaterialMapIndex", "mapType") },
        { "SetMouseCursor", ("MouseCursor", "cursor") },
        { "SetTextureFilter", ("TextureFilter", "filter") },
        { "SetTextureWrap", ("TextureWrap", "wrap") },
        { "SetWindowState", ("ConfigFlags", "flags") },
    };

    // casts the above back to unsafe int type usually
    public static readonly Dictionary<string, string> EnumCastType = new()
    {
        { "ConfigFlags", "(uint)" },

        { "BlendMode", "(int)" },
        { "CameraMode", "(int)" },
        { "CubemapLayout", "(int)" },
        { "GamepadAxis", "(int)" },
        { "GamepadButton", "(int)" },
        { "Gesture", "(int)" },
        { "KeyboardKey", "(int)" },
        { "MaterialMapIndex", "(int)" },
        { "MouseButton", "(int)" },
        { "MouseCursor", "(int)" },
        { "PixelFormat", "(int)" },
        { "TextureFilter", "(int)" },
        { "TextureWrap", "(int)" },
    };

    // Converts C to unsafe C#
    public static readonly Dictionary<string, string> CToUnsafeConversion = new()
    {
        { "LoadFileDataCallback", "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>" },
        { "LoadFileTextCallback", "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>" },
        { "SaveFileDataCallback", "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>" },
        { "SaveFileTextCallback", "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>" },
        { "TraceLogCallback", "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>" },

        { "Camera", "Camera3D" },
        { "Camera*", "Camera3D*" },
        { "const GlyphInfo*", "GlyphInfo*" },
        { "float16", "Float16" },
        { "float3", "Float3" },
        { "GuiStyle", "uint*" },
        { "Matrix", "Matrix4x4" },
        { "Matrix*", "Matrix4x4*" },
        { "PhysicsBody", "PhysicsBodyData" },
        { "PhysicsBody*", "PhysicsBodyData" },
        { "PhysicsShapeType", "PhysicsShape" },
        { "PhysicsShapeType*", "PhysicsShape*" },
        { "rAudioBuffer", "RAudioBuffer" },
        { "rAudioBuffer*", "RAudioBuffer*" },
        { "RenderTexture2D", "RenderTexture" },
        { "rlDrawCall*", "RlDrawCall*" },
        { "rlFramebufferAttachType", "RlFramebufferAttachType" },
        { "rlRenderBatch", "RlRenderBatch" },
        { "rlRenderBatch*", "RlRenderBatch*" },
        { "rlVertexBuffer*", "RlVertexBuffer*" },
        { "Texture", "Texture2D" },
        { "Texture*", "Texture2D*" },
        { "TextureCubemap", "Texture2D" },

        { "char", "sbyte" },
        { "char*", "sbyte*" },
        { "char**", "sbyte**" },
        { "int*", "int*" },
        { "unsigned char", "byte" },
        { "unsigned char*", "byte*" },
        { "unsigned int", "uint" },
        { "unsigned int*", "uint*" },
        { "unsigned long long", "ulong" },
        { "unsigned short", "ushort" },
        { "unsigned short*", "ushort*" },
        { "void*", "void*" },

        { "...", "__arglist" }// var args arry},
    };

    // Converts unsafe C# to safe C#
    public static readonly Dictionary<string, string> UnsafeToSafeConversion = new()
    {
        { "byte*", "byte[]" },
        { "Camera", "Camera" },
        { "Camera*", "ref Camera" },
        { "Camera3D", "Camera3D" },
        { "Camera3D*", "ref Camera3D" },
        { "Color*", "Color[]" },
        { "Image*", "ref Image" },
        { "int*", "int*" },
        { "Matrix4x4*", "Matrix4x4[]" },
        { "PhysicsBodyData", "PhysicsBodyData" },
        { "sbyte*", "string" },
        { "Texture2D*", "ref Texture2D" },
        { "Vector2*", "Vector2[]" },
        { "Rectangle*", "Rectangle[]" },
        { "void*", "IntPtr" },

        { "__arglist", "params object[]" },
    };

    public static string TryGetSolutionDirectoryInfo()
    {
        DirectoryInfo directory = new(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }
        return directory.FullName;
    }
}
