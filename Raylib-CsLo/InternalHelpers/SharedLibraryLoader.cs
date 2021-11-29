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
/// <remarks>
/// <para>kind of wacky pattern I made, which may be useful to others making native nuget packages:
/// The nuget packages need native binaries in a specific folder:
/// `./runtimes/{RID}/native/*` where `RID` is the RuntimeId for the os/platform in which dotnet is running.</para>
/// <para>I made a nuget package that's a wrapper over some native libraries (`raylib`).
/// Unfortunately running via visual studio project references doesn't lookup native binaries the same way as nuget.
/// Instead of having a different folder structure for source projects vs nuget,
/// I added a Custom Import Resolver: https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform#custom-import-resolver
/// which will search the  `./runtimes/{RID}/native/*` folder structure the same way nuget packages are structured.</para>
/// <para>This lets my source-based project/debugging have the same folder layout as nuget packages.</para>
/// </remarks>
static class SharedLibraryLoader
{
	[ModuleInitializer]
	internal static void Init()
	{
		// Register the import resolver before calling anything raylib related.
		// this will let our examples pick the proper runtime folder based on our os.
		NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
	}

	/// <summary>
	/// stores discovered location of libraries
	/// </summary>
	private static ConcurrentDictionary<string, IntPtr> _lookupCache = new();

	/// <summary>
	/// libs contained in "raylib-with-extras"
	/// </summary>
	private static HashSet<string> _raylibLibs = new() { "raylib", "raygui", "physac" };
	private static IntPtr DllImportResolver(string libName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		//use existing discovered location, if any
		{
			if (_lookupCache.TryGetValue(libName, out var libHandle))
			{
				return libHandle;
			}
		}
		//try the default first
		{
			if (NativeLibrary.TryLoad(libName, assembly, searchPath, out var libHandle))
			{
				_lookupCache.TryAdd(libName, libHandle);
				return libHandle;
			}
		}
		var potentialFileNames = new List<string>() { libName, $"lib{libName}" };

		if (_raylibLibs.Contains(libName))
		{
			potentialFileNames.Add("raylib-with-extras");
			potentialFileNames.Add("libraylib-with-extras");
		}


		if (CsLoSettings.openGl43 == true)
		{
			// experimental, for win-x64 only. 
			// only works with limitations: https://github.com/NotNotTech/Raylib-CsLo/issues/2
			//	other platforms should leave this disabled, or if your computer only supports ogl 3.3
			for (int i = potentialFileNames.Count - 1; i >= 0; i--)
			{
				var current = potentialFileNames[i];
				potentialFileNames.Add($"{current}-ogl43");
			}
			//attempt to load 4.3's first
			potentialFileNames.Reverse();
		}




		foreach (var potentialLibName in potentialFileNames)
		{
			if (_TryLoad(libName, potentialLibName, assembly, searchPath, out var toReturn))
			{
				_lookupCache.TryAdd(libName, toReturn);
				return toReturn;
			}
		}


		//fallback to default import resolver
		_lookupCache.TryAdd(libName, IntPtr.Zero);
		return IntPtr.Zero;
	}

	private static bool _TryLoad(string libName, string potentialLibName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr libHandle)
	{
		//first just try to load direct
		if (NativeLibrary.TryLoad(potentialLibName, assembly, searchPath, out libHandle))
		{
			return true;
		}

		//load from our subdir
		//nuget stores native binaries in folders according to "/runtimes/{$RID}/native/" so if we are using source code, emulate that loading behavior
		string runtimeId;
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
			//not a pre-known runtime, use whatever is given
			runtimeId = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;
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

			if (NativeLibrary.TryLoad($"{loadPath}{potentialLibName}", out libHandle))
			{
				return true;
			}
		}

		// Otherwise, fail out
		libHandle = IntPtr.Zero;
		return false;
	}
	private static IntPtr NewMethod(string libraryNameOrig)
	{
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
			var isSuccess = _LoadHelper(libraryNameOrig, libNameResolved, out var toReturn);
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


