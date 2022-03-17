// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Shader location index </summary>
public enum ShaderLocationIndex
{
    /// <summary> Shader location: vertex attribute: position </summary>
    SHADER_LOC_VERTEX_POSITION = 0,
    /// <summary> Shader location: vertex attribute: texcoord01 </summary>
    SHADER_LOC_VERTEX_TEXCOORD01 = 1,
    /// <summary> Shader location: vertex attribute: texcoord02 </summary>
    SHADER_LOC_VERTEX_TEXCOORD02 = 2,
    /// <summary> Shader location: vertex attribute: normal </summary>
    SHADER_LOC_VERTEX_NORMAL = 3,
    /// <summary> Shader location: vertex attribute: tangent </summary>
    SHADER_LOC_VERTEX_TANGENT = 4,
    /// <summary> Shader location: vertex attribute: color </summary>
    SHADER_LOC_VERTEX_COLOR = 5,
    /// <summary> Shader location: matrix uniform: model-view-projection </summary>
    SHADER_LOC_MATRIX_MVP = 6,
    /// <summary> Shader location: matrix uniform: view (camera transform) </summary>
    SHADER_LOC_MATRIX_VIEW = 7,
    /// <summary> Shader location: matrix uniform: projection </summary>
    SHADER_LOC_MATRIX_PROJECTION = 8,
    /// <summary> Shader location: matrix uniform: model (transform) </summary>
    SHADER_LOC_MATRIX_MODEL = 9,
    /// <summary> Shader location: matrix uniform: normal </summary>
    SHADER_LOC_MATRIX_NORMAL = 10,
    /// <summary> Shader location: vector uniform: view </summary>
    SHADER_LOC_VECTOR_VIEW = 11,
    /// <summary> Shader location: vector uniform: diffuse color </summary>
    SHADER_LOC_COLOR_DIFFUSE = 12,
    /// <summary> Shader location: vector uniform: specular color </summary>
    SHADER_LOC_COLOR_SPECULAR = 13,
    /// <summary> Shader location: vector uniform: ambient color </summary>
    SHADER_LOC_COLOR_AMBIENT = 14,
    /// <summary> Shader location: sampler2d texture: albedo (same as: SHADER_LOC_MAP_DIFFUSE) </summary>
    SHADER_LOC_MAP_ALBEDO = 15,
    /// <summary> Shader location: sampler2d texture: metalness (same as: SHADER_LOC_MAP_SPECULAR) </summary>
    SHADER_LOC_MAP_METALNESS = 16,
    /// <summary> Shader location: sampler2d texture: normal </summary>
    SHADER_LOC_MAP_NORMAL = 17,
    /// <summary> Shader location: sampler2d texture: roughness </summary>
    SHADER_LOC_MAP_ROUGHNESS = 18,
    /// <summary> Shader location: sampler2d texture: occlusion </summary>
    SHADER_LOC_MAP_OCCLUSION = 19,
    /// <summary> Shader location: sampler2d texture: emission </summary>
    SHADER_LOC_MAP_EMISSION = 20,
    /// <summary> Shader location: sampler2d texture: height </summary>
    SHADER_LOC_MAP_HEIGHT = 21,
    /// <summary> Shader location: samplerCube texture: cubemap </summary>
    SHADER_LOC_MAP_CUBEMAP = 22,
    /// <summary> Shader location: samplerCube texture: irradiance </summary>
    SHADER_LOC_MAP_IRRADIANCE = 23,
    /// <summary> Shader location: samplerCube texture: prefilter </summary>
    SHADER_LOC_MAP_PREFILTER = 24,
    /// <summary> Shader location: sampler2d texture: brdf </summary>
    SHADER_LOC_MAP_BRDF = 25,
}
