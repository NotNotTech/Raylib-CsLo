// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Tests.autogen.tests;

using System;
using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="PhysicsBodyData" /> struct.</summary>
public static unsafe partial class PhysicsBodyDataTests
{
    /// <summary>Validates that the <see cref="PhysicsBodyData" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(PhysicsBodyData), Marshal.SizeOf<PhysicsBodyData>());
    }

    /// <summary>Validates that the <see cref="PhysicsBodyData" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(PhysicsBodyData).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="PhysicsBodyData" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(504, sizeof(PhysicsBodyData));
        }
        else
        {
            Assert.Equal(492, sizeof(PhysicsBodyData));
        }
    }
}
