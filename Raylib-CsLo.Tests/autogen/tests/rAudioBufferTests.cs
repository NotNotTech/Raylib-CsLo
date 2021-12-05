//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="rAudioBuffer" /> struct.</summary>
    public static unsafe partial class rAudioBufferTests
    {
        /// <summary>Validates that the <see cref="rAudioBuffer" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(rAudioBuffer), Marshal.SizeOf<rAudioBuffer>());
        }

        /// <summary>Validates that the <see cref="rAudioBuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(rAudioBuffer).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="rAudioBuffer" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(rAudioBuffer));
        }
    }
}
