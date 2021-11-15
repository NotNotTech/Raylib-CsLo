//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;

namespace Raylib_CsLo
{
    public unsafe partial struct Music
    {
        public AudioStream stream;

        [NativeTypeName("unsigned int")]
        public uint frameCount;

        public Boolean looping;

        public int ctxType;

        public void* ctxData;
    }
}
