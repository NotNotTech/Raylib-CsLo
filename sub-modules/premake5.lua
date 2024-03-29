newoption 
{
   trigger = "opengl43",
   description = "use OpenGL 4.3"
}

workspace "Raylib-With-Extras"
	configurations { "Debug","Debug.DLL", "Release", "Release.DLL" }
	platforms { "x64"}

	filter "configurations:Debug"
		defines { "DEBUG" }
		symbols "On"
		
	filter "configurations:Debug.DLL"
		defines { "DEBUG" }
		symbols "On"

	filter "configurations:Release"
		defines { "NDEBUG" }
		optimize "On"	
		
	filter "configurations:Release.DLL"
		defines { "NDEBUG" }
		optimize "On"	
		
	filter { "platforms:x64" }
		architecture "x86_64"
		
	targetdir "raylib-with-extras/bin/%{cfg.buildcfg}/"
	
	defines{"PLATFORM_DESKTOP"}
	if (_OPTIONS["opengl43"]) then
		defines{"GRAPHICS_API_OPENGL_43"}
	else
		defines{"GRAPHICS_API_OPENGL_33"}
	end
	
--The raylib-with-extras project, but named "raylib" so the dll is named properly
project "raylib"
	filter "configurations:Debug.DLL OR Release.DLL"
		kind "SharedLib"
		defines {"BUILD_LIBTYPE_SHARED"}
		
	filter "configurations:Debug OR Release"
		kind "StaticLib"
		
	filter "action:vs*"
		defines{"_WINSOCK_DEPRECATED_NO_WARNINGS", "_CRT_SECURE_NO_WARNINGS", "_WIN32"}
		links {"winmm"}
		
	filter "action:gmake*"
		links {"pthread", "GL", "m", "dl", "rt", "X11"}
		
	filter{}
	
	location "raylib-with-extras"
	language "C++"
	targetdir "raylib-with-extras/bin/%{cfg.buildcfg}"
	cppdialect "C++17"
	
	includedirs { "raylib/src","raylib/src/external/glfw/include", 	
	"raylib-extra-shims/src", --extras .c files	
	"physac/src/","raygui/src/","rres/src/" --extras .h files
} 
	vpaths 
	{
		["Header Files"] = { "raylib/src/**.h"},
		["Source Files/*"] = {"raylib/src/**.c"},
		["Extras Headers"] = { "physac/src/**.h","raygui/src/**.h","rres/src/**.h"},
		["Extras Sources"] = { "raylib-extra-shims/src/**.c"},
	}
	files {"raylib/src/*.h", "raylib/src/*.c","physac/src/**.h","raygui/src/**.h","rres/src/**.h", "raylib-extra-shims/src/*.c"}


-- -----------------  ORIGINAL FILE BELOW
-- workspace "RaylibDLLs"
-- 	configurations { "Debug","Debug.DLL", "Release", "Release.DLL" }
-- 	platforms { "x64"}

-- 	filter "configurations:Debug"
-- 		defines { "DEBUG" }
-- 		symbols "On"
		
-- 	filter "configurations:Debug.DLL"
-- 		defines { "DEBUG" }
-- 		symbols "On"

-- 	filter "configurations:Release"
-- 		defines { "NDEBUG" }
-- 		optimize "On"	
		
-- 	filter "configurations:Release.DLL"
-- 		defines { "NDEBUG" }
-- 		optimize "On"	
		
-- 	filter { "platforms:x64" }
-- 		architecture "x86_64"
		
-- 	targetdir "bin/%{cfg.buildcfg}/"
	
-- 	defines{"PLATFORM_DESKTOP"}
-- 	if (_OPTIONS["opengl43"]) then
-- 		defines{"GRAPHICS_API_OPENGL_43"}
-- 	else
-- 		defines{"GRAPHICS_API_OPENGL_33"}
-- 	end
	
-- project "raylib"
-- 		filter "configurations:Debug.DLL OR Release.DLL"
-- 			kind "SharedLib"
-- 			defines {"BUILD_LIBTYPE_SHARED"}
			
-- 		filter "configurations:Debug OR Release"
-- 			kind "StaticLib"
			
