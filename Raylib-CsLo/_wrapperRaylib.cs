// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright © Raylib-CsLo and Contributors. 
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
	public static void SetShaderValueV<T>(Shader shader, int locIndex, Span<T> values, ShaderUniformDataType uniformType, int count) where T : unmanaged
	{
		fixed (T* p_array = values)
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

	public static void DrawMeshInstanced(Mesh mesh, Material material, Span<Matrix4x4> transforms, int instances)
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
	public static void DrawTexturePoly(Texture texture, Vector2 center, Span<Vector2> positions, Span<Vector2> texcoords, int pointCount, Color tint)
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


	public static bool IsFileExtension(string fileName, string exts)
	{
		using var soFilename = fileName.MarshalUtf8();
		using var soExts = exts.MarshalUtf8();

		return IsFileExtension(soFilename.AsPtr(), soExts.AsPtr());
	}
	public static int TextLength(string text)
	{
		using var soText = text.MarshalUtf8();
		return (int)TextLength(soText.AsPtr());
	}

	public static int GetCodepoint(char stringChar, out int bytesProcessed)
	{
		sbyte charSbyte = (sbyte)stringChar;
		int byteCount = 0;
		var toReturn = Raylib.GetCodepoint(&charSbyte, &byteCount);
		bytesProcessed = byteCount;
		return toReturn;
	}

	public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
	{
		using var soText = text.MarshalUtf8();
		return MeasureTextEx(font, soText.AsPtr(), fontSize, spacing);
	}

	public static GlyphInfo* LoadFontData(byte* fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, FontType type)
		=> LoadFontData(fileData, dataSize, fontSize, fontChars, glyphCount, (int)type);

	public static byte* LoadFileData(string fileName, out uint bytesRead)
	{
		using var soFilename = fileName.MarshalUtf8();
		uint output;
		var toReturn = LoadFileData(soFilename.AsPtr(), &output);
		bytesRead = output;
		return toReturn;

	}
	public static void SetMouseCursor(MouseCursor cursor) => SetMouseCursor((int)cursor);


	public static int GetCodepointCount(string text)
	{
		using var soText = text.MarshalUtf8();
		return GetCodepointCount(soText.AsPtr());
	}
	public static string TextSubtext(string message, int position, int length)
	{
		return message.Substring(position, Math.Min(length,message.Length-position));
	}
	public static void UpdateAudioStream(AudioStream stream, Span<short> data, int frameCount)
	{
		fixed (short* writeBufPtr = data)
		{
			UpdateAudioStream(stream, writeBufPtr, frameCount);
		}
	}

}



public static unsafe partial class Raylib
{

	//public static void InitWindow(int width, int height, string title)
	//{
	//	using var sotitle = title.MarshalUtf8();
	//	InitWindow(width, height, sotitle.AsPtr());
	//}

	public static void SetWindowTitle(string title) { using var sotitle = title.MarshalUtf8(); SetWindowTitle(sotitle.AsPtr()); }

	//	public static string GetMonitorName_(int monitor)
	//=> Helpers.ToString(GetMonitorName(monitor));

	//public static void SetClipboardText(string text) { using var sotext = text.MarshalUtf8(); SetClipboardText(sotext.AsPtr()); }

	//public static string GetClipboardText_()=> Helpers.ToString(GetClipboardText());

	//public static Shader LoadShader(string vsFileName, string fsFileName)
	//{
	//	using var sovsFileName = vsFileName.MarshalUtf8();
	//	using var sofsFileName = fsFileName.MarshalUtf8();
	//	return LoadShader(sovsFileName.AsPtr(), sofsFileName.AsPtr());
	//}

	//public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
	//{
	//	using var sofsCode = fsCode.MarshalUtf8();
	//	return LoadShaderFromMemory( vsCode, sofsCode.AsPtr());
	//}

	//public static int GetShaderLocation(Shader shader, string uniformName)
	//{
	//	using var souniformName = uniformName.MarshalUtf8();
	//	return GetShaderLocation(Shader shader, souniformName.AsPtr());
	//}

