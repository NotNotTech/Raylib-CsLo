// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> Camera, defines position/orientation in 3d space </summary>
public unsafe partial struct Camera3D
{
    /// <summary> Camera position </summary>
    public Vector3 position;

    /// <summary> Camera target it looks-at </summary>
    public Vector3 target;

    /// <summary> Camera up vector (rotation over its axis) </summary>
    public Vector3 up;

    /// <summary> Camera field-of-view apperture in Y (degrees) in perspective, used as near plane width in orthographic </summary>
    public float fovy;

    /// <summary> Camera projection: CAMERA_PERSPECTIVE or CAMERA_ORTHOGRAPHIC </summary>
    public int projection;

}
