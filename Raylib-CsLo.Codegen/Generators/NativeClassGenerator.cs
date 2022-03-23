// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class NativeClassGenerator : BaseGenerator
{
    List<RaylibFunction> functions;
    readonly JsonDocument document;
    string fileName;

    public NativeClassGenerator(JsonDocument document, string fileName)
    {
        this.document = document;
        this.fileName = fileName;
        Debug = false;

        Parse();
    }

    public void Generate()
    {
        Line(Settings.CodeHeader);
        Blank();

        Line($"#pragma warning disable");
        Blank();

        Line($"namespace {Settings.NamespaceName};");

        Blank();

        Line($"public unsafe partial class {fileName}");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                GenFunction(func);
            }
        }
        EndBlock();
        Blank();
        Line($"#pragma warning restore");

        string file = Settings.OutputFolder + fileName + "/" + fileName + ".cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());
    }

    void GenFunction(RaylibFunction func)
    {
        DocumentationBlock(func.Description);

        string importname = fileName.ToLowerInvariant();

        if (importname != "raygui" || importname != "physac")
        {
            importname = "raylib";
        }

        Line($"[DllImport(\"{importname}\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]");

        string returnType = GenReturnType(func);
        string parameters = GenParameterDefinitions(func);
        Line($"public static extern {returnType} {func.Name}({parameters});");
        Blank();
    }

    static string GenReturnType(RaylibFunction func)
    {
        return Converter.FromCToUnsafeCs(func.Return);
    }

    string GenParameterDefinitions(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                if (parameter.Type == "params object[]")
                {
                    parameters = parameters.Remove(parameters.LastIndexOf(","), 2);
                    continue;
                }

                DebugLine(parameter.Type + " => " + Converter.FromCToUnsafeCs(parameter.Type));
                string type = Converter.FromCToUnsafeCs(parameter.Type);
                string name = parameter.Name;

                if (parameter.Type == "...")
                {
                    name = "";
                }

                parameters += $"{type} {name}";

                if (index < func.Parameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    void Parse()
    {
        functions = new();

        foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
        {
            RaylibFunction func = new();
            func.Name = element.GetProperty("name").ToString();
            func.Description = element.GetProperty("description").ToString();
            func.Return = element.GetProperty("returnType").ToString().Replace(" *", "*");

            List<RaylibParam> parameters = null;

            if (element.TryGetProperty("params", out JsonElement val))
            {
                parameters = val.Deserialize<List<RaylibParam>>();
            }

            // Skip auto gening these functions be sure to add them manually
            if (Settings.FunctionsToHandleManually.Contains(func.Name))
            {
                func.Manual = true;
            }

            bool isReturnSame = Converter.FromCToUnsafeCs(func.Return).Equals(Converter.FromCToSafeCs(func.Return), System.StringComparison.Ordinal);
            bool isParamsSame = true;
            if (parameters != null)
            {
                func.Parameters = new();

                foreach (RaylibParam param in parameters)
                {
                    string type = param.Type.Replace(" *", "*");

                    if (Converter.FromCToUnsafeCs(func.Return) != Converter.FromCToSafeCs(func.Return))
                    {
                        isParamsSame = false;
                    }

                    // Handle C# keyword named variables
                    if (param.Name == "checked")
                    {
                        param.Name = "@checked";
                    }
                    else if (param.Name == "readonly")
                    {
                        param.Name = "@readonly";
                    }

                    func.Parameters.Add(new RaylibParameter(param.Name, type));
                }
            }

            if (isReturnSame && isParamsSame)
            {
                func.SameTypes = true;
            }

            functions.Add(func);
        }
    }
}
