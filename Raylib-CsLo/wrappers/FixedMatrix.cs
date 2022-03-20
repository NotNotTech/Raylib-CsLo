// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using System.Runtime.CompilerServices;

public partial struct FixedMatrix4x4
{
    public Matrix4x4 e0;
    public Matrix4x4 e1;

    public ref Matrix4x4 this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref AsSpan()[index];
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<Matrix4x4> AsSpan()
    {
        return MemoryMarshal.CreateSpan(ref e0, 2);
    }
}
