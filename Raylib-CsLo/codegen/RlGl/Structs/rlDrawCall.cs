// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> of those state-change happens (this is done in core module) </summary>
public unsafe partial struct RlDrawCall
{
    /// <summary> Drawing mode: LINES, TRIANGLES, QUADS </summary>
    public int mode;

    /// <summary> Number of vertex of the draw </summary>
    public int vertexCount;

    /// <summary> Number of vertex required for index alignment (LINES, TRIANGLES) </summary>
    public int vertexAlignment;

    /// <summary> Texture id to be used on the draw -> Use to create new draw call if changes </summary>
    public uint textureId;

}
