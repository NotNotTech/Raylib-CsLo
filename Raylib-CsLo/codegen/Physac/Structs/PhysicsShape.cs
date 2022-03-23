// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary>  </summary>
public unsafe partial struct PhysicsShape
{
    /// <summary> Shape type (circle or polygon) </summary>
    public PhysicsShape* type;

    /// <summary> Shape physics body data pointer </summary>
    public PhysicsBodyData body;

    /// <summary> Shape vertices data (used for polygon shapes) </summary>
    public PhysicsVertexData vertexData;

    /// <summary> Shape radius (used for circle shapes) </summary>
    public float radius;

    /// <summary> Vertices transform matrix 2x2 </summary>
    public Matrix2x2 transform;

}
