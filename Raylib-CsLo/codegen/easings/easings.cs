// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class Easings
{
    /// <summary> + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseLinearNone(float t, float b, float c, float d);

    /// <summary> + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseLinearIn(float t, float b, float c, float d);

    /// <summary> + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseLinearOut(float t, float b, float c, float d);

    /// <summary> + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseLinearInOut(float t, float b, float c, float d);

    /// <summary> (PI/2.0f)) + c + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseSineIn(float t, float b, float c, float d);

    /// <summary> (PI/2.0f)) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseSineOut(float t, float b, float c, float d);

    /// <summary> 0f*(cosf(PI*t/d) - 1.0f) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseSineInOut(float t, float b, float c, float d);

    /// <summary> d; return (-c*(sqrtf(1.0f - t*t) - 1.0f) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCircIn(float t, float b, float c, float d);

    /// <summary> - 1.0f; return (c*sqrtf(1.0f - t*t) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCircOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCircInOut(float t, float b, float c, float d);

    /// <summary> d; return (c*t*t*t + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCubicIn(float t, float b, float c, float d);

    /// <summary> - 1.0f; return (c*(t*t*t + 1.0f) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCubicOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseCubicInOut(float t, float b, float c, float d);

    /// <summary> d; return (c*t*t + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseQuadIn(float t, float b, float c, float d);

    /// <summary> d; return (-c*t*(t - 2.0f) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseQuadOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseQuadInOut(float t, float b, float c, float d);

    /// <summary> - 1.0f)) + b); } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseExpoIn(float t, float b, float c, float d);

    /// <summary>  + 1.0f) + b);    } </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseExpoOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseExpoInOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBackIn(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBackOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBackInOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBounceOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBounceIn(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseBounceInOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseElasticIn(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseElasticOut(float t, float b, float c, float d);

    /// <summary>  </summary>
    [DllImport("easings", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float EaseElasticInOut(float t, float b, float c, float d);

}

#pragma warning restore