-- 		filter "action:vs*"
-- 			defines{"_WINSOCK_DEPRECATED_NO_WARNINGS", "_CRT_SECURE_NO_WARNINGS", "_WIN32"}
-- 			links {"winmm"}
			
-- 		filter "action:gmake*"
-- 			links {"pthread", "GL", "m", "dl", "rt", "X11"}
			
-- 		filter{}
		
-- 		location "build"
-- 		language "C++"
-- 		targetdir "bin/%{cfg.buildcfg}"
-- 		cppdialect "C++17"
		
-- 		includedirs { "raylib/src", "raylib/src/external/glfw/include"}
-- 		vpaths 
-- 		{
-- 			["Header Files"] = { "raylib/src/**.h"},
-- 			["Source Files/*"] = {"raylib/src/**.c"},
-- 		}
-- 		files {"raylib/src/*.h", "raylib/src/*.c"}
		
-- project "raygui"
-- 	kind "SharedLib"
-- 	location "raygui"
-- 	language "C"
-- 	targetdir "bin/%{cfg.buildcfg}"
	
-- 	includedirs {"src"}
-- 	vpaths 
-- 	{
-- 		["Header Files"] = { "**.h"},
-- 		["Source Files"] = {"**.c", "**.cpp"},
-- 	}
-- 	files {"raygui/**.c", "raygui/**.cpp", "raygui/**.h"}

-- 	links {"raylib"}
	
-- 	includedirs { "raygui", "raylib/src" }
-- 	defines{"PLATFORM_DESKTOP", "GRAPHICS_API_OPENGL_33"}
	
-- 	filter "action:vs*"
-- 		defines{"_WINSOCK_DEPRECATED_NO_WARNINGS", "_CRT_SECURE_NO_WARNINGS", "_WIN32"}
-- 		dependson {"raylib"}
-- 		links {"raylib.lib", "winmm", "kernel32"}
-- 		libdirs {"bin/%{cfg.buildcfg}"}
		
-- 	filter "action:gmake*"
-- 		links {"pthread", "GL", "m", "dl", "rt", "X11"}

		
-- project "raygui"
-- 	kind "SharedLib"
-- 	location "raygui"
-- 	language "C"
-- 	targetdir "bin/%{cfg.buildcfg}"
	
-- 	includedirs {"src"}
-- 	vpaths 
-- 	{
-- 		["Header Files"] = { "**.h"},
-- 		["Source Files"] = {"**.c", "**.cpp"},
-- 	}
-- 	files {"raygui/**.c", "raygui/**.cpp", "raygui/**.h"}

-- 	links {"raylib"}
	
-- 	includedirs { "raygui", "raylib/src" }
-- 	defines{"PLATFORM_DESKTOP", "GRAPHICS_API_OPENGL_33"}
	
-- 	filter "action:vs*"
-- 		defines{"_WINSOCK_DEPRECATED_NO_WARNINGS", "_CRT_SECURE_NO_WARNINGS", "_WIN32"}
-- 		dependson {"raylib"}
-- 		links {"raylib.lib", "winmm", "kernel32"}
-- 		libdirs {"bin/%{cfg.buildcfg}"}
		
-- 	filter "action:gmake*"
-- 		links {"pthread", "GL", "m", "dl", "rt", "X11"}

		
-- project "physac"
-- 		kind "SharedLib"
-- 		location "physac"
-- 		language "C"
-- 		targetdir "bin/%{cfg.buildcfg}"
		
-- 		includedirs {"src"}
-- 		vpaths 
-- 		{
-- 			["Header Files"] = { "**.h"},
-- 			["Source Files"] = {"**.c", "**.cpp"},
-- 		}
-- 		files {"physac/**.c", "physac/**.cpp", "physac/**.h"}
			
-- 		includedirs { "physac" }
-- 		defines{"PLATFORM_DESKTOP", "GRAPHICS_API_OPENGL_33"}
		
-- 		filter "action:vs*"
-- 			defines{"_WINSOCK_DEPRECATED_NO_WARNINGS", "_CRT_SECURE_NO_WARNINGS", "_WIN32"}
-- 			links {"winmm", "kernel32"}
-- 			libdirs {"bin/%{cfg.buildcfg}"}
			
-- 		filter "action:gmake*"
-- 			links {"pthread", "GL", "m", "dl", "rt", "X11"}