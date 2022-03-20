// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System.Drawing;
using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="Rectangle" /> struct.</summary>
public static unsafe partial class RectangleTests
{
    /// <summary>Validates that the <see cref="Rectangle" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Rectangle), Marshal.SizeOf<Rectangle>());
    }

    /// <summary>Validates that the <see cref="Rectangle" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Rectangle).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Rectangle" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(Rectangle));
    }
}
