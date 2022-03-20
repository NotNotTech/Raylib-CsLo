// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System;
using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="PhysicsManifoldData" /> struct.</summary>
public static unsafe partial class PhysicsManifoldDataTests
{
    /// <summary>Validates that the <see cref="PhysicsManifoldData" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(PhysicsManifoldData), Marshal.SizeOf<PhysicsManifoldData>());
    }

    /// <summary>Validates that the <see cref="PhysicsManifoldData" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(PhysicsManifoldData).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="PhysicsManifoldData" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(72, sizeof(PhysicsManifoldData));
        }
        else
        {
            Assert.Equal(56, sizeof(PhysicsManifoldData));
        }
    }
}
