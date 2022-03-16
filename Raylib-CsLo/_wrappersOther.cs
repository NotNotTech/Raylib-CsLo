// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using System.Numerics;

public static unsafe partial class RlGl
{
#pragma warning disable IDE1006
    public static void rlFramebufferAttach(uint fboId, uint texId, rlFramebufferAttachType attachType, rlFramebufferAttachTextureType texType, int mipLevel)
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


public partial struct Rectangle
{
    public Rectangle(float x, float y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }
    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
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

public partial struct Color
{
    public Color(byte r, byte g, byte b, byte a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }
    public Color(int r, int g, int b, int a)
    {
        this.r = (byte)r;
        this.g = (byte)g;
        this.b = (byte)b;
        this.a = (byte)a;
    }

    // Alias for Raylib-Cs
    public static readonly Color LIGHTGRAY = RaylibS.LIGHTGRAY;
    public static readonly Color GRAY = RaylibS.GRAY;
    public static readonly Color DARKGRAY = RaylibS.DARKGRAY;
    public static readonly Color YELLOW = RaylibS.YELLOW;
    public static readonly Color GOLD = RaylibS.GOLD;
    public static readonly Color ORANGE = RaylibS.ORANGE;
    public static readonly Color PINK = RaylibS.PINK;
    public static readonly Color RED = RaylibS.RED;
    public static readonly Color MAROON = RaylibS.MAROON;
    public static readonly Color GREEN = RaylibS.GREEN;
    public static readonly Color LIME = RaylibS.LIME;
    public static readonly Color DARKGREEN = RaylibS.DARKGREEN;
    public static readonly Color SKYBLUE = RaylibS.SKYBLUE;
    public static readonly Color BLUE = RaylibS.BLUE;
    public static readonly Color DARKBLUE = RaylibS.DARKBLUE;
    public static readonly Color PURPLE = RaylibS.PURPLE;
    public static readonly Color VIOLET = RaylibS.VIOLET;
    public static readonly Color DARKPURPLE = RaylibS.DARKPURPLE;
    public static readonly Color BEIGE = RaylibS.BEIGE;
    public static readonly Color BROWN = RaylibS.BROWN;
    public static readonly Color DARKBROWN = RaylibS.DARKBROWN;
    public static readonly Color WHITE = RaylibS.WHITE;
    public static readonly Color BLACK = RaylibS.BLACK;
    public static readonly Color BLANK = RaylibS.BLANK;
    public static readonly Color MAGENTA = RaylibS.MAGENTA;
    public static readonly Color RAYWHITE = RaylibS.RAYWHITE;
}
public partial struct BoundingBox
{
    public BoundingBox(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
}
public unsafe partial struct float3
{
    public static float3 FromVector3(Vector3 vector)
    {
        float3* p_toReturn = (float3*)&vector;
        return *p_toReturn;
    }
}
public unsafe partial struct float16
{
    public static float16 FromMatrix(Matrix4x4 matrix)
    {
        float16* p_toReturn = (float16*)&matrix;
        return *p_toReturn;
    }
}
public partial struct Texture
{
    public PixelFormat Format
    {
        get
        {
            return (PixelFormat)format;
        }

        set
        {
            format = (int)value;
        }
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

public partial class Easings
{
    public static float EaseElasticInOut(float t, float b, float c, float d)
    {
        if (t == 0.0f)
        {
            return b;
        }

        if ((t /= d / 2.0f) == 2.0f)
        {
            return b + c;
        }

        float p = d * (0.3f * 1.5f);
        float a = c;
        float s = p / 4.0f;

        if (t < 1.0f)
        {
            float postFix = a * MathF.Pow(2.0f, 10.0f * (t -= 1.0f));

            return (-0.5f * (postFix * MathF.Sin(((t * d) - s) * (2.0f * 3.14159265358979323846f) / p))) + b;
        }
        else //RAYLIB-CSLO: bugfix in codegen, add else
        {

            float postFix = a * MathF.Pow(2.0f, -10.0f * (t -= 1.0f));

            return (postFix * MathF.Sin(((t * d) - s) * (2.0f * 3.14159265358979323846f) / p) * 0.5f) + c + b;
        }
    }
}
