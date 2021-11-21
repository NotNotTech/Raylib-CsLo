//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
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
}
