// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]
// [!!] Copyright ©️ Raylib-CsLo and Contributors.
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info.
// [!!] -------------------------------------------------
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo;

using System;
using System.Runtime.InteropServices;

using Raylib_CsLo.InternalHelpers;

public static unsafe partial class RayGui
{




    public static bool GuiWindowBox(Rectangle bounds, string? title)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotitle = title.MarshalUtf8();
        return GuiWindowBox(bounds, sotitle.AsPtr());

    }


    public static void GuiGroupBox(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        GuiGroupBox(bounds, sotext.AsPtr());
    }


    public static void GuiLine(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        GuiLine(bounds, sotext.AsPtr());
    }

    public static void GuiLabel(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        GuiLabel(bounds, sotext.AsPtr());
    }


    public static bool GuiButton(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiButton(bounds, sotext.AsPtr());
    }


    public static bool GuiLabelButton(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiLabelButton(bounds, sotext.AsPtr());
    }


    public static bool GuiToggle(Rectangle bounds, string? text, bool active)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiToggle(bounds, sotext.AsPtr(), active);
    }


    public static int GuiToggleGroup(Rectangle bounds, string? text, int active)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiToggleGroup(bounds, sotext.AsPtr(), active);
    }


    public static bool GuiCheckBox(Rectangle bounds, string? text, bool @checked)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiCheckBox(bounds, sotext.AsPtr(), @checked);
    }


    public static int GuiComboBox(Rectangle bounds, string? text, int active)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiComboBox(bounds, sotext.AsPtr(), active);
    }


    public static bool GuiDropdownBox(Rectangle bounds, string? text, int* active, bool editMode)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiDropdownBox(bounds, sotext.AsPtr(), active, editMode);
    }


    public static bool GuiSpinner(Rectangle bounds, string? text, int* value, int minValue, int maxValue, bool editMode)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiSpinner(bounds, sotext.AsPtr(), value, minValue, maxValue, editMode);
    }


    public static bool GuiValueBox(Rectangle bounds, string? text, int* value, int minValue, int maxValue, bool editMode)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiValueBox(bounds, sotext.AsPtr(), value, minValue, maxValue, editMode);
    }


    public static bool GuiTextBox(Rectangle bounds, string? text, int textSize, bool editMode)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiTextBox(bounds, sotext.AsPtr(), textSize, editMode);
    }


    public static bool GuiTextBoxMulti(Rectangle bounds, string? text, int textSize, bool editMode)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiTextBoxMulti(bounds, sotext.AsPtr(), textSize, editMode);
    }


    public static float GuiSlider(Rectangle bounds, string? textLeft, string? textRight, float value, float minValue, float maxValue)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotextLeft = textLeft.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotextRight = textRight.MarshalUtf8();
        return GuiSlider(bounds, sotextLeft.AsPtr(), sotextRight.AsPtr(), value, minValue, maxValue);
    }

    public static float GuiSliderBar(Rectangle rectangle, string? leftText, string? rightText, float value, float minValue, float maxValue)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soTextLeft = leftText.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soTextRight = rightText.MarshalUtf8();
        return GuiSliderBar(rectangle, soTextLeft.AsPtr(), soTextRight.AsPtr(), value, minValue, maxValue);
    }

    public static float GuiProgressBar(Rectangle bounds, string? textLeft, string? textRight, float value, float minValue, float maxValue)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotextLeft = textLeft.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotextRight = textRight.MarshalUtf8();
        return GuiProgressBar(bounds, sotextLeft.AsPtr(), sotextRight.AsPtr(), value, minValue, maxValue);
    }


    public static void GuiStatusBar(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        GuiStatusBar(bounds, sotext.AsPtr());
    }


    public static void GuiDummyRec(Rectangle bounds, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        GuiDummyRec(bounds, sotext.AsPtr());
    }






    public static int GuiListView(Rectangle bounds, string? text, int* scrollIndex, int active)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiListView(bounds, sotext.AsPtr(), scrollIndex, active);
    }


    public static int GuiListViewEx(Rectangle bounds, string[] textArray, int count, int* focus, int* scrollIndex, int active)
    {

        sbyte** p_utf8 = stackalloc sbyte*[textArray.Length];
        for (int i = 0;
i < textArray.Length;
i++)
        {
            p_utf8[i] = (sbyte*)Marshal.StringToCoTaskMemUTF8(textArray[i]);
        }
        int toReturn = GuiListViewEx(bounds, p_utf8, count, focus, scrollIndex, active);

        for (int i = 0;
i < textArray.Length;
i++)
        {
            Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)p_utf8[i]);
        }

        return toReturn;
    }


    public static int GuiMessageBox(Rectangle bounds, string? title, string? message, string? buttons)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soTitle = title.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soMessage = message.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sobuttons = buttons.MarshalUtf8();
        return GuiMessageBox(bounds, soTitle.AsPtr(), soMessage.AsPtr(), sobuttons.AsPtr());
    }


    public static int GuiTextInputBox(Rectangle bounds, string? title, string? message, string? buttons, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soTitle = title.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soMessage = message.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sobuttons = buttons.MarshalUtf8();
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sotext = text.MarshalUtf8();
        return GuiTextInputBox(bounds, soTitle.AsPtr(), soMessage.AsPtr(), sobuttons.AsPtr(), sotext.AsPtr());
    }

    public static void GuiLoadStyle(string? fileName)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> sofileName = fileName.MarshalUtf8();
        GuiLoadStyle(sofileName.AsPtr());
    }

    public static string GuiIconText(int iconId, string? text)
    {
        using Microsoft.Toolkit.HighPerformance.Buffers.SpanOwner<sbyte> soText = text.MarshalUtf8();
        return Helpers.Utf8ToString(GuiIconText(iconId, soText.AsPtr()));
    }




















}
