//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="ModelAnimation" /> struct.</summary>
    public static unsafe partial class ModelAnimationTests
    {
        /// <summary>Validates that the <see cref="ModelAnimation" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(ModelAnimation), Marshal.SizeOf<ModelAnimation>());
        }

        /// <summary>Validates that the <see cref="ModelAnimation" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(ModelAnimation).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="ModelAnimation" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(ModelAnimation));
            }
            else
            {
                Assert.Equal(16, sizeof(ModelAnimation));
            }
        }
    }
}
