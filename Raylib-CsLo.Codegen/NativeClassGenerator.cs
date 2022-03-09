// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;

public class NativeClassGenerator : ClassGenerator
{
    bool debug;

    List<RaylibFunction> functions;

    const string ClassName = "Raylib";

    public static readonly string[] Usings =
    {
        "System.Runtime.InteropServices",
        "System.Numerics",
    };

    public NativeClassGenerator(List<RaylibFunction> functions)
    {
        this.functions = functions;
    }

    public void Generate()
    {
        Line($"#pragma warning disable");
        Line($"namespace {CodegenSettings.NamespaceName};");

        UsingsList();

        Line($"public unsafe partial class {ClassName}");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                GenFunction(func);
            }
        }
        EndBlock();
        Line($"#pragma warning restore");
    }

    void GenFunction(RaylibFunction func)
    {
        Line("[DllImport(\"raylib\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]");

        string returnType = GenReturnType(func);
        string parameters = GenParameterDefinitions(func);
        Line($"public static extern {returnType} {func.Name}({parameters});");
        Blank();
    }

    static string GenReturnType(RaylibFunction func)
    {
        return func.Return.TypeCs;
        //  switch
        // {
        //     "const char*" => "string",
        //     "char*" => "string",
        //     "char**" => "string[]",
        //     "const char**" => "sbyte**",
        //     "unsigned char*" => "byte*",
        //     "unsigned int*" => "uint*",
        //     "unsigned int" => "uint",
        //     "Matrix" => "Matrix4x4",
        //     "Texture2D" => "Texture",
        //     "RenderTexture2D" => "RenderTexture",
        //     "TextureCubemap" => "Texture",
        //     _ => func.Return.TypeC
        // };
    }

    string GenParameterDefinitions(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                if (parameter.TypeC == "params object[]")
                {
                    parameters = parameters.Remove(parameters.LastIndexOf(","), 2);
                    continue;
                }

                Debug(parameter.TypeC + " => " + parameter.TypeCs);
                string resultC = parameter.TypeC switch
                {
                    // "bool" => "[MarshalAs(UnmanagedType.U1)] bool",

                    "TraceLogCallback" => "delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>",
                    "LoadFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>",
                    "SaveFileDataCallback" => "delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>",
                    "LoadFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
                    "SaveFileTextCallback" => "delegate* unmanaged[Cdecl]<sbyte*, sbyte*>",
                    "const char*" => "sbyte*",
                    "char*" => "sbyte*",
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
                    _ => parameter.TypeCs,
                };

                parameters += $"{resultC} {parameter.Name}";

                if (index < func.Parameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    public void UsingsList()
    {
        Blank();
        foreach (string import in Usings)
        {
            Line("using " + import + ';');
        }
        Blank();
    }

    public void Debug(string v)
    {
        if (debug)
        {
            Line($"/*|  {v}  |*/");
        }
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibNative.cs", fileContents.ToString());
    }
}
