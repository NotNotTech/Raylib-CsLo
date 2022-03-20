// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

public unsafe partial struct Color
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

    public Color(float r, float g, float b, float a)
    {
        this.r = (byte)(r * 255);
        this.g = (byte)(g * 255);
        this.b = (byte)(b * 255);
        this.a = (byte)(a * 255);
    }

    public static readonly Color Lightgray = Raylib.Lightgray;
    public static readonly Color Gray = Raylib.Gray;
    public static readonly Color Darkgray = Raylib.Darkgray;
    public static readonly Color Yellow = Raylib.Yellow;
    public static readonly Color Gold = Raylib.Gold;
    public static readonly Color Orange = Raylib.Orange;
    public static readonly Color Pink = Raylib.Pink;
    public static readonly Color Red = Raylib.Red;
    public static readonly Color Maroon = Raylib.Maroon;
    public static readonly Color Green = Raylib.Green;
    public static readonly Color Lime = Raylib.Lime;
    public static readonly Color Darkgreen = Raylib.Darkgreen;
    public static readonly Color Skyblue = Raylib.Skyblue;
    public static readonly Color Blue = Raylib.Blue;
    public static readonly Color Darkblue = Raylib.Darkblue;
    public static readonly Color Purple = Raylib.Purple;
    public static readonly Color Violet = Raylib.Violet;
    public static readonly Color Darkpurple = Raylib.Darkpurple;
    public static readonly Color Beige = Raylib.Beige;
    public static readonly Color Brown = Raylib.Brown;
    public static readonly Color Darkbrown = Raylib.Darkbrown;
    public static readonly Color White = Raylib.White;
    public static readonly Color Black = Raylib.Black;
    public static readonly Color Blank = Raylib.Blank;
    public static readonly Color Magenta = Raylib.Magenta;
    public static readonly Color Raywhite = Raylib.Raywhite;
}
