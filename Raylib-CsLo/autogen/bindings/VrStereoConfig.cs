//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_CsLo
{
    public unsafe partial struct VrStereoConfig
    {
        [NativeTypeName("Matrix [2]")]
        public _projection_e__FixedBuffer projection;

        [NativeTypeName("Matrix [2]")]
        public _viewOffset_e__FixedBuffer viewOffset;

        [NativeTypeName("float [2]")]
        public fixed float leftLensCenter[2];

        [NativeTypeName("float [2]")]
        public fixed float rightLensCenter[2];

        [NativeTypeName("float [2]")]
        public fixed float leftScreenCenter[2];

        [NativeTypeName("float [2]")]
        public fixed float rightScreenCenter[2];

        [NativeTypeName("float [2]")]
        public fixed float scale[2];

        [NativeTypeName("float [2]")]
        public fixed float scaleIn[2];

        public partial struct _projection_e__FixedBuffer
        {
            public Matrix4x4 e0;
            public Matrix4x4 e1;

            public ref Matrix4x4 this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<Matrix4x4> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }

        public partial struct _viewOffset_e__FixedBuffer
        {
            public Matrix4x4 e0;
            public Matrix4x4 e1;

            public ref Matrix4x4 this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<Matrix4x4> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }
    }
}
