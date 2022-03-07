// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    public static void TraceLog(int logLevel, string text)
    {
        using SpanOwner<sbyte> spanOwner = text.MarshalUtf8();
        Raylib.TraceLog(logLevel, spanOwner.AsPtr());
    }

    public static void TraceLog(TraceLogLevel logLevel, string text, params object[] args)
    {
        text = text.SPrintF(args);
        TraceLog((int)logLevel, text);
    }
}
