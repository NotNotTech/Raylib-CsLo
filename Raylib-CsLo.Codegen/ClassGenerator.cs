// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Text;

public class ClassGenerator
{
    int indent;
    public StringBuilder fileContents = new();


    public void StartBlock()
    {
        Line("{");
        indent++;
    }

    public void EndBlock()
    {
        indent--;
        Line("}");
    }

    public static string Call(string functionName, string contents)
    {
        return $"{functionName}({contents})";
    }

    public void Blank()
    {
        fileContents.AppendLine();
    }

    public void Line(string v)
    {
        for (int i = 0; i < indent; i++)
        {
            fileContents.Append("    ");
        }
        fileContents.AppendLine(v);
    }
}
