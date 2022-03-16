// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;
public unsafe partial class physac
{
    // GUARD PHYSAC_H 

    // UNKNOWN PHYSACDEF __declspec(dllexport)

    // MACRO PHYSAC_MALLOC(size) malloc(size)

    // UNKNOWN PHYSAC_CALLOC(size, n)      calloc(size, n)

    // MACRO PHYSAC_FREE(ptr) free(ptr)

    /// <summary>
    /// Maximum number of physic bodies supported
    /// </summary>
    public static readonly int PHYSAC_MAX_BODIES = 64;

    /// <summary>
    /// Maximum number of physic bodies interactions (64x64)
    /// </summary>
    public static readonly int PHYSAC_MAX_MANIFOLDS = 4096;

    /// <summary>
    /// Maximum number of vertex for polygons shapes
    /// </summary>
    public static readonly int PHYSAC_MAX_VERTICES = 24;

    /// <summary>
    /// Default number of vertices for circle shapes
    /// </summary>
    public static readonly int PHYSAC_DEFAULT_CIRCLE_VERTICES = 24;

    public static readonly int PHYSAC_COLLISION_ITERATIONS = 100;

    public static readonly float PHYSAC_PENETRATION_ALLOWANCE = 0.05f;

    public static readonly float PHYSAC_PENETRATION_CORRECTION = 0.4f;

    public static readonly float PHYSAC_PI = 3.14159265358979323846f;

    // UNKNOWN PHYSAC_DEG2RAD (PHYSAC_PI/180.0f)

    // MACRO TRACELOG(...) printf(__VA_ARGS__)

    /// <summary>
    /// Required for CLOCK_MONOTONIC if compiled with c99 without gnu ext.
    /// </summary>
    public static readonly long _POSIX_C_SOURCE = 199309;

    // MACRO CLITERAL(type) type

    // MACRO PHYSAC_MIN(a,b) (((a)<(b))?(a):(b))

    // MACRO PHYSAC_MAX(a,b) (((a)>(b))?(a):(b))

    public static readonly float PHYSAC_FLT_MAX = 3.402823466e+38f;

    public static readonly float PHYSAC_EPSILON = 0.000001f;

    // UNKNOWN PHYSAC_K 1.0f/3.0f

    // UNKNOWN PHYSAC_VECTOR_ZERO CLITERAL(Vector2){ 0.0f, 0.0f }

}

#pragma warning restore
