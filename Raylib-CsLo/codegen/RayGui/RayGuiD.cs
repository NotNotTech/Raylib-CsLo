// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;
public unsafe partial class RayGui
{
    // GUARD RAYGUI_H 

    public static readonly string RAYGUI_VERSION = "3.0";

    // UNKNOWN RAYGUIAPI __declspec(dllexport)

    // MACRO RAYGUI_MALLOC(sz) malloc(sz)

    // MACRO RAYGUI_CALLOC(n,sz) calloc(n,sz)

    // MACRO RAYGUI_FREE(p) free(p)

    // UNKNOWN TRACELOG(level, ...) (void)0

    // MACRO RAYGUI_CLITERAL(name) name

    // GUARD RICONS_IMPLEMENTATION 

    /// <summary> Size of icons (squared) </summary>
    public static readonly int RICON_SIZE = 16;

    /// <summary> Maximum number of icons </summary>
    public static readonly int RICON_MAX_ICONS = 256;

    /// <summary> Maximum length of icon name id </summary>
    public static readonly int RICON_MAX_NAME_LENGTH = 32;

    // UNKNOWN RICON_DATA_ELEMENTS (RICON_SIZE*RICON_SIZE/32)

    /// <summary> Maximum number of standard controls </summary>
    public static readonly int RAYGUI_MAX_CONTROLS = 16;

    /// <summary> Maximum number of standard properties </summary>
    public static readonly int RAYGUI_MAX_PROPS_BASE = 16;

    /// <summary> Maximum number of extended properties </summary>
    public static readonly int RAYGUI_MAX_PROPS_EXTENDED = 8;

    public static readonly int KEY_RIGHT = 262;

    public static readonly int KEY_LEFT = 263;

    public static readonly int KEY_DOWN = 264;

    public static readonly int KEY_UP = 265;

    public static readonly int KEY_BACKSPACE = 259;

    public static readonly int KEY_ENTER = 257;

    public static readonly int MOUSE_LEFT_BUTTON = 0;

    public static readonly int WINDOW_STATUSBAR_HEIGHT = 22;

    public static readonly int GROUPBOX_LINE_THICK = 1;

    public static readonly int GROUPBOX_TEXT_PADDING = 10;

    public static readonly int LINE_TEXT_PADDING = 10;

    public static readonly int PANEL_BORDER_WIDTH = 1;

    public static readonly int TOGGLEGROUP_MAX_ELEMENTS = 32;

    public static readonly int VALUEBOX_MAX_CHARS = 32;

    public static readonly int COLORBARALPHA_CHECKED_SIZE = 10;

    public static readonly int MESSAGEBOX_BUTTON_HEIGHT = 24;

    public static readonly int MESSAGEBOX_BUTTON_PADDING = 10;

    public static readonly int TEXTINPUTBOX_BUTTON_HEIGHT = 24;

    public static readonly int TEXTINPUTBOX_BUTTON_PADDING = 10;

    public static readonly int TEXTINPUTBOX_HEIGHT = 30;

    public static readonly int TEXTINPUTBOX_MAX_TEXT_LENGTH = 256;

    /// <summary> Grid lines alpha amount </summary>
    public static readonly float GRID_COLOR_ALPHA = 0.15f;

    // MACRO BIT_CHECK(a,b) ((a) & (1<<(b)))

    // MACRO BIT_SET(a,b) ((a) |= (1<<(b)))

    // MACRO BIT_CLEAR(a,b) ((a) &= ~((1)<<(b)))

    // MACRO TEXT_VALIGN_PIXEL_OFFSET(h) ((int)h%2)

    public static readonly int RICON_TEXT_PADDING = 4;

    public static readonly int TEXTSPLIT_MAX_TEXT_LENGTH = 1024;

    public static readonly int TEXTSPLIT_MAX_TEXT_ELEMENTS = 128;

    public static readonly int MAX_FORMATTEXT_LENGTH = 64;

    /// <summary> Size of static buffer: TextSplit() </summary>
    public static readonly int TEXTSPLIT_MAX_TEXT_BUFFER_LENGTH = 1024;

    /// <summary> Size of static pointers array: TextSplit() </summary>
    public static readonly int TEXTSPLIT_MAX_SUBSTRINGS_COUNT = 128;

}

#pragma warning restore
