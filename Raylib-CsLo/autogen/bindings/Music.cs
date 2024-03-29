//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using Raylib_CsLo.InternalHelpers;

namespace Raylib_CsLo
{
    public unsafe partial struct Music
    {
        public AudioStream stream;

        [NativeTypeName("unsigned int")]
        public uint frameCount;

        public Bool looping;

        public int ctxType;

        public void* ctxData;
    }
}
