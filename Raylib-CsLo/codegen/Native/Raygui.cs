// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

using System.Runtime.InteropServices;
using System.Numerics;

public unsafe partial class Raygui
{
    /// <summary>
    /// Enable gui controls (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiEnable();

    /// <summary>
    /// Disable gui controls (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiDisable();

    /// <summary>
    /// Lock gui controls (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiLock();

    /// <summary>
    /// Unlock gui controls (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiUnlock();

    /// <summary>
    /// Check if gui is locked (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiIsLocked();

    /// <summary>
    /// Set gui controls alpha (global state), alpha goes from 0.0f to 1.0f
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiFade(float alpha);

    /// <summary>
    /// Set gui state (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiSetState(int state);

    /// <summary>
    /// Get gui state (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiGetState();

    /// <summary>
    /// Set gui custom font (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiSetFont(Font font);

    /// <summary>
    /// Get gui custom font (global state)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Font GuiGetFont();

    /// <summary>
    /// Set one style property
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiSetStyle(int control, int property, int value);

    /// <summary>
    /// Get one style property
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiGetStyle(int control, int property);

    /// <summary>
    /// Window Box control, shows a window that can be closed
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiWindowBox(Rectangle bounds, sbyte* title);

    /// <summary>
    /// Group Box control with text name
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiGroupBox(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Line separator control, could contain text
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiLine(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Panel control, useful to group controls
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiPanel(Rectangle bounds);

    /// <summary>
    /// Scroll Panel control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Rectangle GuiScrollPanel(Rectangle bounds, Rectangle content, Vector2* scroll);

    /// <summary>
    /// Label control, shows text
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiLabel(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Button control, returns true when clicked
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiButton(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Label button control, show true when clicked
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiLabelButton(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Toggle Button control, returns true when active
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiToggle(Rectangle bounds, sbyte* text, bool active);

    /// <summary>
    /// Toggle Group control, returns active toggle index
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiToggleGroup(Rectangle bounds, sbyte* text, int active);

    /// <summary>
    /// Check Box control, returns true when active
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiCheckBox(Rectangle bounds, sbyte* text, bool @checked);

    /// <summary>
    /// Combo Box control, returns selected item index
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiComboBox(Rectangle bounds, sbyte* text, int active);

    /// <summary>
    /// Dropdown Box control, returns selected item
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiDropdownBox(Rectangle bounds, sbyte* text, int* active, bool editMode);

    /// <summary>
    /// Spinner control, returns selected value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiSpinner(Rectangle bounds, sbyte* text, int* value, int minValue, int maxValue, bool editMode);

    /// <summary>
    /// Value Box control, updates input text with numbers
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiValueBox(Rectangle bounds, sbyte* text, int* value, int minValue, int maxValue, bool editMode);

    /// <summary>
    /// Text Box control, updates input text
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiTextBox(Rectangle bounds, sbyte* text, int textSize, bool editMode);

    /// <summary>
    /// Text Box control with multiple lines
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiTextBoxMulti(Rectangle bounds, sbyte* text, int textSize, bool editMode);

    /// <summary>
    /// Slider control, returns selected value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float GuiSlider(Rectangle bounds, sbyte* textLeft, sbyte* textRight, float value, float minValue, float maxValue);

    /// <summary>
    /// Slider Bar control, returns selected value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float GuiSliderBar(Rectangle bounds, sbyte* textLeft, sbyte* textRight, float value, float minValue, float maxValue);

    /// <summary>
    /// Progress Bar control, shows current progress value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float GuiProgressBar(Rectangle bounds, sbyte* textLeft, sbyte* textRight, float value, float minValue, float maxValue);

    /// <summary>
    /// Status Bar control, shows info text
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiStatusBar(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Dummy control for placeholders
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiDummyRec(Rectangle bounds, sbyte* text);

    /// <summary>
    /// Scroll Bar control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiScrollBar(Rectangle bounds, int value, int minValue, int maxValue);

    /// <summary>
    /// Grid control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 GuiGrid(Rectangle bounds, float spacing, int subdivs);

    /// <summary>
    /// List View control, returns selected list item index
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiListView(Rectangle bounds, sbyte* text, int* scrollIndex, int active);

    /// <summary>
    /// List View with extended parameters
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiListViewEx(Rectangle bounds, sbyte** text, int count, int* focus, int* scrollIndex, int active);

    /// <summary>
    /// Message Box control, displays a message
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiMessageBox(Rectangle bounds, sbyte* title, sbyte* message, sbyte* buttons);

    /// <summary>
    /// Text Input Box control, ask for text
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GuiTextInputBox(Rectangle bounds, sbyte* title, sbyte* message, sbyte* buttons, sbyte* text);

    /// <summary>
    /// Color Picker control (multiple color controls)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Color GuiColorPicker(Rectangle bounds, Color color);

    /// <summary>
    /// Color Panel control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Color GuiColorPanel(Rectangle bounds, Color color);

    /// <summary>
    /// Color Bar Alpha control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float GuiColorBarAlpha(Rectangle bounds, float alpha);

    /// <summary>
    /// Color Bar Hue control
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float GuiColorBarHue(Rectangle bounds, float value);

    /// <summary>
    /// Load style file over global style variable (.rgs)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiLoadStyle(sbyte* fileName);

    /// <summary>
    /// Load style default over global style
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiLoadStyleDefault();

    /// <summary>
    /// Load style from file (.rgs)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint* LoadGuiStyle(sbyte* fileName);

    /// <summary>
    /// Unload style
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadGuiStyle(uint* style);

    /// <summary>
    /// Get text with icon id prepended (if supported)
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern sbyte* GuiIconText(int iconId, sbyte* text);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiDrawIcon(int iconId, int posX, int posY, int pixelSize, Color color);

    /// <summary>
    /// Get full icons data pointer
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint* GuiGetIcons();

    /// <summary>
    /// Get icon bit data
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint* GuiGetIconData(int iconId);

    /// <summary>
    /// Set icon bit data
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiSetIconData(int iconId, uint* data);

    /// <summary>
    /// Set icon pixel value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiSetIconPixel(int iconId, int x, int y);

    /// <summary>
    /// Clear icon pixel value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GuiClearIconPixel(int iconId, int x, int y);

    /// <summary>
    /// Check icon pixel value
    /// </summary>
    [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool GuiCheckIconPixel(int iconId, int x, int y);

}

#pragma warning restore
