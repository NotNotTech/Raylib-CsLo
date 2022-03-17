// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class PhysacS
{
    /// <summary> Initializes physics system </summary>
    public static void InitPhysics()
    {
        Physac.InitPhysics();
    }

    /// <summary> Update physics system </summary>
    public static void UpdatePhysics()
    {
        Physac.UpdatePhysics();
    }

    /// <summary> Reset physics system (global variables) </summary>
    public static void ResetPhysics()
    {
        Physac.ResetPhysics();
    }

    /// <summary> Close physics system and unload used memory </summary>
    public static void ClosePhysics()
    {
        Physac.ClosePhysics();
    }

    /// <summary> Sets physics fixed time step in milliseconds. 1.666666 by default </summary>
    public static void SetPhysicsTimeStep(double delta)
    {
        Physac.SetPhysicsTimeStep(delta);
    }

    /// <summary> Sets physics global gravity force </summary>
    public static void SetPhysicsGravity(float x, float y)
    {
        Physac.SetPhysicsGravity(x, y);
    }

    /// <summary> Creates a new circle physics body with generic parameters </summary>
    public static PhysicsBodyData CreatePhysicsBodyCircle(Vector2 pos, float radius, float density)
    {
        return Physac.CreatePhysicsBodyCircle(pos, radius, density);
    }

    /// <summary> Creates a new rectangle physics body with generic parameters </summary>
    public static PhysicsBodyData CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density)
    {
        return Physac.CreatePhysicsBodyRectangle(pos, width, height, density);
    }

    /// <summary> Creates a new polygon physics body with generic parameters </summary>
    public static PhysicsBodyData CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density)
    {
        return Physac.CreatePhysicsBodyPolygon(pos, radius, sides, density);
    }

    /// <summary> Destroy a physics body </summary>
    public static void DestroyPhysicsBody(PhysicsBodyData body)
    {
        Physac.DestroyPhysicsBody(body);
    }

    /// <summary> Adds a force to a physics body </summary>
    public static void PhysicsAddForce(PhysicsBodyData body, Vector2 force)
    {
        Physac.PhysicsAddForce(body, force);
    }

    /// <summary> Adds an angular force to a physics body </summary>
    public static void PhysicsAddTorque(PhysicsBodyData body, float amount)
    {
        Physac.PhysicsAddTorque(body, amount);
    }

    /// <summary> Shatters a polygon shape physics body to little physics bodies with explosion force </summary>
    public static void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force)
    {
        Physac.PhysicsShatter(body, position, force);
    }

    /// <summary> Sets physics body shape transform based on radians parameter </summary>
    public static void SetPhysicsBodyRotation(PhysicsBodyData body, float radians)
    {
        Physac.SetPhysicsBodyRotation(body, radians);
    }

    /// <summary> Returns a physics body of the bodies pool at a specific index </summary>
    public static PhysicsBodyData GetPhysicsBody(int index)
    {
        return Physac.GetPhysicsBody(index);
    }

    /// <summary> Returns the current amount of created physics bodies </summary>
    public static int GetPhysicsBodiesCount()
    {
        return Physac.GetPhysicsBodiesCount();
    }

    /// <summary> Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON) </summary>
    public static int GetPhysicsShapeType(int index)
    {
        return Physac.GetPhysicsShapeType(index);
    }

    /// <summary> Returns the amount of vertices of a physics body shape </summary>
    public static int GetPhysicsShapeVerticesCount(int index)
    {
        return Physac.GetPhysicsShapeVerticesCount(index);
    }

    /// <summary> Returns transformed position of a body shape (body position + vertex transformed position) </summary>
    public static Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex)
    {
        return Physac.GetPhysicsShapeVertex(body, vertex);
    }

}

#pragma warning restore
