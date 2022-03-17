// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;
public unsafe partial class RlGl
{
    // GUARD RLGL_H 

    public static readonly string RLGL_VERSION = "4.0";

    // UNKNOWN RLAPI __declspec(dllexport)

    // UNKNOWN TRACELOG(level, ...) (void)0

    // MACRO TRACELOGD(...) (void)0

    // MACRO RL_MALLOC(sz) malloc(sz)

    // MACRO RL_CALLOC(n,sz) calloc(n,sz)

    // MACRO RL_REALLOC(n,sz) realloc(n,sz)

    // MACRO RL_FREE(p) free(p)

    // GUARD GRAPHICS_API_OPENGL_33 

    // GUARD RLGL_RENDER_TEXTURES_HINT 

    public static readonly int RL_DEFAULT_BATCH_BUFFER_ELEMENTS = 8192;

    /// <summary> Default number of batch buffers (multi-buffering) </summary>
    public static readonly int RL_DEFAULT_BATCH_BUFFERS = 1;

    /// <summary> Default number of batch draw calls (by state changes: mode, texture) </summary>
    public static readonly int RL_DEFAULT_BATCH_DRAWCALLS = 256;

    /// <summary> Maximum number of textures units that can be activated on batch drawing (SetShaderValueTexture()) </summary>
    public static readonly int RL_DEFAULT_BATCH_MAX_TEXTURE_UNITS = 4;

    /// <summary> Maximum size of Matrix stack </summary>
    public static readonly int RL_MAX_MATRIX_STACK_SIZE = 32;

    /// <summary> Maximum number of shader locations supported </summary>
    public static readonly int RL_MAX_SHADER_LOCATIONS = 32;

    /// <summary> Default near cull distance </summary>
    public static readonly double RL_CULL_DISTANCE_NEAR = 0.01;

    /// <summary> Default far cull distance </summary>
    public static readonly double RL_CULL_DISTANCE_FAR = 1000.0;

    /// <summary> GL_TEXTURE_WRAP_S </summary>
    public static readonly int RL_TEXTURE_WRAP_S = 10242;

    /// <summary> GL_TEXTURE_WRAP_T </summary>
    public static readonly int RL_TEXTURE_WRAP_T = 10243;

    /// <summary> GL_TEXTURE_MAG_FILTER </summary>
    public static readonly int RL_TEXTURE_MAG_FILTER = 10240;

    /// <summary> GL_TEXTURE_MIN_FILTER </summary>
    public static readonly int RL_TEXTURE_MIN_FILTER = 10241;

    /// <summary> GL_NEAREST </summary>
    public static readonly int RL_TEXTURE_FILTER_NEAREST = 9728;

    /// <summary> GL_LINEAR </summary>
    public static readonly int RL_TEXTURE_FILTER_LINEAR = 9729;

    /// <summary> GL_NEAREST_MIPMAP_NEAREST </summary>
    public static readonly int RL_TEXTURE_FILTER_MIP_NEAREST = 9984;

    /// <summary> GL_NEAREST_MIPMAP_LINEAR </summary>
    public static readonly int RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR = 9986;

    /// <summary> GL_LINEAR_MIPMAP_NEAREST </summary>
    public static readonly int RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST = 9985;

    /// <summary> GL_LINEAR_MIPMAP_LINEAR </summary>
    public static readonly int RL_TEXTURE_FILTER_MIP_LINEAR = 9987;

    /// <summary> Anisotropic filter (custom identifier) </summary>
    public static readonly int RL_TEXTURE_FILTER_ANISOTROPIC = 12288;

    /// <summary> GL_REPEAT </summary>
    public static readonly int RL_TEXTURE_WRAP_REPEAT = 10497;

    /// <summary> GL_CLAMP_TO_EDGE </summary>
    public static readonly int RL_TEXTURE_WRAP_CLAMP = 33071;

    /// <summary> GL_MIRRORED_REPEAT </summary>
    public static readonly int RL_TEXTURE_WRAP_MIRROR_REPEAT = 33648;

    /// <summary> GL_MIRROR_CLAMP_EXT </summary>
    public static readonly int RL_TEXTURE_WRAP_MIRROR_CLAMP = 34626;

    /// <summary> GL_MODELVIEW </summary>
    public static readonly int RL_MODELVIEW = 5888;

    /// <summary> GL_PROJECTION </summary>
    public static readonly int RL_PROJECTION = 5889;

    /// <summary> GL_TEXTURE </summary>
    public static readonly int RL_TEXTURE = 5890;

    /// <summary> GL_LINES </summary>
    public static readonly int RL_LINES = 1;

    /// <summary> GL_TRIANGLES </summary>
    public static readonly int RL_TRIANGLES = 4;

    /// <summary> GL_QUADS </summary>
    public static readonly int RL_QUADS = 7;

    /// <summary> GL_UNSIGNED_BYTE </summary>
    public static readonly int RL_UNSIGNED_BYTE = 5121;

    /// <summary> GL_FLOAT </summary>
    public static readonly int RL_FLOAT = 5126;

    /// <summary> GL_STREAM_DRAW </summary>
    public static readonly int RL_STREAM_DRAW = 35040;

    /// <summary> GL_STREAM_READ </summary>
    public static readonly int RL_STREAM_READ = 35041;

    /// <summary> GL_STREAM_COPY </summary>
    public static readonly int RL_STREAM_COPY = 35042;

    /// <summary> GL_STATIC_DRAW </summary>
    public static readonly int RL_STATIC_DRAW = 35044;

