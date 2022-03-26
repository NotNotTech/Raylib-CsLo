// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Microsoft.Toolkit.HighPerformance.Buffers;

public unsafe partial class RaylibS
{
    /// <summary> free animations via UnloadModelAnimation() when done </summary>
    public static ModelAnimation[] LoadModelAnimations(string fileName)
    {
        using SpanOwner<sbyte> soFileName = fileName.MarshalUtf8();
        uint count;
        ModelAnimation* p_animations = Raylib.LoadModelAnimations(soFileName.AsPtr(), &count);
        ModelAnimation[] toReturn = new ModelAnimation[count];
        for (int i = 0; i < count; i++)
        {
            toReturn[i] = p_animations[i];
        }
        //this ptr isn't needed.
        Raylib.MemFree(p_animations);
        return toReturn;
    }
}
