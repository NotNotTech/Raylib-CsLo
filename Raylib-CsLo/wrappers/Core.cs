namespace Raylib_CsLo;

using System.Numerics;
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
