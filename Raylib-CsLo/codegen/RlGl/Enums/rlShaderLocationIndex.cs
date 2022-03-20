// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Shader location point type </summary>
public enum RlShaderLocationIndex
{
    /// <summary> Shader location: vertex attribute: position </summary>
    RlShaderLocVertexPosition = 0,
    /// <summary> Shader location: vertex attribute: texcoord01 </summary>
    RlShaderLocVertexTexcoord01 = 1,
    /// <summary> Shader location: vertex attribute: texcoord02 </summary>
    RlShaderLocVertexTexcoord02 = 2,
    /// <summary> Shader location: vertex attribute: normal </summary>
    RlShaderLocVertexNormal = 3,
    /// <summary> Shader location: vertex attribute: tangent </summary>
    RlShaderLocVertexTangent = 4,
    /// <summary> Shader location: vertex attribute: color </summary>
    RlShaderLocVertexColor = 5,
    /// <summary> Shader location: matrix uniform: model-view-projection </summary>
    RlShaderLocMatrixMvp = 6,
    /// <summary> Shader location: matrix uniform: view (camera transform) </summary>
    RlShaderLocMatrixView = 7,
    /// <summary> Shader location: matrix uniform: projection </summary>
    RlShaderLocMatrixProjection = 8,
    /// <summary> Shader location: matrix uniform: model (transform) </summary>
    RlShaderLocMatrixModel = 9,
    /// <summary> Shader location: matrix uniform: normal </summary>
    RlShaderLocMatrixNormal = 10,
    /// <summary> Shader location: vector uniform: view </summary>
    RlShaderLocVectorView = 11,
    /// <summary> Shader location: vector uniform: diffuse color </summary>
    RlShaderLocColorDiffuse = 12,
    /// <summary> Shader location: vector uniform: specular color </summary>
    RlShaderLocColorSpecular = 13,
    /// <summary> Shader location: vector uniform: ambient color </summary>
    RlShaderLocColorAmbient = 14,
    /// <summary> Shader location: sampler2d texture: albedo (same as: RL_SHADER_LOC_MAP_DIFFUSE) </summary>
    RlShaderLocMapAlbedo = 15,
    /// <summary> Shader location: sampler2d texture: metalness (same as: RL_SHADER_LOC_MAP_SPECULAR) </summary>
    RlShaderLocMapMetalness = 16,
    /// <summary> Shader location: sampler2d texture: normal </summary>
    RlShaderLocMapNormal = 17,
    /// <summary> Shader location: sampler2d texture: roughness </summary>
    RlShaderLocMapRoughness = 18,
    /// <summary> Shader location: sampler2d texture: occlusion </summary>
    RlShaderLocMapOcclusion = 19,
    /// <summary> Shader location: sampler2d texture: emission </summary>
    RlShaderLocMapEmission = 20,
    /// <summary> Shader location: sampler2d texture: height </summary>
    RlShaderLocMapHeight = 21,
    /// <summary> Shader location: samplerCube texture: cubemap </summary>
    RlShaderLocMapCubemap = 22,
    /// <summary> Shader location: samplerCube texture: irradiance </summary>
    RlShaderLocMapIrradiance = 23,
    /// <summary> Shader location: samplerCube texture: prefilter </summary>
    RlShaderLocMapPrefilter = 24,
    /// <summary> Shader location: sampler2d texture: brdf </summary>
    RlShaderLocMapBrdf = 25,
}
