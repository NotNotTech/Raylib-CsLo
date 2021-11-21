//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;

namespace Raylib_CsLo
{
    public partial struct PhysicsBodyData
    {
        [NativeTypeName("unsigned int")]
        public uint id;

        public Boolean enabled;

        public Vector2 position;

        public Vector2 velocity;

        public Vector2 force;

        public float angularVelocity;

        public float torque;

        public float orient;

        public float inertia;

        public float inverseInertia;

        public float mass;

        public float inverseMass;

        public float staticFriction;

        public float dynamicFriction;

        public float restitution;

        public Boolean useGravity;

        public Boolean isGrounded;

        public Boolean freezeOrient;

        public PhysicsShape shape;
    }
}
