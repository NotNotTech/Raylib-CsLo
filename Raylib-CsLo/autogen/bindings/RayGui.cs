//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_CsLo
{
    public static unsafe partial class RayGui
    {
        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiEnable();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiDisable();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiLock();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiUnlock();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiIsLocked();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiFade(float alpha);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiSetState(int state);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiGetState();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiSetFont(Font font);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Font GuiGetFont();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiSetStyle(int control, int property, int value);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiGetStyle(int control, int property);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiWindowBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* title);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiGroupBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiLine(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiPanel(Rectangle bounds);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Rectangle GuiScrollPanel(Rectangle bounds, Rectangle content, Vector2* scroll);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiLabel(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiButton(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiLabelButton(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiToggle(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, Boolean active);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiToggleGroup(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int active);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiCheckBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, Boolean @checked);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiComboBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int active);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiDropdownBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int* active, Boolean editMode);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiSpinner(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int* value, int minValue, int maxValue, Boolean editMode);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiValueBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int* value, int minValue, int maxValue, Boolean editMode);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiTextBox(Rectangle bounds, [NativeTypeName("char *")] sbyte* text, int textSize, Boolean editMode);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiTextBoxMulti(Rectangle bounds, [NativeTypeName("char *")] sbyte* text, int textSize, Boolean editMode);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GuiSlider(Rectangle bounds, [NativeTypeName("const char *")] sbyte* textLeft, [NativeTypeName("const char *")] sbyte* textRight, float value, float minValue, float maxValue);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GuiSliderBar(Rectangle bounds, [NativeTypeName("const char *")] sbyte* textLeft, [NativeTypeName("const char *")] sbyte* textRight, float value, float minValue, float maxValue);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GuiProgressBar(Rectangle bounds, [NativeTypeName("const char *")] sbyte* textLeft, [NativeTypeName("const char *")] sbyte* textRight, float value, float minValue, float maxValue);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiStatusBar(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiDummyRec(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiScrollBar(Rectangle bounds, int value, int minValue, int maxValue);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Vector2 GuiGrid(Rectangle bounds, float spacing, int subdivs);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiListView(Rectangle bounds, [NativeTypeName("const char *")] sbyte* text, int* scrollIndex, int active);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiListViewEx(Rectangle bounds, [NativeTypeName("const char **")] sbyte** text, int count, int* focus, int* scrollIndex, int active);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiMessageBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* title, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("const char *")] sbyte* buttons);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GuiTextInputBox(Rectangle bounds, [NativeTypeName("const char *")] sbyte* title, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("const char *")] sbyte* buttons, [NativeTypeName("char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Color GuiColorPicker(Rectangle bounds, Color color);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Color GuiColorPanel(Rectangle bounds, Color color);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GuiColorBarAlpha(Rectangle bounds, float alpha);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GuiColorBarHue(Rectangle bounds, float value);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiLoadStyle([NativeTypeName("const char *")] sbyte* fileName);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiLoadStyleDefault();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GuiIconText(int iconId, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiDrawIcon(int iconId, int posX, int posY, int pixelSize, Color color);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int *")]
        public static extern uint* GuiGetIcons();

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int *")]
        public static extern uint* GuiGetIconData(int iconId);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiSetIconData(int iconId, [NativeTypeName("unsigned int *")] uint* data);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiSetIconPixel(int iconId, int x, int y);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GuiClearIconPixel(int iconId, int x, int y);

        [DllImport("raygui", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GuiCheckIconPixel(int iconId, int x, int y);

        [NativeTypeName("#define RAYGUI_VERSION \"3.0\"")]
        public static ReadOnlySpan<byte> RAYGUI_VERSION => new byte[] { 0x33, 0x2E, 0x30, 0x00 };
    }
}
