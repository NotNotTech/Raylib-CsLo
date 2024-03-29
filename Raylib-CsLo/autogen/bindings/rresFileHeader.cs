//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct rresFileHeader
    {
        [NativeTypeName("unsigned char [4]")]
        public fixed byte id[4];

        [NativeTypeName("unsigned short")]
        public ushort version;

        [NativeTypeName("unsigned short")]
        public ushort chunkCount;

        [NativeTypeName("unsigned int")]
        public uint cdOffset;

        [NativeTypeName("unsigned int")]
        public uint reserved;
    }
}
