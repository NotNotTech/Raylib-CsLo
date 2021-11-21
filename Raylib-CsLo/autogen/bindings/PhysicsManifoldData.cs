//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_CsLo
{
    public unsafe partial struct PhysicsManifoldData
    {
        [NativeTypeName("unsigned int")]
        public uint id;

        [NativeTypeName("PhysicsBody")]
        public PhysicsBodyData* bodyA;

        [NativeTypeName("PhysicsBody")]
        public PhysicsBodyData* bodyB;

        public float penetration;

        public Vector2 normal;

        [NativeTypeName("Vector2 [2]")]
        public _contacts_e__FixedBuffer contacts;

        [NativeTypeName("unsigned int")]
        public uint contactsCount;

        public float restitution;

        public float dynamicFriction;

        public float staticFriction;

        public partial struct _contacts_e__FixedBuffer
        {
            public Vector2 e0;
            public Vector2 e1;

            public ref Vector2 this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Span<Vector2> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }
    }
}
