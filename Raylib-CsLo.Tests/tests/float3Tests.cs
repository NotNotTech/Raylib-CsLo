// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="Float3" /> struct.</summary>
public static unsafe partial class Float3Tests
{
    /// <summary>Validates that the <see cref="Float3" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Float3), Marshal.SizeOf<Float3>());
    }

    /// <summary>Validates that the <see cref="Float3" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Float3).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Float3" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(12, sizeof(Float3));
    }
}
