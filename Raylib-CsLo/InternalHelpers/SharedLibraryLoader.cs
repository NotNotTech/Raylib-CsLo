// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright © Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

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
	private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		{
			string runtime;
			//load from our subdir
			if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				if (System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture == Architecture.X64)
				{
					runtime = "win-x64";
				}
				else
				{
					runtime = "win-x86";
				}
			}
			else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				runtime = "linux-x64";
			}
			else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				runtime = "osx-x64";
			}
			else
			{
				runtime = null;
			}

			if (runtime != null)
			{

				var loadPath = $"./runtimes/{runtime}/native/{libraryName}";
				if (NativeLibrary.TryLoad(loadPath, out var toReturn))
				{
					//success;
					return toReturn;
				}
				//try again prefixing with "lib"
				loadPath = $"./runtimes/{runtime}/native/lib{libraryName}";
				if (NativeLibrary.TryLoad(loadPath, out toReturn))
				{
					//success;
					return toReturn;
				}
			}
		}

		// Otherwise, fallback to default import resolver.
		return IntPtr.Zero;
	}
}


