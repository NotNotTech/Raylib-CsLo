// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class CodegenSettings
{
    public const string NamespaceName = "Raylib_CsLo";

    public static string OutputFolder { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo/codegen/";
    public static string BindingsFolder { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo.Codegen/bindings/";

    public const string Utf8ToStringFunction = "Helpers.Utf8ToString";
    public const string PrtToArrayFunction = "Helpers.PrtToArray";

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
        "TextFormat",
        "TextJoin",
        "TextLength",
        "TextSplit",
        "TraceLog",
        "UpdateAudioStream",
        "UpdateCamera",
        "UpdateTexture",
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
        { "LoadImageRaw", ("PixelFormat", "format") },
        { "LoadTextureCubemap", ("CubemapLayout", "layout") },
        { "SetCameraMode", ("CameraMode", "mode") },
        { "SetConfigFlags", ("ConfigFlags", "flags") },
        { "SetExitKey", ("KeyboardKey", "key") },
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
