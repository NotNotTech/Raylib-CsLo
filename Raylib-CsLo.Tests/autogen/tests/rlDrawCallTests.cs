//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="rlDrawCall" /> struct.</summary>
    public static unsafe partial class rlDrawCallTests
    {
        /// <summary>Validates that the <see cref="rlDrawCall" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(rlDrawCall), Marshal.SizeOf<rlDrawCall>());
        }

        /// <summary>Validates that the <see cref="rlDrawCall" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(rlDrawCall).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="rlDrawCall" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(rlDrawCall));
        }
    }
}
