//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="VrStereoConfig" /> struct.</summary>
    public static unsafe partial class VrStereoConfigTests
    {
        /// <summary>Validates that the <see cref="VrStereoConfig" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(VrStereoConfig), Marshal.SizeOf<VrStereoConfig>());
        }

        /// <summary>Validates that the <see cref="VrStereoConfig" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(VrStereoConfig).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="VrStereoConfig" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(304, sizeof(VrStereoConfig));
        }
    }
}
