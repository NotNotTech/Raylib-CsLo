// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> VrDeviceInfo, Head-Mounted-Display device parameters </summary>
public unsafe partial struct VrDeviceInfo
{
    /// <summary> Horizontal resolution in pixels </summary>
    public int hResolution;

    /// <summary> Vertical resolution in pixels </summary>
    public int vResolution;

    /// <summary> Horizontal size in meters </summary>
    public float hScreenSize;

    /// <summary> Vertical size in meters </summary>
    public float vScreenSize;

    /// <summary> Screen center in meters </summary>
    public float vScreenCenter;

    /// <summary> Distance between eye and display in meters </summary>
    public float eyeToScreenDistance;

    /// <summary> Lens separation distance in meters </summary>
    public float lensSeparationDistance;

    /// <summary> IPD (distance between pupils) in meters </summary>
    public float interpupillaryDistance;

    /// <summary> Lens distortion constant parameters </summary>
    public float lensDistortionValues[4];

    /// <summary> Chromatic aberration correction parameters </summary>
    public float chromaAbCorrection[4];

}
