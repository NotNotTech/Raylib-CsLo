//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct PhysicsShape
    {
        public PhysicsShapeType type;

        [NativeTypeName("PhysicsBody")]
        public PhysicsBodyData* body;

        public PhysicsVertexData vertexData;

        public float radius;

        public Matrix2x2 transform;
    }
}
