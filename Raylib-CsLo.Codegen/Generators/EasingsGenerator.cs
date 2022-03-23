// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;
using System.Collections.Generic;
using System.IO;

public class EasingsGenerator : BaseGenerator
{
    List<string> headerLines = new();
    readonly string fileName;

    public EasingsGenerator(string fileName)
    {
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

        Line($"public unsafe partial class Easings");
        StartBlock();
        foreach (string line in headerLines)
        {
            Line(line);
        }
        EndBlock();

        Line($"#pragma warning restore");
        Blank();

        string file = Settings.OutputFolder + "Easings/Easings.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());
    }

    public void Parse()
    {
        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("    EASEDEF"))
            {
                AddLine(lines[i]);

                bool annoyingBug = lines[i].Contains("EaseElasticInOut");
                int postFixRenameAnnoyance = 0;

                if (!lines[i].Contains('{') || !lines[i].Contains('}'))
                {
                    while (!lines[i].StartsWith("    }"))
                    {
                        i++;
                        if (lines[i].Contains("postFix") && annoyingBug && postFixRenameAnnoyance < 2)
                        {
                            AddLine(lines[i].Replace("postFix", "postFixNegative"));
                            postFixRenameAnnoyance++;
                        }
                        else
                        {
                            AddLine(lines[i]);
                        }
                    }
                }
                headerLines.Add("");
            }
        }
    }

    void AddLine(string line)
    {
        if (line.StartsWith('#') || line.Length == 0)
        {
            return;
        }

        string l = line.Replace("EASEDEF", "public static");

        l = l.Replace("cosf", "MathF.Cos");
        l = l.Replace("sinf", "MathF.Sin");
        l = l.Replace("sqrtf", "MathF.Sqrt");
        l = l.Replace("powf", "MathF.Pow");
        l = l.Replace("PI", "MathF.PI");

        if (l.StartsWith("    "))
        {
            l = l.Remove(0, 4);
        }
        headerLines.Add(l);
    }
}
