// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class RlGl
{
    // GUARD RlglH 

    public const string RlglVersion = "4.0";

    // UNKNOWN Rlapi __declspec(dllexport)

    // UNKNOWN Tracelog(level, ...) (void)0

    // MACRO Tracelogd(...) (void)0

    // MACRO RlMalloc(sz) malloc(sz)

    // MACRO RlCalloc(n,sz) calloc(n,sz)

    // MACRO RlRealloc(n,sz) realloc(n,sz)

    // MACRO RlFree(p) free(p)

    // GUARD GraphicsApiOpengl33 

    // GUARD RlglRenderTexturesHint 

    public const int RlDefaultBatchBufferElements = 8192;

    /// <summary> Default number of batch buffers (multi-buffering) </summary>
    public const int RlDefaultBatchBuffers = 1;

    /// <summary> Default number of batch draw calls (by state changes: mode, texture) </summary>
    public const int RlDefaultBatchDrawcalls = 256;

    /// <summary> Maximum number of textures units that can be activated on batch drawing (SetShaderValueTexture()) </summary>
    public const int RlDefaultBatchMaxTextureUnits = 4;

    /// <summary> Maximum size of Matrix stack </summary>
    public const int RlMaxMatrixStackSize = 32;

    /// <summary> Maximum number of shader locations supported </summary>
    public const int RlMaxShaderLocations = 32;

    /// <summary> Default near cull distance </summary>
    public const double RlCullDistanceNear = 0.01;

    /// <summary> Default far cull distance </summary>
    public const double RlCullDistanceFar = 1000.0;

    /// <summary> GL_TEXTURE_WRAP_S </summary>
    public const int RlTextureWrapS = 10242;

    /// <summary> GL_TEXTURE_WRAP_T </summary>
    public const int RlTextureWrapT = 10243;

    /// <summary> GL_TEXTURE_MAG_FILTER </summary>
    public const int RlTextureMagFilter = 10240;

    /// <summary> GL_TEXTURE_MIN_FILTER </summary>
    public const int RlTextureMinFilter = 10241;

    /// <summary> GL_NEAREST </summary>
    public const int RlTextureFilterNearest = 9728;

    /// <summary> GL_LINEAR </summary>
    public const int RlTextureFilterLinear = 9729;

    /// <summary> GL_NEAREST_MIPMAP_NEAREST </summary>
    public const int RlTextureFilterMipNearest = 9984;

    /// <summary> GL_NEAREST_MIPMAP_LINEAR </summary>
    public const int RlTextureFilterNearestMipLinear = 9986;

    /// <summary> GL_LINEAR_MIPMAP_NEAREST </summary>
    public const int RlTextureFilterLinearMipNearest = 9985;

    /// <summary> GL_LINEAR_MIPMAP_LINEAR </summary>
    public const int RlTextureFilterMipLinear = 9987;

    /// <summary> Anisotropic filter (custom identifier) </summary>
    public const int RlTextureFilterAnisotropic = 12288;

    /// <summary> GL_REPEAT </summary>
    public const int RlTextureWrapRepeat = 10497;

    /// <summary> GL_CLAMP_TO_EDGE </summary>
    public const int RlTextureWrapClamp = 33071;

    /// <summary> GL_MIRRORED_REPEAT </summary>
    public const int RlTextureWrapMirrorRepeat = 33648;

    /// <summary> GL_MIRROR_CLAMP_EXT </summary>
    public const int RlTextureWrapMirrorClamp = 34626;

    /// <summary> GL_MODELVIEW </summary>
    public const int RlModelview = 5888;

    /// <summary> GL_PROJECTION </summary>
    public const int RlProjection = 5889;

    /// <summary> GL_TEXTURE </summary>
    public const int RlTexture = 5890;

    /// <summary> GL_LINES </summary>
    public const int RlLines = 1;

    /// <summary> GL_TRIANGLES </summary>
    public const int RlTriangles = 4;

    /// <summary> GL_QUADS </summary>
    public const int RlQuads = 7;

    /// <summary> GL_UNSIGNED_BYTE </summary>
    public const int RlUnsignedByte = 5121;

    /// <summary> GL_FLOAT </summary>
    public const int RlFloat = 5126;

    /// <summary> GL_STREAM_DRAW </summary>
    public const int RlStreamDraw = 35040;

    /// <summary> GL_STREAM_READ </summary>
    public const int RlStreamRead = 35041;

    /// <summary> GL_STREAM_COPY </summary>
    public const int RlStreamCopy = 35042;

    /// <summary> GL_STATIC_DRAW </summary>
    public const int RlStaticDraw = 35044;

    /// <summary> GL_STATIC_READ </summary>
    public const int RlStaticRead = 35045;

    /// <summary> GL_STATIC_COPY </summary>
    public const int RlStaticCopy = 35046;

    /// <summary> GL_DYNAMIC_DRAW </summary>
    public const int RlDynamicDraw = 35048;

    /// <summary> GL_DYNAMIC_READ </summary>
    public const int RlDynamicRead = 35049;

    /// <summary> GL_DYNAMIC_COPY </summary>
    public const int RlDynamicCopy = 35050;

    /// <summary> GL_FRAGMENT_SHADER </summary>
    public const int RlFragmentShader = 35632;

    /// <summary> GL_VERTEX_SHADER </summary>
    public const int RlVertexShader = 35633;

    /// <summary> GL_COMPUTE_SHADER </summary>
    public const int RlComputeShader = 37305;

    // GUARD RlMatrixType 

    // UNKNOWN RlShaderLocMapDiffuse RL_SHADER_LOC_MAP_ALBEDO

    // UNKNOWN RlShaderLocMapSpecular RL_SHADER_LOC_MAP_METALNESS

    // UNKNOWN Apientry __stdcall

    // UNKNOWN Wingdiapi __declspec(dllimport)

    // UNKNOWN GladMalloc RL_MALLOC

    // UNKNOWN GladFree RL_FREE

    // GUARD GladGlImplementation 

    // GUARD GlGlextPrototypes 

    public const float Pi = 3.14159265358979323846f;

    // UNKNOWN Deg2rad (PI/180.0f)

    // UNKNOWN Rad2deg (180.0f/PI)

    public const int GlShadingLanguageVersion = 35724;

    public const int GlCompressedRgbS3tcDxt1Ext = 33776;

    public const int GlCompressedRgbaS3tcDxt1Ext = 33777;

    public const int GlCompressedRgbaS3tcDxt3Ext = 33778;

    public const int GlCompressedRgbaS3tcDxt5Ext = 33779;

    public const int GlEtc1Rgb8Oes = 36196;

    public const int GlCompressedRgb8Etc2 = 37492;

    public const int GlCompressedRgba8Etc2Eac = 37496;

    public const int GlCompressedRgbPvrtc4bppv1Img = 35840;

    public const int GlCompressedRgbaPvrtc4bppv1Img = 35842;

    public const int GlCompressedRgbaAstc4x4Khr = 37808;

    public const int GlCompressedRgbaAstc8x8Khr = 37815;

    public const int GlMaxTextureMaxAnisotropyExt = 34047;

    public const int GlTextureMaxAnisotropyExt = 34046;

    public const int GlUnsignedShort565 = 33635;

    public const int GlUnsignedShort5551 = 32820;

    public const int GlUnsignedShort4444 = 32819;

    public const int GlLuminance = 6409;

    public const int GlLuminanceAlpha = 6410;

    // UNKNOWN glcleardepth glClearDepthf

    // UNKNOWN GlReadFramebuffer GL_FRAMEBUFFER

    // UNKNOWN GlDrawFramebuffer GL_FRAMEBUFFER

    /// <summary> Binded by default to shader location: 0 </summary>
    public const string RlDefaultShaderAttribNamePosition = "vertexPosition";

    /// <summary> Binded by default to shader location: 1 </summary>
    public const string RlDefaultShaderAttribNameTexcoord = "vertexTexCoord";

    /// <summary> Binded by default to shader location: 2 </summary>
    public const string RlDefaultShaderAttribNameNormal = "vertexNormal";

    /// <summary> Binded by default to shader location: 3 </summary>
    public const string RlDefaultShaderAttribNameColor = "vertexColor";

    /// <summary> Binded by default to shader location: 4 </summary>
    public const string RlDefaultShaderAttribNameTangent = "vertexTangent";

    /// <summary> Binded by default to shader location: 5 </summary>
    public const string RlDefaultShaderAttribNameTexcoord2 = "vertexTexCoord2";

    /// <summary> model-view-projection matrix </summary>
    public const string RlDefaultShaderUniformNameMvp = "mvp";

    /// <summary> view matrix </summary>
    public const string RlDefaultShaderUniformNameView = "matView";

    /// <summary> projection matrix </summary>
    public const string RlDefaultShaderUniformNameProjection = "matProjection";

    /// <summary> model matrix </summary>
    public const string RlDefaultShaderUniformNameModel = "matModel";

    /// <summary> normal matrix (transpose(inverse(matModelView)) </summary>
    public const string RlDefaultShaderUniformNameNormal = "matNormal";

    /// <summary> color diffuse (base tint color, multiplied by texture color) </summary>
    public const string RlDefaultShaderUniformNameColor = "colDiffuse";

    /// <summary> texture0 (texture slot active 0) </summary>
    public const string RlDefaultShaderSampler2dNameTexture0 = "texture0";

    /// <summary> texture1 (texture slot active 1) </summary>
    public const string RlDefaultShaderSampler2dNameTexture1 = "texture1";

    /// <summary> texture2 (texture slot active 2) </summary>
    public const string RlDefaultShaderSampler2dNameTexture2 = "texture2";

    // MACRO Min(a,b) (((a)<(b))?(a):(b))

    // MACRO Max(a,b) (((a)>(b))?(a):(b))

}

#pragma warning restore
