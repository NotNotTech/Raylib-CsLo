// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Dynamic vertex buffers (position + texcoords + colors + indices arrays) </summary>
public unsafe partial struct RlVertexBuffer
{
    /// <summary> Number of elements in the buffer (QUADS) </summary>
    public int elementCount;

    /// <summary> Vertex position (XYZ - 3 components per vertex) (shader-location = 0) </summary>
    public float* vertices;

    /// <summary> Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1) </summary>
    public float* texcoords;

    /// <summary> Vertex colors (RGBA - 4 components per vertex) (shader-location = 3) </summary>
    public byte* colors;

    /// <summary> Vertex indices (in case vertex data comes indexed) (6 indices per quad) </summary>
    public uint* indices;

    /// <summary> OpenGL Vertex Array Object id </summary>
    public uint vaoId;

    /// <summary> OpenGL Vertex Buffer Objects id (4 types of vertex data) </summary>
    public fixed uint vboId[4];

}
