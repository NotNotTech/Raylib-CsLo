// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.UnitTests;

using System;
using System.Runtime.InteropServices;
using Xunit;

/// <summary>Provides validation of the <see cref="Font" /> struct.</summary>
public static unsafe partial class FontTests
{
    /// <summary>Validates that the <see cref="Font" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Font), Marshal.SizeOf<Font>());
    }

    /// <summary>Validates that the <see cref="Font" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Font).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Font" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(48, sizeof(Font));
        }
        else
        {
            Assert.Equal(40, sizeof(Font));
        }
    }
}
