//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct Mesh
    {
        public int vertexCount;

        public int triangleCount;

        public float* vertices;

        public float* texcoords;

        public float* texcoords2;

        public float* normals;

        public float* tangents;

        [NativeTypeName("unsigned char *")]
        public byte* colors;

        [NativeTypeName("unsigned short *")]
        public ushort* indices;

        public float* animVertices;

        public float* animNormals;

        [NativeTypeName("unsigned char *")]
        public byte* boneIds;

        public float* boneWeights;

        [NativeTypeName("unsigned int")]
        public uint vaoId;

        [NativeTypeName("unsigned int *")]
        public uint* vboId;
    }
}
