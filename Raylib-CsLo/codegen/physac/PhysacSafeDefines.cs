// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class PhysacS
{
    // GUARD PhysacH 

    // UNKNOWN Physacdef __declspec(dllexport)

    // MACRO PhysacMalloc(size) malloc(size)

    // UNKNOWN PhysacCalloc(size, n)      calloc(size, n)

    // MACRO PhysacFree(ptr) free(ptr)

    /// <summary> Maximum number of physic bodies supported </summary>
    public const int PhysacMaxBodies = 64;

    /// <summary> Maximum number of physic bodies interactions (64x64) </summary>
    public const int PhysacMaxManifolds = 4096;

    /// <summary> Maximum number of vertex for polygons shapes </summary>
    public const int PhysacMaxVertices = 24;

    /// <summary> Default number of vertices for circle shapes </summary>
    public const int PhysacDefaultCircleVertices = 24;

    public const int PhysacCollisionIterations = 100;

    public const float PhysacPenetrationAllowance = 0.05f;

    public const float PhysacPenetrationCorrection = 0.4f;

    public const float PhysacPi = 3.14159265358979323846f;

    // UNKNOWN PhysacDeg2rad (PHYSAC_PI/180.0f)

    // MACRO Tracelog(...) printf(__VA_ARGS__)

    /// <summary> Required for CLOCK_MONOTONIC if compiled with c99 without gnu ext. </summary>
    public const long PosixCSource = 199309;

    // MACRO Cliteral(type) type

    // MACRO PhysacMin(a,b) (((a)<(b))?(a):(b))

    // MACRO PhysacMax(a,b) (((a)>(b))?(a):(b))

    public const float PhysacFltMax = 3.402823466e+38f;

    public const float PhysacEpsilon = 0.000001f;

    // UNKNOWN PhysacK 1.0f/3.0f

    // UNKNOWN PhysacVectorZero CLITERAL(Vector2){ 0.0f, 0.0f }

}

#pragma warning restore
