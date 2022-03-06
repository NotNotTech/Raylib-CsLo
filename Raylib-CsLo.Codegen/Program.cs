// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static string OutputFolder { get; } = Path.Join(Path.GetFullPath("./"), "Raylib-CsLo/autogen/wrappers/");
    public static string ApiJsonFile { get; } = Path.Join(Path.GetFullPath("./"), "sub-modules\\raylib\\parser\\raylib_api.json");

    static string[] lastFunction = { "SetCameraMoveControls", "GetCollisionRec", "GetPixelDataSize", "TextToInteger", "GetRayCollisionQuad" };


    static readonly Dictionary<string, string> CSharpSafeEquivelent = new()
    {
        { "char *", "string" },
        { "unsigned int", "uint" },
        { "void *", "IntPtr" },

        // Alias TODO: Remove later
        { "RenderTexture2D", "RenderTexture" },
        { "Texture2D", "Texture" },
        { "TextureCubemap", "Texture" },
        { "Matrix", "Matrix4x4" },
    };

    public static void Main()
    {
        if (Directory.Exists(OutputFolder))
        {
            Directory.Delete(OutputFolder, true);
        }
        Directory.CreateDirectory(OutputFolder);

        Dictionary<RaylibModule, List<RaylibFunction>> modules = new();
        modules.Add(RaylibModule.Core, new List<RaylibFunction>());

        using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(ApiJsonFile)))
        {
            RaylibModule module = RaylibModule.Core;
            foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
            {
                RaylibFunction func = JsonSerializer.Deserialize<RaylibFunction>(element);

                if (CSharpSafeEquivelent.TryGetValue(SantizeTypes(func.ReturnTypeC), out string returnType))
                {
                    func.ReturnType = returnType;
                }
                else
                {
                    func.ReturnType = func.ReturnTypeC;
                }

                if (func.ParamatersC != null)
                {
                    func.Paramaters = new();
                    foreach (KeyValuePair<string, string> kvp in func.ParamatersC)
                    {
                        func.Paramaters.Add(kvp.Key, (string)kvp.Value.Clone());
                    }

                    foreach (KeyValuePair<string, string> parameter in func.ParamatersC)
                    {
                        if (CSharpSafeEquivelent.TryGetValue(SantizeTypes(parameter.Value), out string parameterType))
                        {
                            func.Paramaters[parameter.Key] = parameterType;
                        }
                        else
                        {
                            func.Paramaters[parameter.Key] = func.ParamatersC[parameter.Key];
                        }

                    }
                }

                modules[module].Add(func);

                if (module != RaylibModule.Audio && func.Name == lastFunction[(int)module])
                {
                    module++;
                    modules.Add(module, new List<RaylibFunction>());
                }
            }
        }


        foreach (KeyValuePair<RaylibModule, List<RaylibFunction>> module in modules)
        {
            ClassGenerator classGenerator = new(module.Key, module.Value);
            classGenerator.Generate();
            classGenerator.Output();
        }

        while (true)
        { }
    }

    static string SantizeTypes(string type)
    {
        return type
        .Replace("const ", "");
    }

}
