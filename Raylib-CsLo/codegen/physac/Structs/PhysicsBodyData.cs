// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary>  </summary>
public unsafe partial struct PhysicsBodyData
{
    /// <summary> Unique identifier </summary>
    public uint id;

    /// <summary> Enabled dynamics state (collisions are calculated anyway) </summary>
    public bool enabled;

    /// <summary> Physics body shape pivot </summary>
    public Vector2 position;

    /// <summary> Current linear velocity applied to position </summary>
    public Vector2 velocity;

    /// <summary> Current linear force (reset to 0 every step) </summary>
    public Vector2 force;

    /// <summary> Current angular velocity applied to orient </summary>
    public float angularVelocity;

    /// <summary> Current angular force (reset to 0 every step) </summary>
    public float torque;

    /// <summary> Rotation in radians </summary>
    public float orient;

    /// <summary> Moment of inertia </summary>
    public float inertia;

    /// <summary> Inverse value of inertia </summary>
    public float inverseInertia;

    /// <summary> Physics body mass </summary>
    public float mass;

    /// <summary> Inverse value of mass </summary>
    public float inverseMass;

    /// <summary> Friction when the body has not movement (0 to 1) </summary>
    public float staticFriction;

    /// <summary> Friction when the body has movement (0 to 1) </summary>
    public float dynamicFriction;

    /// <summary> Restitution coefficient of the body (0 to 1) </summary>
    public float restitution;

    /// <summary> Apply gravity force to dynamics </summary>
    public bool useGravity;

    /// <summary> Physics grounded on other body state </summary>
    public bool isGrounded;

    /// <summary> Physics rotation constraint </summary>
    public bool freezeOrient;

    /// <summary> Physics body shape information (type, radius, vertices, transform) </summary>
    public PhysicsShape* shape;

}
