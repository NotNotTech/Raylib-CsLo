//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_CsLo
{
    public static unsafe partial class Physac
    {
        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InitPhysics();

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void UpdatePhysics();

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ResetPhysics();

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ClosePhysics();

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetPhysicsTimeStep(double delta);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetPhysicsGravity(float x, float y);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PhysicsBody")]
        public static extern PhysicsBodyData* CreatePhysicsBodyCircle(Vector2 pos, float radius, float density);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PhysicsBody")]
        public static extern PhysicsBodyData* CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PhysicsBody")]
        public static extern PhysicsBodyData* CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void DestroyPhysicsBody([NativeTypeName("PhysicsBody")] PhysicsBodyData* body);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PhysicsAddForce([NativeTypeName("PhysicsBody")] PhysicsBodyData* body, Vector2 force);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PhysicsAddTorque([NativeTypeName("PhysicsBody")] PhysicsBodyData* body, float amount);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PhysicsShatter([NativeTypeName("PhysicsBody")] PhysicsBodyData* body, Vector2 position, float force);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetPhysicsBodyRotation([NativeTypeName("PhysicsBody")] PhysicsBodyData* body, float radians);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PhysicsBody")]
        public static extern PhysicsBodyData* GetPhysicsBody(int index);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetPhysicsBodiesCount();

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetPhysicsShapeType(int index);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetPhysicsShapeVerticesCount(int index);

        [DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Vector2 GetPhysicsShapeVertex([NativeTypeName("PhysicsBody")] PhysicsBodyData* body, int vertex);

        [NativeTypeName("#define PHYSAC_MAX_BODIES 64")]
        public const int PHYSAC_MAX_BODIES = 64;

        [NativeTypeName("#define PHYSAC_MAX_MANIFOLDS 4096")]
        public const int PHYSAC_MAX_MANIFOLDS = 4096;

        [NativeTypeName("#define PHYSAC_MAX_VERTICES 24")]
        public const int PHYSAC_MAX_VERTICES = 24;

        [NativeTypeName("#define PHYSAC_DEFAULT_CIRCLE_VERTICES 24")]
        public const int PHYSAC_DEFAULT_CIRCLE_VERTICES = 24;

        [NativeTypeName("#define PHYSAC_COLLISION_ITERATIONS 100")]
        public const int PHYSAC_COLLISION_ITERATIONS = 100;

        [NativeTypeName("#define PHYSAC_PENETRATION_ALLOWANCE 0.05f")]
        public const float PHYSAC_PENETRATION_ALLOWANCE = 0.05f;

        [NativeTypeName("#define PHYSAC_PENETRATION_CORRECTION 0.4f")]
        public const float PHYSAC_PENETRATION_CORRECTION = 0.4f;

        [NativeTypeName("#define PHYSAC_PI 3.14159265358979323846f")]
        public const float PHYSAC_PI = 3.14159265358979323846f;

        [NativeTypeName("#define PHYSAC_DEG2RAD (PHYSAC_PI/180.0f)")]
        public const float PHYSAC_DEG2RAD = (3.14159265358979323846f / 180.0f);
    }
}
