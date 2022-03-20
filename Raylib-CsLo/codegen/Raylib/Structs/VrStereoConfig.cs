// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> VrStereoConfig, VR stereo rendering configuration for simulator </summary>
public unsafe partial struct VrStereoConfig
{
    /// <summary> VR projection matrices (per eye) </summary>
    public FixedMatrix4x4 projection;

    /// <summary> VR view offset matrices (per eye) </summary>
    public FixedMatrix4x4 viewOffset;

    /// <summary> VR left lens center </summary>
    public fixed float leftLensCenter[2];

    /// <summary> VR right lens center </summary>
    public fixed float rightLensCenter[2];

    /// <summary> VR left screen center </summary>
    public fixed float leftScreenCenter[2];

    /// <summary> VR right screen center </summary>
    public fixed float rightScreenCenter[2];

    /// <summary> VR distortion scale </summary>
    public fixed float scale[2];

    /// <summary> VR distortion scale in </summary>
    public fixed float scaleIn[2];

}
