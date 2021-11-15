//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct AudioStream
    {
        public rAudioBuffer* buffer;

        [NativeTypeName("unsigned int")]
        public uint sampleRate;

        [NativeTypeName("unsigned int")]
        public uint sampleSize;

        [NativeTypeName("unsigned int")]
        public uint channels;
    }
}
