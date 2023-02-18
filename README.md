| [![Raylib-CsLo-Logo](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/meta/logos/raylib-cslo_128x128.png)](https://github.com/NotNotTech/Raylib-CsLo) |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |

[![Nuget Package](https://img.shields.io/badge/Nuget_Package-blue?logo=NuGet)](https://www.nuget.org/packages/Raylib-CsLo)
[![Source Code](https://img.shields.io/badge/Source_Code-black?logo=GitHub)](https://github.com/NotNotTech/Raylib-CsLo)
[![Source Code](https://img.shields.io/badge/🚀_100+_Examples_🚀-teal)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)
![.NET 5+](https://img.shields.io/badge/.NET-net5+-%23512bd4)
[![Chat on Discord](https://img.shields.io/badge/chat%20on-discord-7289DA)](https://discord.gg/raylib)

# Table of Contents

- [Table of Contents](#table-of-contents)
- [Mac M1 is now supported](#mac-m1-is-now-supported)
- [About](#about)
  - [What is **Raylib**?](#what-is-raylib)
  - [Super easy to use for 2d](#super-easy-to-use-for-2d)
  - [High performance for 3d! (but `unsafe` to use)](#high-performance-for-3d-but-unsafe-to-use)
- [How to use/install](#how-to-useinstall)
  - [via Nuget](#via-nuget)
  - [via sources](#via-sources)
- [Linux / OsX / other platform support](#linux--osx--other-platform-support)
- [Examples](#examples)
- [Differences from `Raylib-Cs`](#differences-from-raylib-cs)
- [Extras (1st person, 3rd person cameras)](#extras-1st-person-3rd-person-cameras)
- [Usage Tips, FAQ](#usage-tips-faq)
- [Known Issues](#known-issues)
- [TROUBLESHOOTING your game](#troubleshooting-your-game)
  - [Frame stutters, hitching, spikes](#frame-stutters-hitching-spikes)
- [How to Contribute](#how-to-contribute)
- [Want to build from scratch?](#want-to-build-from-scratch)
  - [yoink the native binary instead](#yoink-the-native-binary-instead)
- [License options: MPL or PCL](#license-options-mpl-or-pcl)
  - [Mozilla Public License 2\_0 (**MPL**)](#mozilla-public-license-2_0-mpl)
  - [Private Commercial License (**PCL**)](#private-commercial-license-pcl)
- [ChangeLog](#changelog)

# Mac M1 is now supported
`v4.2.0.5` should now include full osx support, both x64 and arm64, which includes supporting the M1.   
If you test on the M1 and have problems, please raise an issue.

# About

Managed C# bindings to `Raylib`, a friendly 2d/3d game framework similar to XNA / MonoGame.

- Win/Linux/OsX supported.
- All Raylib features, including Extras bindings
  - `raylib` : Core features, including Audio.
  - `rlgl` : OpenGl abstraction
  - `raygui` : An Imperitive Gui
  - `physac` : A 2d physics framework
  - `easings` : for simple animations  (Managed Port)
  - `raymath` : game math library (Managed Port)
- Minimal bindings + convenience wrappers to make it easier to use.
- Tested and verified **ALL** 100+ Raylib examples.  These [ported examples are available to you in the GitHub Repo](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)
- Requires `unsafe` for 3d workflows.
- Supports `net5+`, `Mono 6.4+`, `NetCore3+` (via `netStandard 2.1`)
- Tested on `Win10`.  User Reports `Arch` Linux works.  Please test on other platforms and [raise an issue](https://github.com/NotNotTech/Raylib-CsLo/issues) if any problems occur.
- A focus on performance.  No runtime allocations if at all possible.
- No intellisense docs. [read the raylib cheatsheet for docs](https://www.raylib.com/cheatsheet/cheatsheet.html) or [view the 100+ examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)
- Full source code included in [The GitHub Repository](https://github.com/NotNotTech/Raylib-CsLo), including native sources, allowing you to compile for any platform you wish.
- [A Nuget package is avalable](https://www.nuget.org/packages/Raylib-CsLo)

## What is **Raylib**?

[Raylib](https://www.raylib.com/) is a friendly-to-use game framework that includes basic scenarios to meet your needs:   audio, 2d, 3d, fonts, animation, 2d physics.  Somewhat similar to `Xna` or `MonoGame` but friendlier.  **However, `Raylib` is a C/CPP framework**.  `Raylib-CsLo` is a C# Wrapper over the top, which lets you gain raylib's powers to quickly prototype your game ideas.

## Super easy to use for 2d

If you stick with 2d, you don't need to use any `unsafe` (pointer) code, which lets 2d users feel at home and use `Raylib-CsLo` as an awesome 2d game framework.

## High performance for 3d! (but `unsafe` to use)

3d in `CsLo` requires the `unsafe` keyword.  If you use 3d, you need to understand a bit of how pointers work. Raylib uses these to link things like `Model`, `Mesh`, and `Material`.  Writing wrappers over these is possible but it would basically be creating a an entirely new framework.  I suggest leaving this as-is, as it avoids object allocation (GC Pressure).

Additionally, 3d users: **Be sure you check the Usage Tips section below**, especially on how you need to use `Matrix4x4.Transpose()` when sending matricies to Raylib.

# How to use/install

## via Nuget

1. add the latest version of [The Raylib-CsLo Nuget Package](https://www.nuget.org/packages/Raylib-CsLo) to your project
2. Create an example project using it, the following code is coppied from [The StandAlone Example's Program.cs](https://github.com/NotNotTech/Raylib-CsLo/tree/main/StandaloneExample/program.cs)

```cs
using Raylib_CsLo;

namespace StandaloneExample
{
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
    Raylib.ClearBackground(Raylib.SKYBLUE);
    Raylib.DrawFPS(10, 10);
    Raylib.DrawText("Raylib is easy!!!", 640 , 360, 50, Raylib.RED);
    Raylib.EndDrawing();
   }
   Raylib.CloseWindow();
  }
 }
}
```

## via sources

1. clone/download the [github repository](https://github.com/NotNotTech/Raylib-CsLo)
2. open `./Raylib-CsLo-DEV.sln` in Visual Studio 2022.
3. build and run.
   - the `Raylib-CsLo.Examples` project will run by default, and will run through all (aprox 100+) examples.
4. For a stand-alone example that uses the Nuget Package, see the [`./StandaloneExample` folder](https://github.com/NotNotTech/Raylib-CsLo/tree/main/StandaloneExample)

# Linux / OsX / other platform support

The following platforms are shipped in the nuget package:

- `win-x64` : confirmed working on `Win10, x64`.  This is the platform used for dev/testing of `raylib-cslo`.
- `linux-x64`: confirmed working on `Arch` Linux.  Binaries built under `Ubuntu 20.04` so that shold also work.
- `osx-x64`:  not confirmed yet.  Please let me know if you try.

You can build the native binaries for whatever platform you need.  Please see the readme under <https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo/runtimes> for more info.

# Examples

Here are links to most the examples.

| [`Core`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Core/)                                                 | [`Shapes`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shapes/)                                                   | [`Textures`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Textures/)                                                     | [`Text`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Text/)                                                 | [`Models`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Models/)                                                   | [`Shaders`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shaders/)                                                    | [`Audio`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Audio/)                                                  | [`Physics`](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Physics/)                                                    |
| -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Core/examples-core-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Core) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Shapes/examples-shapes-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shapes) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Textures/examples-textures-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Textures) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Text/examples-text-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Text) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Models/examples-models-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Models) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Shaders/examples-shaders-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shaders) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Audio/examples-audio-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Audio) | [![Ex1](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Physics/examples-physics-1.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Physics) |
| [![Ex2](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Core/examples-core-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Core) | [![Ex2](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Shapes/examples-shapes-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shapes) | [![Ex2](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Textures/examples-textures-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Textures) | [![](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Text/examples-text-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Text)    | [![Ex2](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Models/examples-models-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Models) | [![Ex2](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Shaders/examples-shaders-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Shaders) | [![](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Audio/examples-audio-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Audio)    | [![](https://raw.githubusercontent.com/NotNotTech/Raylib-CsLo/main/Raylib-CsLo.Examples/Physics/examples-physics-2.png)](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples/Physics)    |

# Differences from `Raylib-Cs`

| [`Raylib-Cs`](https://github.com/ChrisDill/Raylib-cs)               | `Raylib-CsLo`                                                                                                                                                                     |
| ------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ***An artisanal, bespoke binding+wrapper.***                  | ***A cold, calculating robo-binding.***                                                                                                                       |
| Each binding is hand crafted with carefull design                   | Exact Bindings (Autogen) with wrappers to make C# usage nice.                                                                                                                     |
| Bindings for `Raylib` and extras `RayMath`, `RlGl`.                 | Bindings for `Raylib` and all extras (`RayGui`, `Easings`, `Physac`, `RlGl`, `RayMath`)                                                                                           |
| Optimized for normal C# usage                                       | Optimized for maximum performance and might require `unsafe`                                                                                                                           |
| New Raylib version? Harder to detect breaking changes               | New Raylib version? Breaking changes are easy to spot and fix                                                                                                                     |
| includes Intellisence docs                                          | No docs.  Use the [Cheatsheet](https://www.raylib.com/cheatsheet/cheatsheet.html) /          [Examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples) |
| Born 2018-07                                             | Born 2021-11                                                                                                                                              |
| [Lots of examples](https://github.com/ChrisDill/Raylib-cs-Examples) | [ALL 100+ Raylib examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)                                                                              |
| zlib Licensed                                                       | MPL 2.0 Licensed                                                                                                                                                          |
| [Nuget Package](https://www.nuget.org/packages/Raylib-cs/)          | [Nuget Package](https://www.nuget.org/packages/Raylib-CsLo)                                                                                                                       |
| Raylib 4.0                                                 | Raylib 4.2                                                                                                                                                                      |
| lots of contribs                                                    | few contribs                                                                                                                                                                |

# Extras (1st person, 3rd person cameras)

If you need a custom camera, check out the `Raylib-Extras-CsLo` project, which contains a custom First Person Camera and Third Person Camera.  <https://github.com/NotNotTech/Raylib-Extras-CsLo>

# Usage Tips, FAQ

- **How do I do `SOME_IDEA`?**
  - All the Raylib examples (100+) have been ported successfully.  Please refer to them here: [ALL 100+ Raylib examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples).  If you need more help, ask on Discord.
- **Does `Raylib-CsLo` include the `SOME_FUNCTION_YOU_NEED()` function?**
  - Raylib-CsLo has bindings for everything in the Raylib 4.0 release, including extras like `raygui` and `physac`, but with the exception of things in the `Known Issues` section further below.
- **Why didn't you add a wrapper for function `SOME_OTHER_FUNCTION_YOU_NEED()`?**
  - Raylib-CsLo uses a manual marshalling technique, as the built in PInvoke marshalling is not very efficienct.  Most API's have wrappers (and all involving `string` marshalling), but some involving pointers have been left as-is.  If you come across a function that you feel needs more wrapping, you can [raise an issue](https://github.com/NotNotTech/Raylib-CsLo/issues) or perhaps [submit a PR](https://github.com/NotNotTech/Raylib-CsLo/pulls)
- **How do I convert a string to `sbyte*` or vice-versa?**
  - All API's that take `sbyte*` have `string` wrappers, so be sure to look at the overload you can call.
- **Do I have to really cast my Enum to `int`?**
  - The autogen bindings are left untouched, however convenience wrappers are added.  Usually these will automagically "work" via function overloads, but where this is not possible, try adding an underscore `_` to the end of the function/property.  For example:  `Camera3D.projection_ = CameraProjection.CAMERA_ORTHOGRAPHIC;` or `Gesture gesture = Raylib.GetGestureDetected_();`.
  - If all else fails, yes.  Cast to `(int)`.
- **I ran the examples in a profiler.   What are all these `sbyte[]` arrays being allocated?**
  - A pool of `sbyte[]` is allocated for string marshall purposes, to avoid runtime allocations.
- **Can I, Should I use `RayMath`?**
  - `Raylib_CsLo.RayMath` contains a lot of super helpful functions for doing gamedev related maths.
  - The `RayMath` helper functions have been translated into C# code.   This makes the code pretty fast, but if the same function exists under `System.Numerics` you should use that instead, because the DotNet CLR treats things under System.Numerics special, and optimizes it better.
- **Why are my matricies corrupt?**
  - Raylib/OpenGl uses column-major matricies, while dotnet/vulkan/directx uses row-major.  When passing your final calculated matrix to raylib for rendering, call `Matrix4x4.Transpose(yourMatrix)`

# Known Issues

- `Audio`: **v4.2 Regression Bug**.  There is a state corruption bug in the *native* audio subsystem if you dispose of streaming audio.  You may encounter this if you use multiple windows and audio streaming. see this [tracking issue](https://github.com/NotNotTech/Raylib-CsLo/issues/22) for more info.
- `RayGui`: be sure to call `RayGui.GuiLoadStyleDefault();` right after you `InitWindow()`.  This is needed to initialize the gui properly.  If you don't, if you close a raylib window and then open a new one (inside the same app), the gui will be broken.
- The `Text.Unicode` example doesn't render unicode properly.  Maybe the required font is missing, maybe there is a bug in the example (Utf16 to Utf8 conversion) or maybe there is a bug in Raylib.  A hunch: I think it's probably due to the fonts not including unicode characters, but I didn't investigate further.
- Native Memory allocation functions are not ported:  use `System.Runtime.InteropServices.NativeMemory.Alloc()` instead
- `LogCustom()` is ported but doesn't support variable length arguments.
- `Texture2D` doesn't exist.  it is just an alias for `Texture` so use that instead.  You might want to use `using` aliases like the following

      ```cs
      //usings to make C# code more like the raylib cpp examples.   
      //to see more stuff like this, look at Raylib-CsLo.Examples/program.cs
      global using Camera = Raylib_CsLo.Camera3D;
      global using RenderTexture2D = Raylib_CsLo.RenderTexture;
      global using Texture2D = Raylib_CsLo.Texture;
      global using TextureCubemap = Raylib_CsLo.Texture;
      global using Matrix = System.Numerics.Matrix4x4;
      ```

# TROUBLESHOOTING your game

## Frame stutters, hitching, spikes

- Make sure the Garbage Collector isn't overwhelmed
- Ensure your graphic drivers are up to date
- **If using an Nvidia card**, read this: <https://stackoverflow.com/questions/36959508/nvidia-graphics-driver-causing-noticeable-frame-stuttering>
  - TLDR: Poor driver support for OpenGl games.  In your driver settings, turn "Threaded Optimization" to `OFF`.

# How to Contribute

0) assume you are using Visual Studio (or maybe rider?) and can run `dev.sln`
1) fork the repo, build and try out the example project
2) Pick something to do

- test/improve support on linux and/or OsX
- improve wrappers for ease of use
- ????  check issues

# Want to build from scratch?

check out the readme under the `binding-gen` folder

## yoink the native binary instead
If there is a platform that doesn't work due to no native binary being shipped with the Raylib-CsLo nuget package, 
you should just be able to yoink the official raylib native library [...like from here](https://github.com/raysan5/raylib/releases/tag/4.2.0) and if it's put in the right folder location (output folder), 
raylib-cslo can use it, assuming it's named properly.   If you do this you need to be aware that the various raylib-extras will not be available, but everything else should work.

# License options: MPL or PCL

## Mozilla Public License 2_0 (**MPL**)

By default, this repository is licensed under the [Mozilla Public License 2.0 (**MPL**)](https://github.com/NotNotTech/Raylib-CsLo/blob/main/LICENSE).  The MPL is a popular "weak copyleft" license that allows just about anything.  **For example, you may use/include/static-link this library in a commercial, closed-source project without any burdens.**    The main limitation of the MPL being that: ***Modifications to the source code in this project must be open sourced***.  

The MPL is a great choice, both by providing flexibility to the user, and by encouraging contributions to the underlying project.  If you would like to read about the MPL, **FOSSA** has [a great overview of the MPL 2.0 here](https://fossa.com/blog/open-source-software-licenses-101-mozilla-public-license-2-0/).

## Private Commercial License (**PCL**)

If for some reason you or your organization really, ***REALLY*** can not open source your modifications to this project, I am willing to offer a PCL for USD $1000, half of which will be donated to the upstream `raylib` project.  Payment can be made via github donations.  Yes $1000 is a lot of money, so just try to accept the MPL terms and move on with life!
If you still think a PCL is what you need, raise an issue or email JasonS aat Novaleaf doot coom to discuss.

# ChangeLog

changelog for major releases.

- **4.2.0.5**  (2023/01/31): Includes Mac arm64 (M1) binaries (Thanks `Shpendicus`).
- **4.2.0.3**  (2022/09/22): Includes Mac x64 binaries (Thanks `Shpendicus`).
- **4.2.0**  (2022/09/20): Includes Linux binaries (Thanks `Peter0x44`).
- **4.2.0-alpha1**  (2022/09/19):
  - fix marshalling of null strings passed to native code.  was marshalling as empty strings but instead should have been marshalling as NULL.   fixed.  see <https://github.com/NotNotTech/Raylib-CsLo/issues/20>
- **4.2.0-alpha0**  (2022/09/19): Update to `Raylib4.2`. Bugs:
  - ~~Native binaries only build for Win_x64.  No binaries for linux or osx.  Use the `4.0` nuget package until someone contribs the Raylib native build for those platforms.~~ (fixed 4.2.0.3)
  - *[Raylib Native Regression Bug]* Memory corruption in the Streaming Audio system.  Causes corruption of Native Raylib state upon closing a streaming session.   This is a bug in the native code, so we need to await an upstream fix.   see <https://github.com/raysan5/raylib/issues/2714>
- **4.0.0-rc.5.0** (2021/12/15):  No breaking changes. Broaden DotNet support to Net5+, etc (via NetStandard 2.1)
- **4.0.0-rc.4.0** (2021/12/04):  No breaking changes. Cleanup and change license from LGPL to MPL, because LGPL doesn't allow private static linking.
- **4.0.0-rc.3** (2021/11/29):  No breaking changes.  Improve Boolean Marshalling.  
- **4.0.0-rc.2** (2021/11/28):  Rollup all native code into single binary.  Improve bindings compat.  
- **4.0.0-rc.1** (2021/11/24):  Support for Linux and OsX (hopefully).
- **4.0.0-rc.0** (2021/11/22):  `physac.dll` and bindings for it added.  `Physics` and `Audio` examples ported.   All `raylib` examples complete!
- **4.0.0-beta.2** (2021/11/22):  `RayGui`, and `Easings` Raylib.extras ported to managed code. `Shapes`,`Textures`, and `Text` examples ported.
- **4.0.0-beta.0** (2021/11/20):  `Model`, and `Shader` examples ported.
- **4.0.0-alpha.2** (2021/11/18):  Model examples ported. AutoGen Bindings expanded to include all api's exposed by Raylib.dll (adding `RayMath`, `RlGl`)
- **4.0.0-alpha.1** (2021/11/16):  all `Core` examples ported, so "feature complete" for the workflows used in those examples (and, complete only for those workflows)

<!-- [![Commit Activity](https://img.shields.io/github/commit-activity/m/NotNotTech/Raylib-CsLo)](https://github.com/NotNotTech/Raylib-CsLo/graphs/contributors) -->