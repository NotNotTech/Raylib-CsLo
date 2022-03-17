// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary>  </summary>
public unsafe partial struct PhysicsManifoldData
{
    /// <summary> Unique identifier </summary>
    public uint id;

    /// <summary> Manifold first physics body reference </summary>
    public PhysicsBodyData bodyA;

    /// <summary> Manifold second physics body reference </summary>
    public PhysicsBodyData bodyB;

    /// <summary> Depth of penetration from collision </summary>
    public float penetration;

    /// <summary> Normal direction vector from 'a' to 'b' </summary>
    public Vector2 normal;

    /// <summary> Points of contact during collision </summary>
    public Vector2 contacts[2];

    /// <summary> Current collision number of contacts </summary>
    public uint contactsCount;

    /// <summary> Mixed restitution during collision </summary>
    public float restitution;

    /// <summary> Mixed dynamic friction during collision </summary>
    public float dynamicFriction;

    /// <summary> Mixed static friction during collision </summary>
    public float staticFriction;

}
