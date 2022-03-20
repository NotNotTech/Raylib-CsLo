// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> RenderTexture, fbo for texture rendering </summary>
public unsafe partial struct RenderTexture
{
    /// <summary> OpenGL framebuffer object id </summary>
    public uint id;

    /// <summary> Color buffer attachment texture </summary>
    public Texture2D texture;

    /// <summary> Depth buffer attachment texture </summary>
    public Texture2D depth;

}
