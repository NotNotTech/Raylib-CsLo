// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> NPatchInfo, n-patch layout info </summary>
public unsafe partial struct NPatchInfo
{
    /// <summary> Texture source rectangle </summary>
    public Rectangle source;

    /// <summary> Left border offset </summary>
    public int left;

    /// <summary> Top border offset </summary>
    public int top;

    /// <summary> Right border offset </summary>
    public int right;

    /// <summary> Bottom border offset </summary>
    public int bottom;

    /// <summary> Layout of the n-patch: 3x3, 1x3 or 3x1 </summary>
    public int layout;

}