	//public static int GetShaderLocationAttrib(Shader shader, string attribName)
	//{
	//	using var soattribName = attribName.MarshalUtf8();
	//	return GetShaderLocationAttrib(Shader shader, soattribName.AsPtr());
	//}

	//public static void TakeScreenshot(string fileName) { using var sofileName = fileName.MarshalUtf8(); TakeScreenshot(sofileName.AsPtr()); }

	//public static void TraceLog(int logLevel, string text)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return TraceLog(int logLevel, sotext.AsPtr());
	//}

	public static Boolean SaveFileData(string fileName, void* data, [NativeTypeName("unsigned int")] uint bytesToWrite)
	{
		using var sofileName = fileName.MarshalUtf8();
		return SaveFileData(sofileName.AsPtr(), data, bytesToWrite);
	}

	public static string LoadFileText(string fileName)
	{
		using var sotext = fileName.MarshalUtf8();
		return Helpers.Utf8ToString(LoadFileText(sotext.AsPtr()));
	}


	public static void UnloadFileText(string text)
	{
		using var sotext = text.MarshalUtf8();
		UnloadFileText(sotext.AsPtr());
	}

	public static Boolean SaveFileText(string fileName, string text)
	{
		using var sofileName = fileName.MarshalUtf8();
		using var sotext = text.MarshalUtf8();
		return SaveFileText(sofileName.AsPtr(), sotext.AsPtr());
	}

	public static Boolean FileExists(string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return FileExists(sofileName.AsPtr());
	}

	public static Boolean DirectoryExists(string dirPath)
	{
		using var sodirPath = dirPath.MarshalUtf8();
		return DirectoryExists(sodirPath.AsPtr());
	}

	//public static Boolean IsFileExtension(string fileName, string ext)
	//{
	//	using var soext = ext.MarshalUtf8();
	//	return IsFileExtension( fileName, soext.AsPtr());
	//}

	public static string GetFileExtension(string fileName)
	{
		using var sotext = fileName.MarshalUtf8();
		return Helpers.Utf8ToString(GetFileExtension(sotext.AsPtr()));
	}

	//public static string GetFileName(string filePath)
	//{
	//	using var sotext = filePath.MarshalUtf8();
	//	return Helpers.ToString(GetFileName(sotext.AsPtr()));
	//}

	public static string GetFileNameWithoutExt(string filePath)
	{
		using var sotext = filePath.MarshalUtf8();
		return Helpers.Utf8ToString(GetFileNameWithoutExt(sotext.AsPtr()));
	}

	public static string GetDirectoryPath(string filePath)
	{
		using var sotext = filePath.MarshalUtf8();
		return Helpers.Utf8ToString(GetDirectoryPath(sotext.AsPtr()));
	}

	public static string GetPrevDirectoryPath(string filePath)
	{
		using var sotext = filePath.MarshalUtf8();
		return Helpers.Utf8ToString(GetPrevDirectoryPath(sotext.AsPtr()));
	}

	public static string GetWorkingDirectory_()
=> Helpers.Utf8ToString(GetWorkingDirectory());

	public static string[] GetDirectoryFiles(string dirPath)
	{
		return Directory.GetFiles(dirPath);
	}

	public static Boolean ChangeDirectory(string dir)
	{
		using var sodir = dir.MarshalUtf8();
		return ChangeDirectory(sodir.AsPtr());
	}

	//public static sbyte** GetDroppedFiles(int* count);

	//public static int GetFileModTime(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return GetFileModTime(sofileName.AsPtr());
	//}

//	public static string EncodeDataBase64([NativeTypeName("const unsigned char *")] byte* data, int dataLength, int* outputLength)
//=> Helpers.ToString(EncodeDataBase64([NativeTypeName("const unsigned char *")] byte * data, int dataLength, int * outputLength));

	public static void OpenURL(string url) { using var sourl = url.MarshalUtf8(); OpenURL(sourl.AsPtr()); }

//	public static string GetGamepadName_(int gamepad)
//=> Helpers.ToString(GetGamepadName(gamepad));

	public static int SetGamepadMappings(string mappings)
	{
		using var somappings = mappings.MarshalUtf8();
		return SetGamepadMappings(somappings.AsPtr());
	}

