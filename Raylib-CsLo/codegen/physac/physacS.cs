// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class physacS
{
    /// <summary>
    /// Initializes physics system
    /// </summary>
    public static void InitPhysics()
    {
        physac.InitPhysics();
    }

    /// <summary>
    /// Update physics system
    /// </summary>
    public static void UpdatePhysics()
    {
        physac.UpdatePhysics();
    }

    /// <summary>
    /// Reset physics system (global variables)
    /// </summary>
    public static void ResetPhysics()
    {
        physac.ResetPhysics();
    }

    /// <summary>
    /// Close physics system and unload used memory
    /// </summary>
    public static void ClosePhysics()
    {
        physac.ClosePhysics();
    }

    /// <summary>
    /// Sets physics fixed time step in milliseconds. 1.666666 by default
    /// </summary>
    public static void SetPhysicsTimeStep(double delta)
    {
        physac.SetPhysicsTimeStep(delta);
    }

    /// <summary>
    /// Sets physics global gravity force
    /// </summary>
    public static void SetPhysicsGravity(float x, float y)
    {
        physac.SetPhysicsGravity(x, y);
    }

    /// <summary>
    /// Creates a new circle physics body with generic parameters
    /// </summary>
    public static PhysicsBodyData CreatePhysicsBodyCircle(Vector2 pos, float radius, float density)
    {
        return physac.CreatePhysicsBodyCircle(pos, radius, density);
    }

    /// <summary>
    /// Creates a new rectangle physics body with generic parameters
    /// </summary>
    public static PhysicsBodyData CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density)
    {
        return physac.CreatePhysicsBodyRectangle(pos, width, height, density);
    }

    /// <summary>
    /// Creates a new polygon physics body with generic parameters
    /// </summary>
    public static PhysicsBodyData CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density)
    {
        return physac.CreatePhysicsBodyPolygon(pos, radius, sides, density);
    }

    /// <summary>
    /// Destroy a physics body
    /// </summary>
    public static void DestroyPhysicsBody(PhysicsBodyData body)
    {
        physac.DestroyPhysicsBody(body);
    }

    /// <summary>
    /// Adds a force to a physics body
    /// </summary>
    public static void PhysicsAddForce(PhysicsBodyData body, Vector2 force)
    {
        physac.PhysicsAddForce(body, force);
    }

    /// <summary>
    /// Adds an angular force to a physics body
    /// </summary>
    public static void PhysicsAddTorque(PhysicsBodyData body, float amount)
    {
        physac.PhysicsAddTorque(body, amount);
    }

    /// <summary>
    /// Shatters a polygon shape physics body to little physics bodies with explosion force
    /// </summary>
    public static void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force)
    {
        physac.PhysicsShatter(body, position, force);
    }

    /// <summary>
    /// Sets physics body shape transform based on radians parameter
    /// </summary>
    public static void SetPhysicsBodyRotation(PhysicsBodyData body, float radians)
    {
        physac.SetPhysicsBodyRotation(body, radians);
    }

    /// <summary>
    /// Returns a physics body of the bodies pool at a specific index
    /// </summary>
    public static PhysicsBodyData GetPhysicsBody(int index)
    {
        return physac.GetPhysicsBody(index);
    }

    /// <summary>
    /// Returns the current amount of created physics bodies
    /// </summary>
    public static int GetPhysicsBodiesCount()
    {
        return physac.GetPhysicsBodiesCount();
    }

    /// <summary>
    /// Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON)
    /// </summary>
    public static int GetPhysicsShapeType(int index)
    {
        return physac.GetPhysicsShapeType(index);
    }

    /// <summary>
    /// Returns the amount of vertices of a physics body shape
    /// </summary>
    public static int GetPhysicsShapeVerticesCount(int index)
    {
        return physac.GetPhysicsShapeVerticesCount(index);
    }

    /// <summary>
    /// Returns transformed position of a body shape (body position + vertex transformed position)
    /// </summary>
    public static Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex)
    {
        return physac.GetPhysicsShapeVertex(body, vertex);
    }

}

#pragma warning restore
