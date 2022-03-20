// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="GuiStyleProp" /> struct.</summary>
public static unsafe partial class GuiStylePropTests
{
    /// <summary>Validates that the <see cref="GuiStyleProp" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(GuiStyleProp), Marshal.SizeOf<GuiStyleProp>());
    }

    /// <summary>Validates that the <see cref="GuiStyleProp" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(GuiStyleProp).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="GuiStyleProp" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(8, sizeof(GuiStyleProp));
    }
}
