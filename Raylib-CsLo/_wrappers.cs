
using Raylib_CsLo.InternalHelpers;
using System.Runtime.InteropServices;

namespace Raylib_CsLo;

public static unsafe partial class Raylib
{
	public static bool IsKeyPressed(KeyboardKey key) => IsKeyPressed((int)key);

	public static bool IsKeyDown(KeyboardKey key) => IsKeyDown((int)key);
	public static bool IsKeyReleased(KeyboardKey key) => IsKeyReleased((int)key);

	public static bool IsKeyUp(KeyboardKey key) => IsKeyUp((int)key);
	public static void SetExitKey(KeyboardKey key) => SetExitKey((int)key);
	public static KeyboardKey GetKeyPressed_() => (KeyboardKey)GetKeyPressed();

	public static void InitWindow(int width, int height, string title)
	{
		using var spanOwner = title.MarshalUtf8();
		InitWindow(width, height, spanOwner.AsPtr());
	}


	public static bool IsGestureDetected(Gesture gesture) => IsGestureDetected((int)gesture);

	public static Gesture GetGestureDetected_() => (Gesture)GetGestureDetected();

	public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
	{
		using var spanOwner = text.MarshalUtf8();
		DrawText(spanOwner.AsPtr(), posX, posY, fontSize, color);
	}
	public static bool IsMouseButtonPressed(MouseButton button) => IsMouseButtonPressed((int)button);
	public static bool IsMouseButtonDown(MouseButton button) => IsMouseButtonDown((int)button);
	public static bool IsMouseButtonReleased(MouseButton button) => IsMouseButtonReleased((int)button);
	public static bool IsMouseButtonUp(MouseButton button) => IsMouseButtonUp((int)button);

	public static string TextFormat(string format, params object[] args)
	{
		return format.SPrintF(args);
	}
	/// <summary>
	/// dealing with __arglist: https://www.c-sharpcorner.com/UploadFile/b942f9/calling-unmanaged-functions-which-take-a-variable-number-of-arguments-from-C-Sharp/
	/// </summary>
	/// <param name="text"></param>
	/// <param name="__arglist"></param>
	/// <returns></returns>
	[DllImport("raylib.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* TextFormat([NativeTypeName("const char *")] sbyte* text,__arglist);


	public static void SetConfigFlags(ConfigFlags flags)
	{
		SetConfigFlags((uint)flags);
	}

	public static Texture LoadTexture(string fileName)
	{
		using var spanOwner = fileName.MarshalUtf8();
		return LoadTexture(spanOwner.AsPtr());
	}


	public static string GetMonitorName_(int monitor) => Marshal.PtrToStringUTF8((IntPtr)GetMonitorName(monitor));

	public static void SetClipboardText(string text)
	{
		using var spanOwner = text.MarshalUtf8();
		SetClipboardText(spanOwner.AsPtr());
	}

	public static string GetClipboardText_() => Marshal.PtrToStringUTF8((IntPtr)GetClipboardText());

	public static Shader LoadShader(string vsFileName, string fsFileName)
	{

		using var _vsFileName = vsFileName.MarshalUtf8();
		using var _fsFileName = fsFileName.MarshalUtf8();
		return LoadShader(_vsFileName.AsPtr(), _fsFileName.AsPtr());
	}
	public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
	{

		using var _vsCode = vsCode.MarshalUtf8();
		using var _fsCode = fsCode.MarshalUtf8();
		return LoadShaderFromMemory(_vsCode.AsPtr(), _fsCode.AsPtr());
	}
	public static int GetShaderLocation(Shader shader, string uniformName)
	{

		using var _uniformName = uniformName.MarshalUtf8();
		return GetShaderLocation(shader, _uniformName.AsPtr());
	}
	public static int GetShaderLocationAttrib(Shader shader, string uniformName)
	{

		using var _uniformName = uniformName.MarshalUtf8();
		return GetShaderLocationAttrib(shader, _uniformName.AsPtr());
	}
	public static void TakeScreenshot(string fileName)
	{
		using var spanOwner = fileName.MarshalUtf8();
		TakeScreenshot(spanOwner.AsPtr());
	}
	public static void TraceLog(int logLevel, string text)
	{
		using var spanOwner = text.MarshalUtf8();
		TraceLog(logLevel, spanOwner.AsPtr());
	}

	public static string GetGamepadName_(int gamepad)
	{
		var toReturn = GetGamepadName(gamepad);
		return Marshal.PtrToStringUTF8((IntPtr)toReturn);
	}
	public static bool TextIsEqual(string a, string b)
	{
		return a == b;
	}

	public static bool IsGamepadButtonPressed(int gamepad, GamepadButton button) =>
		IsGamepadButtonPressed(gamepad, (int)button);
	public static bool IsGamepadButtonDown(int gamepad, GamepadButton button) =>
		IsGamepadButtonDown(gamepad, (int)button);
	public static bool IsGamepadButtonReleased(int gamepad, GamepadButton button) =>
		IsGamepadButtonReleased(gamepad, (int)button);
	public static bool IsGamepadButtonUp(int gamepad, GamepadButton button) =>
		IsGamepadButtonUp(gamepad, (int)button);

	public static float GetGamepadAxisMovement(int gamepad, GamepadAxis axis) =>
		GetGamepadAxisMovement(gamepad, (int)axis);

	public static string[] GetDroppedFiles()
	{
		int count;
		var buffer = GetDroppedFiles(&count);
		var files = new string[count];

		for (int i = 0; i < count; i++)
		{
			files[i] = Marshal.PtrToStringUTF8((IntPtr)buffer[i]);
		}

		return files;
	}

	public static string[] GetDroppedFilesAndClear()
	{
		int count;
		var buffer = GetDroppedFiles(&count);
		var files = new string[count];

		for (int i = 0; i < count; i++)
		{
			files[i] = Marshal.PtrToStringUTF8((IntPtr)buffer[i]);
		}

		ClearDroppedFiles();

		return files;
	}
}


public partial struct Rectangle
{
	public Rectangle(float x, float y, float width, float height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}
}

public partial struct Camera3D
{
	public CameraProjection projection_
	{
		get => (CameraProjection)projection;
		set=>projection = (int)value;
	}

}
	
