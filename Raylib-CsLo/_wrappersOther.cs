// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using System.Numerics;

public static unsafe partial class RlGl
{
#pragma warning disable IDE1006
    public static void rlFramebufferAttach(uint fboId, uint texId, RlFramebufferAttachType attachType, RlFramebufferAttachTextureType texType, int mipLevel)
    {
        rlFramebufferAttach(fboId, texId, (int)attachType, (int)texType, mipLevel);
    }

    public static uint rlLoadTextureCubemap(void* data, int size, PixelFormat format)
    {
        return rlLoadTextureCubemap(data, size, (int)format);
    }

    public static unsafe void rlMultMatrixf(Matrix4x4 matrix)
    {
        rlMultMatrixf((float*)&matrix);
    }
#pragma warning restore IDE1006
}

public partial struct Ray
{
    public Ray(Vector3 position, Vector3 direction)
    {
        this.position = position;
        this.direction = direction;
    }
}


public partial struct Camera3D
{
    public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy, CameraProjection projection)
    {
        this.position = position;
        this.target = target;
        this.up = up;
        this.fovy = fovy;
        this.projection = (int)projection;

    }

    public CameraProjection Projection
    {
        get
        {
            return (CameraProjection)projection;
        }

        set
        {
            projection = (int)value;
        }
    }

}
public partial struct BoundingBox
{
    public BoundingBox(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
}
public unsafe partial struct Float3
{
    public static Float3 FromVector3(Vector3 vector)
    {
        Float3* p_toReturn = (Float3*)&vector;
        return *p_toReturn;
    }
}
public unsafe partial struct Float16
{
    public static Float16 FromMatrix(Matrix4x4 matrix)
    {
        Float16* p_toReturn = (Float16*)&matrix;
        return *p_toReturn;
    }
}
public partial struct NPatchInfo
{

    public NPatchInfo(Rectangle source, int left, int top, int right, int bottom, NPatchLayout layout)
    {
        this.source = source;
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
        this.layout = (int)layout;
    }
}
