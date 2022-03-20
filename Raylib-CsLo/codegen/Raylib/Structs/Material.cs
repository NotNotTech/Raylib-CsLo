// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Material, includes shader and maps </summary>
public unsafe partial struct Material
{
    /// <summary> Material shader </summary>
    public Shader shader;

    /// <summary> Material maps array (MAX_MATERIAL_MAPS) </summary>
    public MaterialMap* maps;

    /// <summary> Material generic parameters (if required) </summary>
    public fixed float @params[4];

}
