// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class easingsS
{
    /// <summary>
    /// + b); }
    /// </summary>
    public static float EaseLinearNone(float t, float b, float c, float d)
    {
        return easings.EaseLinearNone(t, b, c, d);
    }

    /// <summary>
    /// + b); }
    /// </summary>
    public static float EaseLinearIn(float t, float b, float c, float d)
    {
        return easings.EaseLinearIn(t, b, c, d);
    }

    /// <summary>
    /// + b); }
    /// </summary>
    public static float EaseLinearOut(float t, float b, float c, float d)
    {
        return easings.EaseLinearOut(t, b, c, d);
    }

    /// <summary>
    /// + b); }
    /// </summary>
    public static float EaseLinearInOut(float t, float b, float c, float d)
    {
        return easings.EaseLinearInOut(t, b, c, d);
    }

    /// <summary>
    /// (PI/2.0f)) + c + b); }
    /// </summary>
    public static float EaseSineIn(float t, float b, float c, float d)
    {
        return easings.EaseSineIn(t, b, c, d);
    }

    /// <summary>
    /// (PI/2.0f)) + b); }
    /// </summary>
    public static float EaseSineOut(float t, float b, float c, float d)
    {
        return easings.EaseSineOut(t, b, c, d);
    }

    /// <summary>
    /// 0f*(cosf(PI*t/d) - 1.0f) + b); }
    /// </summary>
    public static float EaseSineInOut(float t, float b, float c, float d)
    {
        return easings.EaseSineInOut(t, b, c, d);
    }

    /// <summary>
    /// d; return (-c*(sqrtf(1.0f - t*t) - 1.0f) + b); }
    /// </summary>
    public static float EaseCircIn(float t, float b, float c, float d)
    {
        return easings.EaseCircIn(t, b, c, d);
    }

    /// <summary>
    /// - 1.0f; return (c*sqrtf(1.0f - t*t) + b); }
    /// </summary>
    public static float EaseCircOut(float t, float b, float c, float d)
    {
        return easings.EaseCircOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseCircInOut(float t, float b, float c, float d)
    {
        return easings.EaseCircInOut(t, b, c, d);
    }

    /// <summary>
    /// d; return (c*t*t*t + b); }
    /// </summary>
    public static float EaseCubicIn(float t, float b, float c, float d)
    {
        return easings.EaseCubicIn(t, b, c, d);
    }

    /// <summary>
    /// - 1.0f; return (c*(t*t*t + 1.0f) + b); }
    /// </summary>
    public static float EaseCubicOut(float t, float b, float c, float d)
    {
        return easings.EaseCubicOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseCubicInOut(float t, float b, float c, float d)
    {
        return easings.EaseCubicInOut(t, b, c, d);
    }

    /// <summary>
    /// d; return (c*t*t + b); }
    /// </summary>
    public static float EaseQuadIn(float t, float b, float c, float d)
    {
        return easings.EaseQuadIn(t, b, c, d);
    }

    /// <summary>
    /// d; return (-c*t*(t - 2.0f) + b); }
    /// </summary>
    public static float EaseQuadOut(float t, float b, float c, float d)
    {
        return easings.EaseQuadOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseQuadInOut(float t, float b, float c, float d)
    {
        return easings.EaseQuadInOut(t, b, c, d);
    }

    /// <summary>
    /// - 1.0f)) + b); }
    /// </summary>
    public static float EaseExpoIn(float t, float b, float c, float d)
    {
        return easings.EaseExpoIn(t, b, c, d);
    }

    /// <summary>
    ///  + 1.0f) + b);    }
    /// </summary>
    public static float EaseExpoOut(float t, float b, float c, float d)
    {
        return easings.EaseExpoOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseExpoInOut(float t, float b, float c, float d)
    {
        return easings.EaseExpoInOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBackIn(float t, float b, float c, float d)
    {
        return easings.EaseBackIn(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBackOut(float t, float b, float c, float d)
    {
        return easings.EaseBackOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBackInOut(float t, float b, float c, float d)
    {
        return easings.EaseBackInOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBounceOut(float t, float b, float c, float d)
    {
        return easings.EaseBounceOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBounceIn(float t, float b, float c, float d)
    {
        return easings.EaseBounceIn(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseBounceInOut(float t, float b, float c, float d)
    {
        return easings.EaseBounceInOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseElasticIn(float t, float b, float c, float d)
    {
        return easings.EaseElasticIn(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseElasticOut(float t, float b, float c, float d)
    {
        return easings.EaseElasticOut(t, b, c, d);
    }

    /// <summary>
    /// 
    /// </summary>
    public static float EaseElasticInOut(float t, float b, float c, float d)
    {
        return easings.EaseElasticInOut(t, b, c, d);
    }

}

#pragma warning restore
