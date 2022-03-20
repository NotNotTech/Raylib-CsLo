// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Model, meshes, materials and animation data </summary>
public unsafe partial struct Model
{
    /// <summary> Local transform matrix </summary>
    public Matrix4x4 transform;

    /// <summary> Number of meshes </summary>
    public int meshCount;

    /// <summary> Number of materials </summary>
    public int materialCount;

    /// <summary> Meshes array </summary>
    public Mesh* meshes;

    /// <summary> Materials array </summary>
    public Material* materials;

    /// <summary> Mesh material number </summary>
    public int* meshMaterial;

    /// <summary> Number of bones </summary>
    public int boneCount;

    /// <summary> Bones information (skeleton) </summary>
    public BoneInfo* bones;

    /// <summary> Bones base transformation (pose) </summary>
    public Transform* bindPose;

}
