// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;

public static class CodegenSettings
{
    public static string OutputFolder { get; } = Path.GetFullPath("../Raylib-CsLo/autogen/wrappers/");
    public static string ApiJsonFile { get; } = Path.GetFullPath("../sub-modules/raylib/parser/raylib_api.json");

    public static readonly string[] LastFunctionInModule =
    {
        "SetCameraMoveControls",
        "GetCollisionRec",
        "GetPixelDataSize",
        "TextToInteger",
        "GetRayCollisionQuad"
    };

    public const string NamespaceName = "Raylib_CsLo";
    public static readonly string[] Usings =
    {
        "System.Numerics",
        "Microsoft.Toolkit.HighPerformance.Buffers",
        "Raylib_CsLo.InternalHelpers",
    };
}
