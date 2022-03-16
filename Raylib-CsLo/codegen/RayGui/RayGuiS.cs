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

public unsafe partial class RayGuiS
{
    /// <summary>
    /// Enable gui controls (global state)
    /// </summary>
    public static void GuiEnable()
    {
        RayGui.GuiEnable();
    }

    /// <summary>
    /// Disable gui controls (global state)
    /// </summary>
    public static void GuiDisable()
    {
        RayGui.GuiDisable();
    }

    /// <summary>
    /// Lock gui controls (global state)
    /// </summary>
    public static void GuiLock()
    {
        RayGui.GuiLock();
    }

    /// <summary>
    /// Unlock gui controls (global state)
    /// </summary>
    public static void GuiUnlock()
    {
        RayGui.GuiUnlock();
    }

    /// <summary>
    /// Check if gui is locked (global state)
    /// </summary>
    public static bool GuiIsLocked()
    {
        return RayGui.GuiIsLocked();
    }

    /// <summary>
    /// Set gui controls alpha (global state), alpha goes from 0.0f to 1.0f
    /// </summary>
    public static void GuiFade(float alpha)
    {
        RayGui.GuiFade(alpha);
    }

    /// <summary>
    /// Set gui state (global state)
    /// </summary>
    public static void GuiSetState(int state)
    {
        RayGui.GuiSetState(state);
    }

    /// <summary>
    /// Get gui state (global state)
    /// </summary>
    public static int GuiGetState()
    {
        return RayGui.GuiGetState();
    }

    /// <summary>
    /// Set gui custom font (global state)
    /// </summary>
    public static void GuiSetFont(Font font)
    {
        RayGui.GuiSetFont(font);
    }

    /// <summary>
    /// Get gui custom font (global state)
    /// </summary>
    public static Font GuiGetFont()
    {
        return RayGui.GuiGetFont();
    }

    /// <summary>
    /// Set one style property
    /// </summary>
    public static void GuiSetStyle(int control, int property, int value)
    {
        RayGui.GuiSetStyle(control, property, value);
    }

    /// <summary>
    /// Get one style property
    /// </summary>
    public static int GuiGetStyle(int control, int property)
    {
        return RayGui.GuiGetStyle(control, property);
    }

    /// <summary>
    /// Window Box control, shows a window that can be closed
    /// </summary>
    public static bool GuiWindowBox(Rectangle bounds, string title)
    {
        using var title_ = title.MarshalUtf8();
        return RayGui.GuiWindowBox(bounds, title_.AsPtr());
    }

