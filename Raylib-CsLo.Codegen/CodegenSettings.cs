// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.IO;
using System.Linq;

public static class CodegenSettings
{
    public const string NamespaceName = "Raylib_CsLo";

    public static string OutputFolder { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo/codegen/";
    public static string ApiJsonFile { get; } = TryGetSolutionDirectoryInfo() + "/Raylib-CsLo.Codegen/bindings/raylib_api.json";

    public const string Utf8ToStringFunction = "Helpers.Utf8ToString";
    public const string PrtToArrayFunction = "Helpers.PrtToArray";
    public const string ArrayToPtrFunction = "Helpers.ArrayToPtr";

    public static readonly string[] FunctionsToHandleManually =
    {
        "TraceLog",
        "SetTraceLogCallback",

        "SetLoadFileDataCallback",
        "SetSaveFileDataCallback",
        "SetLoadFileTextCallback",
        "SetSaveFileTextCallback",

        "GetDirectoryFiles",
        "GetDroppedFiles",

        "LoadFileData",
        "LoadModelAnimations",

        "TextFormat",
        "TextJoin",
        "TextSplit",
    };

    // Thanks to the weird inconsistency between linux working dir and windows lets just do this
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