	//public static Image LoadImage(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadImage(sofileName.AsPtr());
	//}

	public static Image LoadImageRaw(string fileName, int width, int height, int format, int headerSize)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadImageRaw(sofileName.AsPtr(),  width,  height,  format,  headerSize);
	}

	public static Image LoadImageAnim(string fileName, int* frames)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadImageAnim(sofileName.AsPtr(),  frames);
	}

	public static Image LoadImageFromMemory(string fileType, [NativeTypeName("const unsigned char *")] byte* fileData, int dataSize)
	{
		using var sofileType = fileType.MarshalUtf8();
		return LoadImageFromMemory(sofileType.AsPtr(), fileData,  dataSize);
	}

	//public static Boolean ExportImage(Image image, string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return ExportImage(Image image, sofileName.AsPtr());
	//}

	public static Boolean ExportImageAsCode(Image image, string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return ExportImageAsCode(image, sofileName.AsPtr());
	}

	public static Image ImageText(string text, int fontSize, Color color)
	{
		using var sotext = text.MarshalUtf8();
		return ImageText(sotext.AsPtr(),  fontSize,  color);
	}

	public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
	{
		using var sotext = text.MarshalUtf8();
		return ImageTextEx( font, sotext.AsPtr(),  fontSize,spacing,  tint);
	}

	public static void ImageDrawText(Image* dst, string text, int posX, int posY, int fontSize, Color color)
	{
		using var sotext = text.MarshalUtf8();
		ImageDrawText(dst, sotext.AsPtr(),  posX,  posY,  fontSize,  color);
	}

	//public static void ImageDrawTextEx(Image* dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return ImageDrawTextEx( dst,  font, sotext.AsPtr(),  position,  fontSize,  spacing,  tint);
	//}

	//public static Texture LoadTexture(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadTexture(sofileName.AsPtr());
	//}

	//public static Font LoadFont(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadFont(sofileName.AsPtr());
	//}

	//public static Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadFontEx(sofileName.AsPtr(), int fontSize, int * fontChars, int glyphCount);
	//}

	public static Font LoadFontFromMemory(string fileType, byte* fileData, int dataSize, int fontSize, int* fontChars, int glyphCount)
	{
		using var sofileType = fileType.MarshalUtf8();
		return LoadFontFromMemory(sofileType.AsPtr(),  fileData,  dataSize,  fontSize,  fontChars,  glyphCount);
	}

	//public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return DrawText(sotext.AsPtr(), int posX, int posY, int fontSize, Color color);
	//}

	//public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return DrawTextEx(Font font, sotext.AsPtr(), Vector2 position, float fontSize, float spacing, Color tint);
	//}

	public static void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
	{
		using var sotext = text.MarshalUtf8();
		DrawTextPro( font, sotext.AsPtr(),  position,  origin,  rotation,  fontSize,  spacing,  tint);
	}

	//public static int MeasureText(string text, int fontSize)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return MeasureText(sotext.AsPtr(), int fontSize);
	//}

	//public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return MeasureTextEx(Font font, sotext.AsPtr(), float fontSize, float spacing);
	//}

	public static int* LoadCodepoints(string text, int* count)
	{
		using var sotext = text.MarshalUtf8();
		return LoadCodepoints(sotext.AsPtr(), count);
	}

	//public static int GetCodepointCount(string text)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return GetCodepointCount(sotext.AsPtr());
	//}

	public static int GetCodepoint(string text, int* bytesProcessed)
	{
		using var sotext = text.MarshalUtf8();
		return GetCodepoint(sotext.AsPtr(),  bytesProcessed);
	}

	public static string CodepointToUTF8_(int codepoint, int* byteSize)
=> Helpers.Utf8ToString(CodepointToUTF8( codepoint,  byteSize));

	public static string TextCodepointsToUTF8_(int* codepoints, int length)
