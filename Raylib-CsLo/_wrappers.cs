// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System.Numerics;
using Raylib_CsLo.InternalHelpers;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

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

	public static void DrawText(string text, float posX, float posY, float fontSize, Color color)
	{
		DrawText(text, (int)posX, (int)posY, (int)fontSize, color);
	}
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
	public static extern sbyte* TextFormat([NativeTypeName("const char *")] sbyte* text, __arglist);


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

	public static void TraceLog(TraceLogLevel logLevel, string text, params object[] args)
	{
		text = text.SPrintF(args);
		TraceLog((int)logLevel, text);
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
		var files = GetDroppedFiles();
		ClearDroppedFiles();
		return files;
	}



	public static void SetCameraMode(Camera3D camera, CameraMode mode) => SetCameraMode(camera, (int)mode);
	public unsafe static void UpdateCamera(ref Camera3D camera)
	{
		fixed (Camera3D* ptr = &camera)
		{
			UpdateCamera(ptr);
		}
	}

	public static int MeasureText(string text, int fontSize)
	{
		using var so = text.MarshalUtf8();
		return MeasureText(so.AsPtr(), fontSize);
	}

	public static void SetTextureFilter(Texture texture, TextureFilter filter) => SetTextureFilter(texture, (int)filter);
	public static void SetTextureWrap(Texture texture, TextureWrap wrap) => SetTextureWrap(texture, (int)wrap);

	//public static void SetShaderValue(Shader shader, int locIndex, float* value, ShaderUniformDataType uniformType) => SetShaderValue(shader, locIndex, value, (int)uniformType);
	public static void SetShaderValue<T>(Shader shader, int locIndex, T* value, ShaderUniformDataType uniformType) where T : unmanaged => SetShaderValue(shader, locIndex, value, (int)uniformType);
	public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, ref T value, ShaderUniformDataType uniformType) where T : unmanaged
	{
		fixed (T* valuePtr = &value)
		{
			SetShaderValue(shader, uniformLoc, (void*)valuePtr, (int)uniformType);
		}
	}
	public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType) where T : unmanaged => SetShaderValue(shader, uniformLoc, (void*)(&value), (int)uniformType);
	public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType) where T : unmanaged
	{
		SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
	}
	public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType) where T : unmanaged
	{
		fixed (T* valuePtr = values)
		{
			Raylib.SetShaderValue(shader, uniformLoc, (void*)valuePtr, (int)uniformType);
		}
	}


	/// <summary>
	/// 'vector' (array) version of this function.  
	/// </summary>
	public static void SetShaderValueV<T>(Shader shader, int locIndex, T[] array, ShaderUniformDataType uniformType, int count) where T : unmanaged
	{
		fixed (T* p_array = array)
		{
			SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
		}
		//GCHandle pinnedData = GCHandle.Alloc(value, GCHandleType.Pinned);
		//Raylib.SetShaderValueV(shader, uniformLoc, pinnedData.AddrOfPinnedObject(), uniformType, count);
		//pinnedData.Free();
	}
	/// <summary>
	/// 'vector' (array) version of this function.  can pass a `ref` to an arrayItem instead of the entire array
	/// </summary>
	public static void SetShaderValueV<T>(Shader shader, int locIndex, ref T arrayOffset, ShaderUniformDataType uniformType, int count) where T : unmanaged
	{
		fixed (T* p_array = &arrayOffset)
		{
			SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
		}
		//GCHandle pinnedData = GCHandle.Alloc(value, GCHandleType.Pinned);
		//Raylib.SetShaderValueV(shader, uniformLoc, pinnedData.AddrOfPinnedObject(), uniformType, count);
		//pinnedData.Free();
	}
	public static void ClearWindowState(ConfigFlags flags) => ClearWindowState((uint)flags);

	public static void SetWindowState(ConfigFlags flags) => SetWindowState((uint)flags);

	public static bool IsWindowState(ConfigFlags flags) => IsWindowState((uint)flags);



	/// <summary>
	/// free animations via UnloadModelAnimation() when done
	/// </summary>
	/// <param name="fileName"></param>
	/// <returns></returns>
	public static ModelAnimation[] LoadModelAnimations(string fileName)
	{
		using var soFileName = fileName.MarshalUtf8();
		uint count;
		var p_animations = LoadModelAnimations(soFileName.AsPtr(), &count);
		ModelAnimation[] toReturn = new ModelAnimation[count];
		for (var i = 0; i < count; i++)
		{
			toReturn[i] = p_animations[i];
		}
		//this ptr isn't needed.
		MemFree(p_animations);
		return toReturn;
	}
	public static void UnloadModelAnimations(Span<ModelAnimation> modelAnimations)
	{
		foreach (var modelAnimation in modelAnimations)
		{
			UnloadModelAnimation(modelAnimation);
		}
	}


	public static void SetMaterialTexture(Material* material, MaterialMapIndex mapType, Texture texture) => SetMaterialTexture(material, (int)mapType, texture);

	public static Model LoadModel(string fileName)
	{
		using var soFileName = fileName.MarshalUtf8();
		return LoadModel(soFileName.AsPtr());
	}

	public static Image LoadImage(string fileName)
	{
		using var soFileName = fileName.MarshalUtf8();
		return LoadImage(soFileName.AsPtr());
	}


	public static string GetFileName(string filePath)
	{
		return Path.GetFileName(filePath);

		//if (filePath.Contains("/"))
		//{
		//	filePath = filePath.Substring(filePath.LastIndexOf("/") + 1);
		//}
		//if (filePath.Contains("/"))
		//{
		//	filePath = filePath.Substring(filePath.LastIndexOf('\\') + 1);
		//}
		//return filePath;
	}

	public static void DrawGrid(int slices, double spacing) => DrawGrid(slices, (float)spacing);


	public static Texture LoadTextureCubemap(Image image, CubemapLayout layout) => LoadTextureCubemap(image, (int)layout);

	public static long GetFileModTime(string fileName)
	{
		using var soFileName = fileName.MarshalUtf8();
		return GetFileModTime(soFileName.AsPtr());
	}

	public static void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int instances)
	{
		fixed (Matrix4x4* p_transforms = transforms)
		{
			Raylib.DrawMeshInstanced(mesh, material, p_transforms, instances);
		}
	}

	public static void BeginBlendMode(BlendMode blendMode) => BeginBlendMode((int)blendMode);


	public static void ImageDrawTextEx(ref Image dst, Font font, string fileName, Vector2 position, float fontSize, float spacing, Color tint)
	{
		using var text = fileName.MarshalUtf8();
		fixed (Image* p_dst = &dst)
		{
			ImageDrawTextEx(p_dst, font, text.AsPtr(), position, fontSize, spacing, tint);
		}

	}

	public static void ImageDrawTextEx(Image* p_dst, Font font, string fileName, Vector2 position, float fontSize, float spacing, Color tint)
	{
		using var text = fileName.MarshalUtf8();
		//fixed (Image* p_dst = &parrots)
		{
			ImageDrawTextEx(p_dst, font, text.AsPtr(), position, fontSize, spacing, tint);
		}

	}

	public static Font LoadFont(string fileName)
	{
		using var text = fileName.MarshalUtf8();
		return LoadFont(text.AsPtr());
	}

	public static void ImageFormat(Image* image, PixelFormat newFormat) => ImageFormat(image, (int)newFormat);



	public static Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
	{
		using var text = fileName.MarshalUtf8();
		return LoadFontEx(text.AsPtr(), fontSize, fontChars, glyphCount);
	}

	public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
	{
		using var p_text = text.MarshalUtf8();
		DrawTextEx(font, p_text.AsPtr(), position, fontSize, spacing, tint);
	}


	public static void ExportImage(Image image, string fileName)
	{
		using var soFilename = fileName.MarshalUtf8();
		ExportImage(image, soFilename.AsPtr());
	}
	public static void DrawTexturePoly(Texture texture, Vector2 center, Vector2[] positions, Vector2[] texcoords, int pointCount, Color tint)
	{
		fixed (Vector2* p_pos = positions)
		{
			fixed (Vector2* p_tex = texcoords)
			{
				DrawTexturePoly(texture, center, p_pos, p_tex, pointCount, tint);
			}

		}
	}

	public static Image LoadImageRaw(string fileName, int width, int height, PixelFormat format, int headerSize)
	{
		using var soFilename = fileName.MarshalUtf8();
		return LoadImageRaw(soFilename.AsPtr(), width, height, (int)format, headerSize);
	}
	public static Sound LoadSound(string fileName)
	{
		using var soFilename = fileName.MarshalUtf8();
		return LoadSound(soFilename.AsPtr());
	}
}

