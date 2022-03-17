// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary>  </summary>
public unsafe partial struct rlglData
{
    /// <summary> Current render batch </summary>
    public rlRenderBatch * currentBatch;

    /// <summary> Default internal render batch </summary>
    public rlRenderBatch defaultBatch;

    /// <summary> Current active render batch vertex counter (generic, used for all batches) </summary>
    public struct { vertexCounter;

    /// <summary> Current active render batch vertex counter (generic, used for all batches) </summary>
    public int vertexCounter;

    /// <summary> Current active texture coordinate (added on glVertex*()) </summary>
    public float texcoordx, texcoordy;

    /// <summary> Current active normal (added on glVertex*()) </summary>
    public float normalx, normaly, normalz;

    /// <summary> Current active color (added on glVertex*()) </summary>
    public byte colorr, colorg, colorb, colora;

    /// <summary> Current matrix mode </summary>
    public int currentMatrixMode;

    /// <summary> Current matrix pointer </summary>
    public Matrix * currentMatrix;

    /// <summary> Default modelview matrix </summary>
    public Matrix4x4 modelview;

    /// <summary> Default projection matrix </summary>
    public Matrix4x4 projection;

    /// <summary> Transform matrix to be used with rlTranslate, rlRotate, rlScale </summary>
    public Matrix4x4 transform;

    /// <summary> Require transform matrix application to current draw-call vertex (if required) </summary>
    public bool transformRequired;

    /// <summary> Matrix stack for push/pop </summary>
    public Matrix4x4 stack[RL_MAX_MATRIX_STACK_SIZE];

    /// <summary> Matrix stack counter </summary>
    public int stackCounter;

    /// <summary> Default texture used on shapes/poly drawing (required by shader) </summary>
    public uint defaultTextureId;

    /// <summary> Active texture ids to be enabled on batch drawing (0 active by default) </summary>
    public uint activeTextureId[RL_DEFAULT_BATCH_MAX_TEXTURE_UNITS];

    /// <summary> Default vertex shader id (used by default shader program) </summary>
    public uint defaultVShaderId;

    /// <summary> Default fragment shader id (used by default shader program) </summary>
    public uint defaultFShaderId;

    /// <summary> Default shader program id, supports vertex color and diffuse texture </summary>
    public uint defaultShaderId;

    /// <summary> Default shader locations pointer to be used on rendering </summary>
    public int * defaultShaderLocs;

    /// <summary> Current shader id to be used on rendering (by default, defaultShaderId) </summary>
    public uint currentShaderId;

    /// <summary> Current shader locations pointer to be used on rendering (by default, defaultShaderLocs) </summary>
    public int * currentShaderLocs;

    /// <summary> Stereo rendering flag </summary>
    public bool stereoRender;

    /// <summary> VR stereo rendering eyes projection matrices </summary>
    public Matrix4x4 projectionStereo[2];

    /// <summary> VR stereo rendering eyes view offset matrices </summary>
    public Matrix4x4 viewOffsetStereo[2];

    /// <summary> Blending mode active </summary>
    public int currentBlendMode;

    /// <summary> Blending source factor </summary>
    public int glBlendSrcFactor;

    /// <summary> Blending destination factor </summary>
    public int glBlendDstFactor;

    /// <summary> Blending equation </summary>
    public int glBlendEquation;

    /// <summary> Default framebuffer width </summary>
    public int framebufferWidth;

    /// <summary> Default framebuffer height </summary>
    public int framebufferHeight;

}
