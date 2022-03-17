// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> Camera2D, defines position/orientation in 2d space </summary>
public unsafe partial struct Camera2D
{
    /// <summary> Camera offset (displacement from target) </summary>
    public Vector2 offset;

    /// <summary> Camera target (rotation and zoom origin) </summary>
    public Vector2 target;

    /// <summary> Camera rotation in degrees </summary>
    public float rotation;

    /// <summary> Camera zoom (scaling), should be 1.0f by default </summary>
    public float zoom;

}
