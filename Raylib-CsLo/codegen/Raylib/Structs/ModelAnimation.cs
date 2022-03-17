// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> ModelAnimation </summary>
public unsafe partial struct ModelAnimation
{
    /// <summary> Number of bones </summary>
    public int boneCount;

    /// <summary> Number of animation frames </summary>
    public int frameCount;

    /// <summary> Bones information (skeleton) </summary>
    public BoneInfo * bones;

    /// <summary> Poses array by frame </summary>
    public Transform ** framePoses;

}
