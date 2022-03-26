// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

public unsafe partial class RaylibS
{
    /// <summary> Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure </summary>
    public static int GetCodepoint(char stringChar, out int bytesProcessed)
    {
        sbyte charSbyte = (sbyte)stringChar;
        int byteCount = 0;
        int toReturn = Raylib.GetCodepoint(&charSbyte, &byteCount);
        bytesProcessed = byteCount;
        return toReturn;
    }
}