    /// <summary> GL_STATIC_READ </summary>
    public static readonly int RL_STATIC_READ = 35045;

    /// <summary> GL_STATIC_COPY </summary>
    public static readonly int RL_STATIC_COPY = 35046;

    /// <summary> GL_DYNAMIC_DRAW </summary>
    public static readonly int RL_DYNAMIC_DRAW = 35048;

    /// <summary> GL_DYNAMIC_READ </summary>
    public static readonly int RL_DYNAMIC_READ = 35049;

    /// <summary> GL_DYNAMIC_COPY </summary>
    public static readonly int RL_DYNAMIC_COPY = 35050;

    /// <summary> GL_FRAGMENT_SHADER </summary>
    public static readonly int RL_FRAGMENT_SHADER = 35632;

    /// <summary> GL_VERTEX_SHADER </summary>
    public static readonly int RL_VERTEX_SHADER = 35633;

    /// <summary> GL_COMPUTE_SHADER </summary>
    public static readonly int RL_COMPUTE_SHADER = 37305;

    // GUARD RL_MATRIX_TYPE 

    // UNKNOWN RL_SHADER_LOC_MAP_DIFFUSE RL_SHADER_LOC_MAP_ALBEDO

    // UNKNOWN RL_SHADER_LOC_MAP_SPECULAR RL_SHADER_LOC_MAP_METALNESS

    // UNKNOWN APIENTRY __stdcall

    // UNKNOWN WINGDIAPI __declspec(dllimport)

    // UNKNOWN GLAD_MALLOC RL_MALLOC

    // UNKNOWN GLAD_FREE RL_FREE

    // GUARD GLAD_GL_IMPLEMENTATION 

    // GUARD GL_GLEXT_PROTOTYPES 

    public static readonly float PI = 3.14159265358979323846f;

    // UNKNOWN DEG2RAD (PI/180.0f)

    // UNKNOWN RAD2DEG (180.0f/PI)

    public static readonly int GL_SHADING_LANGUAGE_VERSION = 35724;

    public static readonly int GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 33776;

    public static readonly int GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 33777;

    public static readonly int GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 33778;

    public static readonly int GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 33779;

    public static readonly int GL_ETC1_RGB8_OES = 36196;

    public static readonly int GL_COMPRESSED_RGB8_ETC2 = 37492;

    public static readonly int GL_COMPRESSED_RGBA8_ETC2_EAC = 37496;

    public static readonly int GL_COMPRESSED_RGB_PVRTC_4BPPV1_IMG = 35840;

    public static readonly int GL_COMPRESSED_RGBA_PVRTC_4BPPV1_IMG = 35842;

    public static readonly int GL_COMPRESSED_RGBA_ASTC_4x4_KHR = 37808;

    public static readonly int GL_COMPRESSED_RGBA_ASTC_8x8_KHR = 37815;

    public static readonly int GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 34047;

    public static readonly int GL_TEXTURE_MAX_ANISOTROPY_EXT = 34046;

    public static readonly int GL_UNSIGNED_SHORT_5_6_5 = 33635;

    public static readonly int GL_UNSIGNED_SHORT_5_5_5_1 = 32820;

    public static readonly int GL_UNSIGNED_SHORT_4_4_4_4 = 32819;

    public static readonly int GL_LUMINANCE = 6409;

    public static readonly int GL_LUMINANCE_ALPHA = 6410;

    // UNKNOWN glClearDepth glClearDepthf

    // UNKNOWN GL_READ_FRAMEBUFFER GL_FRAMEBUFFER

    // UNKNOWN GL_DRAW_FRAMEBUFFER GL_FRAMEBUFFER

    /// <summary> Binded by default to shader location: 0 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_POSITION = "vertexPosition";

    /// <summary> Binded by default to shader location: 1 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_TEXCOORD = "vertexTexCoord";

    /// <summary> Binded by default to shader location: 2 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_NORMAL = "vertexNormal";

    /// <summary> Binded by default to shader location: 3 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_COLOR = "vertexColor";

    /// <summary> Binded by default to shader location: 4 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_TANGENT = "vertexTangent";

    /// <summary> Binded by default to shader location: 5 </summary>
    public static readonly string RL_DEFAULT_SHADER_ATTRIB_NAME_TEXCOORD2 = "vertexTexCoord2";

    /// <summary> model-view-projection matrix </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_MVP = "mvp";

    /// <summary> view matrix </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_VIEW = "matView";

    /// <summary> projection matrix </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_PROJECTION = "matProjection";

    /// <summary> model matrix </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_MODEL = "matModel";

    /// <summary> normal matrix (transpose(inverse(matModelView)) </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_NORMAL = "matNormal";

    /// <summary> color diffuse (base tint color, multiplied by texture color) </summary>
    public static readonly string RL_DEFAULT_SHADER_UNIFORM_NAME_COLOR = "colDiffuse";

    /// <summary> texture0 (texture slot active 0) </summary>
    public static readonly string RL_DEFAULT_SHADER_SAMPLER2D_NAME_TEXTURE0 = "texture0";

    /// <summary> texture1 (texture slot active 1) </summary>
    public static readonly string RL_DEFAULT_SHADER_SAMPLER2D_NAME_TEXTURE1 = "texture1";

    /// <summary> texture2 (texture slot active 2) </summary>
    public static readonly string RL_DEFAULT_SHADER_SAMPLER2D_NAME_TEXTURE2 = "texture2";

    // MACRO MIN(a,b) (((a)<(b))?(a):(b))

    // MACRO MAX(a,b) (((a)>(b))?(a):(b))

}

#pragma warning restore
