// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Mesh, vertex data and vao/vbo </summary>
public unsafe partial struct Mesh
{
    /// <summary> Number of vertices stored in arrays </summary>
    public int vertexCount;

    /// <summary> Number of triangles stored (indexed or not) </summary>
    public int triangleCount;

    /// <summary> Vertex position (XYZ - 3 components per vertex) (shader-location = 0) </summary>
    public float* vertices;

    /// <summary> Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1) </summary>
    public float* texcoords;

    /// <summary> Vertex second texture coordinates (useful for lightmaps) (shader-location = 5) </summary>
    public float* texcoords2;

    /// <summary> Vertex normals (XYZ - 3 components per vertex) (shader-location = 2) </summary>
    public float* normals;

    /// <summary> Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4) </summary>
    public float* tangents;

    /// <summary> Vertex colors (RGBA - 4 components per vertex) (shader-location = 3) </summary>
    public byte* colors;

    /// <summary> Vertex indices (in case vertex data comes indexed) </summary>
    public ushort* indices;

    /// <summary> Animated vertex positions (after bones transformations) </summary>
    public float* animVertices;

    /// <summary> Animated normals (after bones transformations) </summary>
    public float* animNormals;

    /// <summary> Vertex bone ids, max 255 bone ids, up to 4 bones influence by vertex (skinning) </summary>
    public byte* boneIds;

    /// <summary> Vertex bone weight, up to 4 bones influence by vertex (skinning) </summary>
    public float* boneWeights;

    /// <summary> OpenGL Vertex Array Object id </summary>
    public uint vaoId;

    /// <summary> OpenGL Vertex Buffer Objects id (default vertex data) </summary>
    public uint* vboId;

}
