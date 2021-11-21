//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_CsLo
{
    public partial struct PhysicsVertexData
    {
        [NativeTypeName("unsigned int")]
        public uint vertexCount;

        [NativeTypeName("Vector2 [24]")]
        public _positions_e__FixedBuffer positions;

        [NativeTypeName("Vector2 [24]")]
        public _normals_e__FixedBuffer normals;

        public partial struct _positions_e__FixedBuffer
        {
            public Vector2 e0;
            public Vector2 e1;
            public Vector2 e2;
            public Vector2 e3;
            public Vector2 e4;
            public Vector2 e5;
            public Vector2 e6;
            public Vector2 e7;
            public Vector2 e8;
            public Vector2 e9;
            public Vector2 e10;
            public Vector2 e11;
            public Vector2 e12;
            public Vector2 e13;
            public Vector2 e14;
            public Vector2 e15;
            public Vector2 e16;
            public Vector2 e17;
            public Vector2 e18;
            public Vector2 e19;
            public Vector2 e20;
            public Vector2 e21;
            public Vector2 e22;
            public Vector2 e23;

            public ref Vector2 this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Span<Vector2> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 24);
        }

        public partial struct _normals_e__FixedBuffer
        {
            public Vector2 e0;
            public Vector2 e1;
            public Vector2 e2;
            public Vector2 e3;
            public Vector2 e4;
            public Vector2 e5;
            public Vector2 e6;
            public Vector2 e7;
            public Vector2 e8;
            public Vector2 e9;
            public Vector2 e10;
            public Vector2 e11;
            public Vector2 e12;
            public Vector2 e13;
            public Vector2 e14;
            public Vector2 e15;
            public Vector2 e16;
            public Vector2 e17;
            public Vector2 e18;
            public Vector2 e19;
            public Vector2 e20;
            public Vector2 e21;
            public Vector2 e22;
            public Vector2 e23;

            public ref Vector2 this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Span<Vector2> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 24);
        }
    }
}
