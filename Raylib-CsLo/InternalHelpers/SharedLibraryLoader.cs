// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright © Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Raylib_CsLo;

/// <summary>
/// searches the /runtimes/ folder for shared libraries
/// </summary>
static class SharedLibraryLoader
{
	[ModuleInitializer]
	public static void Init()
	{
		// Register the import resolver before calling anything raylib related.
		// this will let our examples pick the proper runtime folder based on our os.
		NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
	}

	/// <summary>
	/// stores discovered location of libraries
	/// </summary>
	private static ConcurrentDictionary<string, IntPtr> _lookupCache = new();
	private static IntPtr DllImportResolver(string libraryNameOrig, Assembly assembly, DllImportSearchPath? searchPath)
	{
		//use existing discovered location, if any
		{
			if (_lookupCache.TryGetValue(libraryNameOrig, out var libHandle))
			{
				return libHandle;
			}
		}

		string libNameResolved = libraryNameOrig;
		if (CsLoSettings.openGl43 == true)
		{
			// experimental, for win-x64 only. 
			// only works with limitations: https://github.com/NotNotTech/Raylib-CsLo/issues/2
			//	other platforms should leave this disabled, or if your computer only supports ogl 3.3

			if (libraryNameOrig == "raylib")
			{
				libNameResolved = "raylib-ogl43";
			}
			//else if (libraryNameOrig == "raygui")
			//{
			//	libNameResolved = "raygui-ogl43";
			//}
		}


		string runtimeId;
		//load from our subdir
		if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			if (System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture == Architecture.X64)
			{
				runtimeId = "win-x64";
			}
			else
			{
				runtimeId = "win-x86";
			}
		}
		else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			runtimeId = "linux-x64";
		}
		else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			runtimeId = "osx-x64";
		}
		else
		{
			//unknown runtime, just cache and return whatever is returned when we try to load, if it succeeds or not
			var isSuccess = _LoadHelper(libraryNameOrig,libNameResolved,out var toReturn);
			_lookupCache.TryAdd(libraryNameOrig, toReturn);
			return toReturn;
		}

		const int TECHNIQUE_COUNT = 3;
		for (var i = 0; i < TECHNIQUE_COUNT; i++)
		{
			string baseFolder;
			switch (i)
			{
				case 0:
				{
					baseFolder = AppDomain.CurrentDomain.BaseDirectory;
					break;
				}
				case 2:
				{
					baseFolder = Environment.CurrentDirectory;
					break;
				}
				default:
				case 1:
				{
					baseFolder = "./";
					break;
				}
			}

			var loadPath = Path.Combine(baseFolder, $"runtimes/{runtimeId}/native/");

			if (_LoadHelper(libraryNameOrig, $"{loadPath}{libNameResolved}", out var toReturn))
			{
				//success;
				return toReturn;
			}
			//try again prefixing with "lib"
			if (_LoadHelper(libraryNameOrig, $"{loadPath}lib{libNameResolved}", out toReturn))
			{
				//success;
				return toReturn;
			}

		}

		// Otherwise, fallback to default import resolver.
		_lookupCache.TryAdd(libraryNameOrig, IntPtr.Zero);
		return IntPtr.Zero;

	}

	/// <summary>
	/// returns true if loaded and cached.   false otherwise
	/// </summary>
	private static bool _LoadHelper(string libraryNameOrig, string loadPathAndName, out IntPtr libHandle)
	{
		if (NativeLibrary.TryLoad(loadPathAndName, out libHandle))
		{
			//success;
			_lookupCache.TryAdd(libraryNameOrig, libHandle);
			return true;
		}
		libHandle = IntPtr.Zero;
		return false;

	}
}


