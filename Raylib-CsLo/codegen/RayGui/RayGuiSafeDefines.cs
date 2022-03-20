// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class RayGuiS
{
    // GUARD RayguiH 

    public const string RayguiVersion = "3.0";

    // UNKNOWN Rayguiapi __declspec(dllexport)

    // MACRO RayguiMalloc(sz) malloc(sz)

    // MACRO RayguiCalloc(n,sz) calloc(n,sz)

    // MACRO RayguiFree(p) free(p)

    // UNKNOWN Tracelog(level, ...) (void)0

    // MACRO RayguiCliteral(name) name

    // GUARD RiconsImplementation 

    /// <summary> Size of icons (squared) </summary>
    public const int RiconSize = 16;

    /// <summary> Maximum number of icons </summary>
    public const int RiconMaxIcons = 256;

    /// <summary> Maximum length of icon name id </summary>
    public const int RiconMaxNameLength = 32;

    // UNKNOWN RiconDataElements (RICON_SIZE*RICON_SIZE/32)

    /// <summary> Maximum number of standard controls </summary>
    public const int RayguiMaxControls = 16;

    /// <summary> Maximum number of standard properties </summary>
    public const int RayguiMaxPropsBase = 16;

    /// <summary> Maximum number of extended properties </summary>
    public const int RayguiMaxPropsExtended = 8;

    public const int MouseLeftButton = 0;

    public const int WindowStatusbarHeight = 22;

    public const int GroupboxLineThick = 1;

    public const int GroupboxTextPadding = 10;

    public const int LineTextPadding = 10;

    public const int PanelBorderWidth = 1;

    public const int TogglegroupMaxElements = 32;

    public const int ValueboxMaxChars = 32;

    public const int ColorbaralphaCheckedSize = 10;

    public const int MessageboxButtonHeight = 24;

    public const int MessageboxButtonPadding = 10;

    public const int TextinputboxButtonHeight = 24;

    public const int TextinputboxButtonPadding = 10;

    public const int TextinputboxHeight = 30;

    public const int TextinputboxMaxTextLength = 256;

    /// <summary> Grid lines alpha amount </summary>
    public const float GridColorAlpha = 0.15f;

    // MACRO BitCheck(a,b) ((a) & (1<<(b)))

    // MACRO BitSet(a,b) ((a) |= (1<<(b)))

    // MACRO BitClear(a,b) ((a) &= ~((1)<<(b)))

    // MACRO TextValignPixelOffset(h) ((int)h%2)

    public const int RiconTextPadding = 4;

    public const int TextsplitMaxTextLength = 1024;

    public const int TextsplitMaxTextElements = 128;

    public const int MaxFormattextLength = 64;

    /// <summary> Size of static buffer: TextSplit() </summary>
    public const int TextsplitMaxTextBufferLength = 1024;

    /// <summary> Size of static pointers array: TextSplit() </summary>
    public const int TextsplitMaxSubstringsCount = 128;

}

#pragma warning restore
