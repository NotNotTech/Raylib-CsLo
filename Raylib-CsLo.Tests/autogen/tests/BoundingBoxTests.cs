//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="BoundingBox" /> struct.</summary>
    public static unsafe partial class BoundingBoxTests
    {
        /// <summary>Validates that the <see cref="BoundingBox" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(BoundingBox), Marshal.SizeOf<BoundingBox>());
        }

        /// <summary>Validates that the <see cref="BoundingBox" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(BoundingBox).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="BoundingBox" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(BoundingBox));
        }
    }
}
