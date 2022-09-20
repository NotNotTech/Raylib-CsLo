//# raylib 4.0 bindings.   MPL 2.0 Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Raylib_CsLo.UnitTests
{
    /// <summary>Provides validation of the <see cref="rresResourceChunk" /> struct.</summary>
    public static unsafe partial class rresResourceChunkTests
    {
        /// <summary>Validates that the <see cref="rresResourceChunk" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(rresResourceChunk), Marshal.SizeOf<rresResourceChunk>());
        }

        /// <summary>Validates that the <see cref="rresResourceChunk" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(rresResourceChunk).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="rresResourceChunk" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(56, sizeof(rresResourceChunk));
            }
            else
            {
                Assert.Equal(44, sizeof(rresResourceChunk));
            }
        }
    }
}
