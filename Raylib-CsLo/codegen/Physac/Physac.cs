// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class Physac
{
    /// <summary> Initializes physics system </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void InitPhysics();

    /// <summary> Update physics system </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdatePhysics();

    /// <summary> Reset physics system (global variables) </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResetPhysics();

    /// <summary> Close physics system and unload used memory </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClosePhysics();

    /// <summary> Sets physics fixed time step in milliseconds. 1.666666 by default </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetPhysicsTimeStep(double delta);

    /// <summary> Sets physics global gravity force </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetPhysicsGravity(float x, float y);

    /// <summary> Creates a new circle physics body with generic parameters </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern PhysicsBodyData CreatePhysicsBodyCircle(Vector2 pos, float radius, float density);

    /// <summary> Creates a new rectangle physics body with generic parameters </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern PhysicsBodyData CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density);

    /// <summary> Creates a new polygon physics body with generic parameters </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern PhysicsBodyData CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density);

    /// <summary> Destroy a physics body </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DestroyPhysicsBody(PhysicsBodyData body);

    /// <summary> Adds a force to a physics body </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PhysicsAddForce(PhysicsBodyData body, Vector2 force);

    /// <summary> Adds an angular force to a physics body </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PhysicsAddTorque(PhysicsBodyData body, float amount);

    /// <summary> Shatters a polygon shape physics body to little physics bodies with explosion force </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force);

    /// <summary> Sets physics body shape transform based on radians parameter </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetPhysicsBodyRotation(PhysicsBodyData body, float radians);

    /// <summary> Returns a physics body of the bodies pool at a specific index </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern PhysicsBodyData GetPhysicsBody(int index);

    /// <summary> Returns the current amount of created physics bodies </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetPhysicsBodiesCount();

    /// <summary> Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON) </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetPhysicsShapeType(int index);

    /// <summary> Returns the amount of vertices of a physics body shape </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetPhysicsShapeVerticesCount(int index);

    /// <summary> Returns transformed position of a body shape (body position + vertex transformed position) </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex);

}

#pragma warning restore
