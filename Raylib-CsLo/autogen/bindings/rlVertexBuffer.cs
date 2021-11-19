//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct rlVertexBuffer
    {
        public int elementCount;

        public float* vertices;

        public float* texcoords;

        [NativeTypeName("unsigned char *")]
        public byte* colors;

        [NativeTypeName("unsigned int *")]
        public uint* indices;

        [NativeTypeName("unsigned int")]
        public uint vaoId;

        [NativeTypeName("unsigned int [4]")]
        public fixed uint vboId[4];
    }
}
