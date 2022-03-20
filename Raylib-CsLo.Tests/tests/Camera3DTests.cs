// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="Camera3D" /> struct.</summary>
public static unsafe partial class Camera3DTests
{
    /// <summary>Validates that the <see cref="Camera3D" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Camera3D), Marshal.SizeOf<Camera3D>());
    }

    /// <summary>Validates that the <see cref="Camera3D" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Camera3D).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Camera3D" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(44, sizeof(Camera3D));
    }
}