    /// <summary>
    /// Group Box control with text name
    /// </summary>
    public static void GuiGroupBox(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        RayGui.GuiGroupBox(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Line separator control, could contain text
    /// </summary>
    public static void GuiLine(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        RayGui.GuiLine(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Panel control, useful to group controls
    /// </summary>
    public static void GuiPanel(Rectangle bounds)
    {
        RayGui.GuiPanel(bounds);
    }

    /// <summary>
    /// Scroll Panel control
    /// </summary>
    public static Rectangle GuiScrollPanel(Rectangle bounds, Rectangle content, Vector2[] scroll)
    {
        fixed (Vector2* scroll_ = scroll)
        {
            return RayGui.GuiScrollPanel(bounds, content, scroll_);
        }
    }

    /// <summary>
    /// Label control, shows text
    /// </summary>
    public static void GuiLabel(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        RayGui.GuiLabel(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Button control, returns true when clicked
    /// </summary>
    public static bool GuiButton(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiButton(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Label button control, show true when clicked
    /// </summary>
    public static bool GuiLabelButton(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiLabelButton(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Toggle Button control, returns true when active
    /// </summary>
    public static bool GuiToggle(Rectangle bounds, string text, bool active)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiToggle(bounds, text_.AsPtr(), active);
    }

    /// <summary>
    /// Toggle Group control, returns active toggle index
    /// </summary>
    public static int GuiToggleGroup(Rectangle bounds, string text, int active)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiToggleGroup(bounds, text_.AsPtr(), active);
    }

    /// <summary>
    /// Check Box control, returns true when active
    /// </summary>
    public static bool GuiCheckBox(Rectangle bounds, string text, bool @checked)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiCheckBox(bounds, text_.AsPtr(), @checked);
    }

    /// <summary>
    /// Combo Box control, returns selected item index
    /// </summary>
    public static int GuiComboBox(Rectangle bounds, string text, int active)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiComboBox(bounds, text_.AsPtr(), active);
    }

    /// <summary>
    /// Dropdown Box control, returns selected item
    /// </summary>
    public static bool GuiDropdownBox(Rectangle bounds, string text, int* active, bool editMode)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiDropdownBox(bounds, text_.AsPtr(), active, editMode);
    }

    /// <summary>
    /// Spinner control, returns selected value
    /// </summary>
    public static bool GuiSpinner(Rectangle bounds, string text, int* value, int minValue, int maxValue, bool editMode)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiSpinner(bounds, text_.AsPtr(), value, minValue, maxValue, editMode);
    }

    /// <summary>
    /// Value Box control, updates input text with numbers
    /// </summary>
    public static bool GuiValueBox(Rectangle bounds, string text, int* value, int minValue, int maxValue, bool editMode)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiValueBox(bounds, text_.AsPtr(), value, minValue, maxValue, editMode);
    }

    /// <summary>
    /// Text Box control, updates input text
    /// </summary>
    public static bool GuiTextBox(Rectangle bounds, string text, int textSize, bool editMode)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiTextBox(bounds, text_.AsPtr(), textSize, editMode);
    }

    /// <summary>
    /// Text Box control with multiple lines
    /// </summary>
    public static bool GuiTextBoxMulti(Rectangle bounds, string text, int textSize, bool editMode)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiTextBoxMulti(bounds, text_.AsPtr(), textSize, editMode);
    }

    /// <summary>
    /// Slider control, returns selected value
    /// </summary>
    public static float GuiSlider(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue)
    {
        using var textLeft_ = textLeft.MarshalUtf8();
        using var textRight_ = textRight.MarshalUtf8();
        return RayGui.GuiSlider(bounds, textLeft_.AsPtr(), textRight_.AsPtr(), value, minValue, maxValue);
    }

    /// <summary>
    /// Slider Bar control, returns selected value
    /// </summary>
    public static float GuiSliderBar(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue)
    {
        using var textLeft_ = textLeft.MarshalUtf8();
        using var textRight_ = textRight.MarshalUtf8();
        return RayGui.GuiSliderBar(bounds, textLeft_.AsPtr(), textRight_.AsPtr(), value, minValue, maxValue);
    }

    /// <summary>
    /// Progress Bar control, shows current progress value
    /// </summary>
    public static float GuiProgressBar(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue)
    {
        using var textLeft_ = textLeft.MarshalUtf8();
        using var textRight_ = textRight.MarshalUtf8();
        return RayGui.GuiProgressBar(bounds, textLeft_.AsPtr(), textRight_.AsPtr(), value, minValue, maxValue);
    }

    /// <summary>
    /// Status Bar control, shows info text
    /// </summary>
    public static void GuiStatusBar(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        RayGui.GuiStatusBar(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Dummy control for placeholders
    /// </summary>
    public static void GuiDummyRec(Rectangle bounds, string text)
    {
        using var text_ = text.MarshalUtf8();
        RayGui.GuiDummyRec(bounds, text_.AsPtr());
    }

    /// <summary>
    /// Scroll Bar control
    /// </summary>
    public static int GuiScrollBar(Rectangle bounds, int value, int minValue, int maxValue)
    {
        return RayGui.GuiScrollBar(bounds, value, minValue, maxValue);
    }

    /// <summary>
    /// Grid control
    /// </summary>
    public static Vector2 GuiGrid(Rectangle bounds, float spacing, int subdivs)
    {
        return RayGui.GuiGrid(bounds, spacing, subdivs);
    }

    /// <summary>
    /// List View control, returns selected list item index
    /// </summary>
    public static int GuiListView(Rectangle bounds, string text, int* scrollIndex, int active)
    {
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiListView(bounds, text_.AsPtr(), scrollIndex, active);
    }

    /// <summary>
    /// List View with extended parameters
    /// </summary>
    public static int GuiListViewEx(Rectangle bounds, sbyte** text, int count, int* focus, int* scrollIndex, int active)
    {
        return RayGui.GuiListViewEx(bounds, text, count, focus, scrollIndex, active);
    }

    /// <summary>
    /// Message Box control, displays a message
    /// </summary>
    public static int GuiMessageBox(Rectangle bounds, string title, string message, string buttons)
    {
        using var title_ = title.MarshalUtf8();
        using var message_ = message.MarshalUtf8();
        using var buttons_ = buttons.MarshalUtf8();
        return RayGui.GuiMessageBox(bounds, title_.AsPtr(), message_.AsPtr(), buttons_.AsPtr());
    }

    /// <summary>
    /// Text Input Box control, ask for text
    /// </summary>
    public static int GuiTextInputBox(Rectangle bounds, string title, string message, string buttons, string text)
    {
        using var title_ = title.MarshalUtf8();
        using var message_ = message.MarshalUtf8();
        using var buttons_ = buttons.MarshalUtf8();
        using var text_ = text.MarshalUtf8();
        return RayGui.GuiTextInputBox(bounds, title_.AsPtr(), message_.AsPtr(), buttons_.AsPtr(), text_.AsPtr());
    }

    /// <summary>
    /// Color Picker control (multiple color controls)
    /// </summary>
    public static Color GuiColorPicker(Rectangle bounds, Color color)
    {
        return RayGui.GuiColorPicker(bounds, color);
    }

    /// <summary>
    /// Color Panel control
    /// </summary>
    public static Color GuiColorPanel(Rectangle bounds, Color color)
    {
        return RayGui.GuiColorPanel(bounds, color);
    }

    /// <summary>
    /// Color Bar Alpha control
    /// </summary>
    public static float GuiColorBarAlpha(Rectangle bounds, float alpha)
    {
        return RayGui.GuiColorBarAlpha(bounds, alpha);
    }

    /// <summary>
    /// Color Bar Hue control
    /// </summary>
    public static float GuiColorBarHue(Rectangle bounds, float value)
    {
        return RayGui.GuiColorBarHue(bounds, value);
    }

    /// <summary>
    /// Load style file over global style variable (.rgs)
    /// </summary>
    public static void GuiLoadStyle(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        RayGui.GuiLoadStyle(fileName_.AsPtr());
    }

    /// <summary>
    /// Load style default over global style
    /// </summary>
    public static void GuiLoadStyleDefault()
    {
        RayGui.GuiLoadStyleDefault();
    }

    /// <summary>
    /// Load style from file (.rgs)
    /// </summary>
    public static uint* LoadGuiStyle(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return RayGui.LoadGuiStyle(fileName_.AsPtr());
    }

    /// <summary>
    /// Unload style
    /// </summary>
    public static void UnloadGuiStyle(uint* style)
    {
        RayGui.UnloadGuiStyle(style);
    }

    /// <summary>
    /// Get text with icon id prepended (if supported)
    /// </summary>
    public static string GuiIconText(int iconId, string text)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(RayGui.GuiIconText(iconId, text_.AsPtr()));
    }

    /// <summary>
    /// 
    /// </summary>
    public static void GuiDrawIcon(int iconId, int posX, int posY, int pixelSize, Color color)
    {
        RayGui.GuiDrawIcon(iconId, posX, posY, pixelSize, color);
    }

    /// <summary>
    /// Get full icons data pointer
    /// </summary>
    public static uint* GuiGetIcons()
    {
        return RayGui.GuiGetIcons();
    }

    /// <summary>
    /// Get icon bit data
    /// </summary>
    public static uint* GuiGetIconData(int iconId)
    {
        return RayGui.GuiGetIconData(iconId);
    }

    /// <summary>
    /// Set icon bit data
    /// </summary>
    public static void GuiSetIconData(int iconId, uint* data)
    {
        RayGui.GuiSetIconData(iconId, data);
    }

    /// <summary>
    /// Set icon pixel value
    /// </summary>
    public static void GuiSetIconPixel(int iconId, int x, int y)
    {
        RayGui.GuiSetIconPixel(iconId, x, y);
    }

    /// <summary>
    /// Clear icon pixel value
    /// </summary>
    public static void GuiClearIconPixel(int iconId, int x, int y)
    {
        RayGui.GuiClearIconPixel(iconId, x, y);
    }

    /// <summary>
    /// Check icon pixel value
    /// </summary>
    public static bool GuiCheckIconPixel(int iconId, int x, int y)
    {
        return RayGui.GuiCheckIconPixel(iconId, x, y);
    }

}

#pragma warning restore