=> Helpers.Utf8ToString(TextCodepointsToUTF8( codepoints,  length));

	public static int TextCopy(string dst, string src)
	{
		using var sodst = dst.MarshalUtf8();
		using var sosrc = src.MarshalUtf8();
		return TextCopy(sodst.AsPtr(), sosrc.AsPtr());
	}

	//public static Boolean TextIsEqual(string text1, string text2)
	//{
	//	using var sotext1 = text1.MarshalUtf8();
	//	using var sotext2 = text2.MarshalUtf8();
	//	return TextIsEqual( sotext1.AsPtr(), sotext2.AsPtr());
	//}

	//public static uint TextLength(string text)
	//{
	//	using var sotext = text.MarshalUtf8();
	//	return TextLength(sotext.AsPtr());
	//}

//	public static string TextFormat_(sbyte* text)
//=> Helpers.ToString(TextFormat( text));

//	public static string TextSubtext_(sbyte* text, int position, int length)
//=> Helpers.ToString(TextSubtext( text, int position, int length));

//	public static string TextReplace_(sbyte* text, sbyte* replace, sbyte* by)
//=> Helpers.ToString(TextReplace( text,  replace,  by));

//	public static string TextInsert_(sbyte* text, sbyte* insert, int position)
//=> Helpers.ToString(TextInsert( text,  insert, int position));

//	public static string TextJoin_(sbyte** textList, int count, sbyte* delimiter)
//=> Helpers.ToString(TextJoin( *textList, int count,  delimiter));

	//public static sbyte** TextSplit(sbyte* text, [NativeTypeName("char")] sbyte delimiter, int* count);

	//public static void TextAppend(string text, string append, int* position)
	//{
	//	using var sotext = append.MarshalUtf8();
	//	using var soappend = append.MarshalUtf8();
	//	TextAppend(sotext.AsPtr(), soappend.AsPtr(),  position);
	//}

	//public static int TextFindIndex(sbyte* text, string find)
	//{
	//	using var sofind = find.MarshalUtf8();
	//	return TextFindIndex( text, sofind.AsPtr());
	//}

//	public static string TextToUpper_(sbyte* text)
//=> Helpers.ToString(TextToUpper( text));

//	public static string TextToLower_(sbyte* text)
//=> Helpers.ToString(TextToLower( text));

//	public static string TextToPascal_(sbyte* text)
//=> Helpers.ToString(TextToPascal( text));

	public static int TextToInteger(string text)
	{
		using var sotext = text.MarshalUtf8();
		return TextToInteger(sotext.AsPtr());
	}

	//public static Model LoadModel(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadModel(sofileName.AsPtr());
	//}

	public static Boolean ExportMesh(Mesh mesh, string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return ExportMesh( mesh, sofileName.AsPtr());
	}

	public static Material* LoadMaterials(string fileName, int* materialCount)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadMaterials(sofileName.AsPtr(),materialCount);
	}

	public static ModelAnimation* LoadModelAnimations(string fileName, [NativeTypeName("unsigned int *")] uint* animCount)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadModelAnimations(sofileName.AsPtr(), animCount);
	}

	public static Wave LoadWave(string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadWave(sofileName.AsPtr());
	}

	public static Wave LoadWaveFromMemory(string fileType, [NativeTypeName("const unsigned char *")] byte* fileData, int dataSize)
	{
		using var sofileType = fileType.MarshalUtf8();
		return LoadWaveFromMemory(sofileType.AsPtr(),  fileData,  dataSize);
	}

	//public static Sound LoadSound(string fileName)
	//{
	//	using var sofileName = fileName.MarshalUtf8();
	//	return LoadSound(sofileName.AsPtr());
	//}

	public static Boolean ExportWave(Wave wave, string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return ExportWave( wave, sofileName.AsPtr());
	}

	public static Boolean ExportWaveAsCode(Wave wave, string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return ExportWaveAsCode( wave, sofileName.AsPtr());
	}

	public static Music LoadMusicStream(string fileName)
	{
		using var sofileName = fileName.MarshalUtf8();
		return LoadMusicStream(sofileName.AsPtr());
	}

	public static Music LoadMusicStreamFromMemory(string fileType, [NativeTypeName("unsigned char *")] byte* data, int dataSize)
	{
		using var sofileType = fileType.MarshalUtf8();
		return LoadMusicStreamFromMemory(sofileType.AsPtr(), data,  dataSize);
	}

}


