// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> rlRenderBatch type </summary>
public unsafe partial struct rlRenderBatch
{
    /// <summary> Number of vertex buffers (multi-buffering support) </summary>
    public int bufferCount;

    /// <summary> Current buffer tracking in case of multi-buffering </summary>
    public int currentBuffer;

    /// <summary> Dynamic buffer(s) for vertex data </summary>
    public rlVertexBuffer * vertexBuffer;

    /// <summary> Draw calls array, depends on textureId </summary>
    public rlDrawCall * draws;

    /// <summary> Draw calls counter </summary>
    public int drawCounter;

    /// <summary> Current depth value for next draw </summary>
    public float currentDepth;

}
