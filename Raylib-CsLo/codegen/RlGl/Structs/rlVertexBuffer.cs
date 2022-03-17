// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> Dynamic vertex buffers (position + texcoords + colors + indices arrays) </summary>
public unsafe partial struct rlVertexBuffer
{
    /// <summary> Number of elements in the buffer (QUADS) </summary>
    public int elementCount;

    /// <summary> Vertex position (XYZ - 3 components per vertex) (shader-location = 0) </summary>
    public float * vertices;

    /// <summary> Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1) </summary>
    public float * texcoords;

    /// <summary> Vertex colors (RGBA - 4 components per vertex) (shader-location = 3) </summary>
    public unsigned char * colors;

    /// <summary> OpenGL Vertex Array Object id </summary>
    public #if defined(GRAPHICS_API_OPENGL_11) || defined(GRAPHICS_API_OPENunsigned int * vaoId;

    /// <summary> Vertex indices (in case vertex data comes indexed) (6 indices per quad) </summary>
    public unsigned int * indices;

    /// <summary> Dynamic buffer(s) for vertex data </summary>
    public #endif vertexBuffer;

    /// <summary> OpenGL Vertex Buffer Objects id (4 types of vertex data) </summary>
    public #if defined(GRAPHICS_API_OPENGL_ES2) vboId[4];

    /// <summary> Vertex indices (in case vertex data comes indexed) (6 indices per quad) </summary>
    public unsigned short * indices;

    /// <summary> Modelview matrix for this draw -> Using RLGL.modelview by default </summary>
    public #endif modelview;

    /// <summary> OpenGL Vertex Array Object id </summary>
    public uint vaoId;

    /// <summary> OpenGL Vertex Buffer Objects id (4 types of vertex data) </summary>
    public uint vboId[4];

}
