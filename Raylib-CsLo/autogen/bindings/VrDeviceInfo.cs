//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
namespace Raylib_CsLo
{
    public unsafe partial struct VrDeviceInfo
    {
        public int hResolution;

        public int vResolution;

        public float hScreenSize;

        public float vScreenSize;

        public float vScreenCenter;

        public float eyeToScreenDistance;

        public float lensSeparationDistance;

        public float interpupillaryDistance;

        [NativeTypeName("float [4]")]
        public fixed float lensDistortionValues[4];

        [NativeTypeName("float [4]")]
        public fixed float chromaAbCorrection[4];
    }
}