public static unsafe partial class RlGl
{

	public static void rlFramebufferAttach(uint fboId, uint texId, rlFramebufferAttachType attachType, rlFramebufferAttachTextureType texType, int mipLevel)
	=> rlFramebufferAttach(fboId, texId, (int)attachType, (int)texType, mipLevel);

	public static uint rlLoadTextureCubemap(void* data, int size, PixelFormat format)
	=> rlLoadTextureCubemap(data, size, (int)format);
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

	public float X
	{
		get => x;
		set => x = value;
	}
	public float Y
	{
		get => y;
		set => y = value;
	}
}

public partial struct Camera3D
{
	public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy, CameraProjection projection)
	{
		this.position = position;
		this.target = target;
		this.up = up;
		this.fovy = fovy;
		this.projection = (int)projection;
	}

	public CameraProjection projection_
	{
		get => (CameraProjection)projection;
		set => projection = (int)value;
	}

}

public partial struct Color
{
	public Color(byte r, byte g, byte b, byte a)
	{
		this.r = r;
		this.g = g;
		this.b = b;
		this.a = a;
	}
	public Color(int r, int g, int b, int a)
	{
		this.r = (byte)r;
		this.g = (byte)g;
		this.b = (byte)b;
		this.a = (byte)a;
	}
}
public partial struct BoundingBox
{
	public BoundingBox(Vector3 min, Vector3 max)
	{
		this.min = min;
		this.max = max;
	}
}
public unsafe partial struct float3
{
	public static float3 FromVector3(Vector3 vector)
	{
		var p_toReturn = (float3*)(void*)(&vector);
		return *p_toReturn;
	}
}
public unsafe partial struct float16
{
	public static float16 FromMatrix(Matrix4x4 matrix)
	{
		var p_toReturn = (float16*)(void*)(&matrix);
		return *p_toReturn;
	}
}
public partial struct Texture
{
	public PixelFormat format_
	{
		get => (PixelFormat)format;
		set => format = (int)value;
	}
}
public partial struct NPatchInfo
{

	public NPatchInfo(Rectangle source, int left, int top, int right, int bottom, NPatchLayout layout)
	{
		this.source = source;
		this.left = left;
		this.top = top;
		this.right = right;
		this.bottom = bottom;
		this.layout = (int)layout;
	}
}
