// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Tests.autogen.tests;

using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="Matrix2x2" /> struct.</summary>
public static unsafe partial class Matrix2x2Tests
{
    /// <summary>Validates that the <see cref="Matrix2x2" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Matrix2x2), Marshal.SizeOf<Matrix2x2>());
    }

    /// <summary>Validates that the <see cref="Matrix2x2" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Matrix2x2).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Matrix2x2" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(Matrix2x2));
    }
}
