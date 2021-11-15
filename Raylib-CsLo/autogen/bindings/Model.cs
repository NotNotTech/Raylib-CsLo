//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Numerics;

namespace Raylib_CsLo
{
    public unsafe partial struct Model
    {
        [NativeTypeName("Matrix")]
        public Matrix4x4 transform;

        public int meshCount;

        public int materialCount;

        public Mesh* meshes;

        public Material* materials;

        public int* meshMaterial;

        public int boneCount;

        public BoneInfo* bones;

        public Transform* bindPose;
    }
}
