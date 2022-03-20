<div align="center">
<img src="https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo/Icon.png">
</div>

<div align="center">
<a href="https://www.nuget.org/packages/Raylib-CsLo/"> <img src="https://img.shields.io/nuget/v/Raylib-CsLo"> </a>
</div>

<div align="center">
<a href="https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples"> <img src="https://img.shields.io/badge/🚀_100+_Examples_🚀-teal"> </a>
<a href="https://discord.gg/raylib"> <img src="https://img.shields.io/badge/chat%20on-discord-7289DA"> </a>
</div>

# About
Managed C# bindings to `Raylib`, a friendly 2d/3d game framework similar to XNA / MonoGame
- Win/Linux/OsX supported
- All Raylib features, including Extras bindings
    - `raylib` : Core features, including Audio
    - `rlgl` : OpenGl abstraction
    - `raygui` : An Imperitive Gui
    - `physac` : A 2d physics framework
    - `easings` : for simple animations (Managed Port)
    - `raymath` : game math library (Managed Port)
- Minimal bindings + convenience wrappers to make it easier to use
- Tested and verified **ALL** 100+ Raylib examples. These [ported examples are available to you in the GitHub Repo](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)
- Supports `net5+`, `Mono 6.4+`, `NetCore3+` (via `netStandard 2.1`)
- Tested on `Win10`. User Reports `Arch` Linux works. Please test on other platforms and [raise an issue](https://github.com/NotNotTech/Raylib-CsLo/issues) if any problems occur
- A focus on performance. No runtime allocations if at all possible
- No intellisense docs. [read the raylib cheatsheet for docs](https://www.raylib.com/cheatsheet/cheatsheet.html) or [view the 100+ examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)
- Full source code included in [The GitHub Repository](https://github.com/NotNotTech/Raylib-CsLo), including native sources, allowing you to compile for any platform you wish
- [A Nuget package is avalable](https://www.nuget.org/packages/Raylib-CsLo)

## What is **Raylib**?
[Raylib](https://www.raylib.com/) is a friendly-to-use game framework that includes basic scenarios to meet your needs:  
audio, 2d, 3d, fonts, animation, 2d physics.

Somewhat similar to `Xna` or `MonoGame` but friendlier.  
**However, `Raylib` is a C/CPP framework**.  
`Raylib-CsLo` is a C# Wrapper over the top, which lets you gain raylib's powers to quickly prototype your game ideas.  

## Super easy to use for 2d!
If you stick with 2d, you don't need to use any `unsafe` (pointer) code, which lets 2d users feel at home and use `Raylib-CsLo` as an awesome 2d game framework.

## High performance for 3d! (but `unsafe` to use)
If you use 3d, you need to understand a bit of how pointers work.  
Raylib uses these to link things like `Model`, `Mesh`, and `Material`.  
Writing wrappers over these is possible but it would basically be creating a an entirely new framework.  
I suggest leaving this as-is, as it avoids object allocation (GC Pressure).

Additionally, 3d users: **Be sure you check the Usage Tips section below**, especially on how you need to use
`Matrix4x4.Transpose()` when sending matricies to Raylib.

# How to use/install

## via Nuget
1. add the latest version of [The Raylib-CsLo Nuget Package](https://www.nuget.org/packages/Raylib-CsLo) to your project
2. Create an example project using it, the following code is copied from [The StandAlone Example's Program.cs](https://github.com/NotNotTech/Raylib-CsLo/tree/main/StandaloneExample/program.cs)
```cs
namespace StandaloneExample;

using Raylib_CsLo;
using System.Threading.Tasks;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Raylib.InitWindow(1280, 720, "Hello, Raylib-CsLo");
        Raylib.SetTargetFPS(60);
        // Main game loop
        while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.Skyblue);
            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("Raylib is easy!!!", 640, 360, 50, Raylib.Red);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
```

## via sources
1. clone/download the [github repository](https://github.com/NotNotTech/Raylib-CsLo)
2. open `./Raylib-CsLo.sln` in Visual Studio 2022.
3. build and run the `Raylib-CsLo.Examples` project will run by default, and will run through all (aprox 100+) examples.
4. For a stand-alone example that uses the Nuget Package, see the [`./StandaloneExample` folder](https://github.com/NotNotTech/Raylib-CsLo/tree/main/StandaloneExample)

# Linux / OsX / other platform support

The following platforms are shipped in the nuget package:
- `win-x64` : confirmed working on `Win10, x64`. This is the platform used for dev/testing of `raylib-cslo`.
- `linux-x64`: confirmed working on `Arch` Linux. Binaries built under `Ubuntu 20.04` so that shold also work.
- `osx-x64`: not confirmed yet. Please let me know if you try.

You can build the native binaries for whatever platform you need. Please see the readme under [Runtimes/](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo/runtimes) for more info.

# Examples
Here are links to most the examples. The images/links probably won't work from Nuget. [Visit the Github Repo to see it properly.](https://github.com/NotNotTech/Raylib-CsLo)

# Differences from `Raylib-Cs`
| [`Raylib-Cs`](https://github.com/ChrisDill/Raylib-cs)                                | `Raylib-CsLo`                                                                                        |
| ------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------- |
| Each binding is hand crafted with carefull design                                    | Exact Bindings (Autogen) with wrappers to make C# usage nice.                                        |
| Bindings for `Raylib` and extras `RayMath`, `RlGl`.                                  | Bindings for `Raylib` and all extras (`RayGui`, `Easings`, `Physac`, `RlGl`, `RayMath`)              |
| Optimized for normal C# usage                                                        | Optimized for maximum performance and requires `unsafe`                                              |
| New Raylib version? Harder to detect breaking changes                                | New Raylib version? Breaking changes are easy to spot and fix                                        |
| includes Intellisence docs                                                           | No docs. Use the [Cheatsheet](https://www.raylib.com/cheatsheet/cheatsheet.html)                     |
| [Examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples) | [Examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)                 |
| has a long track record                                                              | didn't exist till mid november 2021!                                                                 |
| [Lots of examples](https://github.com/ChrisDill/Raylib-cs-Examples)                  | [ALL 100+ Raylib examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples) |
| zlib licensed                                                                        | MPL 2.0 Licensed licensed                                                                            |
| [Nuget Package](https://www.nuget.org/packages/Raylib-cs/)                           | [Nuget Package](https://www.nuget.org/packages/Raylib-CsLo)                                          |
| raylib 3.7.1 Stable                                                                  | Raylib 4.0.0                                                                                         |

# Extras (1st person, 3rd person cameras)
If you need a custom camera, check out the `Raylib-Extras-CsLo` project, which contains a custom First Person Camera and Third Person Camera. https://github.com/NotNotTech/Raylib-Extras-CsLo

# Usage Tips / FAQ
- **How do I do `SOME_IDEA`?**
    - All the Raylib examples (100+) have been ported successfully. Please refer to them here: [ALL 100+ Raylib examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples). If you need more help, ask on Discord.
- **Does `Raylib-CsLo` include the `SOME_FUNCTION_YOU_NEED()` function?**
    - Raylib-CsLo has bindings for everything in the Raylib 4.0 release, including extras like `raygui` and `physac`, but with the exception of things in the `Known Issues` section further below.
- **Why didn't you add a wrapper for function `SOME_OTHER_FUNCTION_YOU_NEED()`?**
    - Raylib-CsLo uses a manual marshalling technique, as the built in PInvoke marshalling is not very efficienct. Most API's have wrappers (and all involving `string` marshalling), but some involving pointers have been left as-is. If you come across a function that you feel needs more wrapping, you can [raise an issue](https://github.com/NotNotTech/Raylib-CsLo/issues) or perhaps [submit a PR](https://github.com/NotNotTech/Raylib-CsLo/pulls)
- **How do I convert a string to `sbyte*` or vice-versa?**
    - All API's that take `sbyte*` have `string` wrappers, so be sure to look at the overload you can call.
- **Do I have to really cast my Enum to `int`?**
    - The autogen bindings are left untouched, however convenience wrappers are added. Usually these will automagically "work" via function overloads, but where this is not possible, try adding an underscore `_` to the end of the function/property. For example: `Camera3D.projection_ = CameraProjection.CAMERA_ORTHOGRAPHIC;` or `Gesture gesture = Raylib.GetGestureDetected_();`.
    - If all else fails, yes. Cast to `(int)`.
- **I ran the examples in a profiler. What are all these `sbyte[]` arrays being allocated?**
    - A pool of `sbyte[]` is allocated for string marshall purposes, to avoid runtime allocations.
- **Can I, Should I use `RayMath`?**
    - `Raylib_CsLo.RayMath` contains a lot of super helpful functions for doing gamedev related maths.
    - The `RayMath` helper functions have been translated into C# code. This makes the code pretty fast, but if the same function exists under `System.Numerics` you should use that instead, because the DotNet CLR treats things under System.Numerics special, and optimizes it better.
- **Why are my matricies corrupt?**
    - Raylib/OpenGl uses column-major matricies, while dotnet/vulkan/directx uses row-major. When passing your final calculated matrix to raylib for rendering, call `Matrix4x4.Transpose(yourMatrix)`

# Known Issues:
- `RayGui`: be sure to call `RayGui.GuiLoadStyleDefault();` right after you `InitWindow()`. This is needed to initialize the gui properly. If you don't, if you close a raylib window and then open a new one (inside the same app), the gui will be broken.
- The `Text.Unicode` example doesn't render unicode properly. Maybe the required font is missing, maybe there is a bug in the example (Utf16 to Utf8 conversion) or maybe there is a bug in Raylib. A hunch: I think it's probably due to the fonts not including unicode characters, but I didn't investigate further.
- Native Memory allocation functions are not ported: use `System.Runtime.InteropServices.NativeMemory.Alloc()` instead
- `LogCustom()` is ported but doesn't support variable length arguments.
- `Texture2D` doesn't exist. it is just an alias for `Texture` so use that instead. You might want to use `using` aliases like the following

`usings` to make C# code more like the raylib cpp examples.
to see more stuff like this, look at Raylib-CsLo.Examples/program.cs
```cs
global using Camera = Raylib_CsLo.Camera3D;
global using RenderTexture2D = Raylib_CsLo.RenderTexture;
global using Texture2D = Raylib_CsLo.Texture;
global using TextureCubemap = Raylib_CsLo.Texture;
global using Matrix = System.Numerics.Matrix4x4;
```

# How to Contribute

1. `git clone https://github.com/NotNotTech/Raylib-CsLo.git --recursive`
2. assume you are using Visual Studio (or maybe rider?) and can run `dev.sln`
3. fork the repo, build and try out the example project
4. Pick something to do
    - test/improve support on linux and/or OsX
    - improve wrappers for ease of use
    - check issues


# License options: `MPL2.0` or `PCL`
## [Mozilla Public License 2.0 (**MPL**)](https://github.com/NotNotTech/Raylib-CsLo/blob/main/LICENSE)
By default, this repository is licensed under the [Mozilla Public License 2.0 (**MPL**)](https://github.com/NotNotTech/Raylib-CsLo/blob/main/LICENSE).  
The MPL is a popular "weak copyleft" license that allows just about anything.  
**For example, you may use/include/static-link this library in a commercial, closed-source project without any burdens.**  
The main limitation of the MPL being that: ***Modifications to the source code in this project must be open sourced***.  
The MPL is a great choice, both by providing flexibility to the user, and by encouraging contributions to the underlying project.  
If you would like to read about the MPL, **FOSSA** has [a great overview of the MPL 2.0 here](https://fossa.com/blog/open-source-software-licenses-101-mozilla-public-license-2-0/).

## Private Commercial License (**PCL**)
If for some reason you or your organization really, ***REALLY*** can not open source your modifications to this project, I am willing to offer a PCL for USD $1000, half of which will be donated to the upstream `raylib` project.  
Payment can be made via github donations.  
Yes $1000 is a lot of money, so just try to accept the MPL terms and move on with life!  
If you still think a PCL is what you need, raise an issue or email JasonS aat Novaleaf doot coom to discuss.  

# ChangeLog
changelog for major releases.

- **4.0.0-rc.5.0** (2021/12/15): No breaking changes. Broaden DotNet support to Net5+, etc (via NetStandard 2.1)
- **4.0.0-rc.4.0** (2021/12/04): No breaking changes. Cleanup and change license from LGPL to MPL, because LGPL doesn't allow private static linking.
- **4.0.0-rc.3** (2021/11/29): No breaking changes. Improve Boolean Marshalling.
- **4.0.0-rc.2** (2021/11/28): Rollup all native code into single binary. Improve bindings compat.
- **4.0.0-rc.1** (2021/11/24): Support for Linux and OsX (hopefully).
- **4.0.0-rc.0** (2021/11/22): `physac.dll` and bindings for it added. `Physics` and `Audio` examples ported. All `raylib` examples complete!
- **4.0.0-beta.2** (2021/11/22): `RayGui`, and `Easings` Raylib.extras ported to managed code. `Shapes`,`Textures`, and `Text` examples ported.
- **4.0.0-beta.0** (2021/11/20): `Model`, and `Shader` examples ported.
- **4.0.0-alpha.2** (2021/11/18): Model examples ported. AutoGen Bindings expanded to include all api's exposed by Raylib.dll (adding `RayMath`, `RlGl`)
- **4.0.0-alpha.1** (2021/11/16): all `Core` examples ported, so "feature complete" for the workflows used in those examples (and, complete only for those workflows)
