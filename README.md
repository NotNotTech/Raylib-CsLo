<h1 align="center">
    <a href="#"><img align="center" src="meta/logos/raylib-cslo_128x128.png" height="96"> Raylib-CsLo</a>
    <br />
</h1>


<div align="center">


![Status ALPHA](https://img.shields.io/badge/status-ALPHA-orange)
[![Commit Activity](https://img.shields.io/github/commit-activity/m/NotNotTech/Raylib-CsLo)](https://github.com/NotNotTech/Raylib-CsLo/graphs/contributors)
![.NET 6.0](https://img.shields.io/badge/.NET-net6.0-%23512bd4)
[![Chat on Discord](https://img.shields.io/badge/chat%20on-discord-7289DA)](https://discord.gg/raylib)

</div>

# Raylib-CsLo
LowLevel autogen bindings to Raylib 4.0 and convenience wrappers on top.  


- Requires use of `unsafe`
- A focus on performance.  No runtime allocations if at all possible.
- because these are autogen, there won't be any intellisense docs. [read the raylib cheatsheet for docs](https://www.raylib.com/cheatsheet/cheatsheet.html)

# Table of Contents


- [Raylib-CsLo](#raylib-cslo)
- [Table of Contents](#table-of-contents)
- [🚧🚨🚧 UNDER CONSTRUCTION 🚧🚨🚧](#-under-construction-)
  - [Release timeline](#release-timeline)
    - [`ALPHA`](#alpha)
    - [`BETA`](#beta)
    - [`RELEASE`](#release)
- [Differences from `raylib-cs`](#differences-from-raylib-cs)
- [Usage Tips / FAQ](#usage-tips--faq)
- [How to Contribute](#how-to-contribute)

# 🚧🚨🚧 UNDER CONSTRUCTION 🚧🚨🚧
Currently the bindings work, but because these are bare-bones, autogen bindings, they are not user friendly, even for `unsafe` use.
Right now only the [Core Examples have been ported](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples).

## Release timeline


### `ALPHA`
- **The current status.**
- A Nuget package will be released at that time.
- All the [core examples](https://www.raylib.com/examples.html) are ported. This ensures a minimal set of convenience wrappers are in place, so things don't get too miserable.

### `BETA`
- Triggered when the `model` and `shaders` examples are ported. 


### `RELEASE`
- Triggered when all examples are ported.  You can contribute to make this happen.
# Differences from `raylib-cs`



| [`raylib-cs`](https://github.com/ChrisDill/Raylib-cs)                   | `raylib-cslo`                                                                                                                                                                         |
| ----------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| each binding is hand crafted with carefull design                       | Autogen with wrappers to make the raylib examples work (with minimal changes).  Bindings not used in examples will probably be painful to use (example: convert `sbyte*` to strings). |
| Optimized for normal C# usage                                           | Optimized for maximum performance and requires `unsafe`                                                                                                                               |
| New Raylib version? Harder to detect breaking changes                   | New Raylib version? Breaking changes are easy to spot and fix                                                                                                                         |
| includes Intellisence docs                                              | No docs.  Use the [Cheatsheet](https://www.raylib.com/cheatsheet/cheatsheet.html)                                                                                                     |
| has a long track record                                                 | didn't exist till mid november 2021!                                                                                                                                                  |
| [has lots of examples](https://github.com/ChrisDill/Raylib-cs-Examples) | [only the Core examples](https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo.Examples)                                                                                    |
| zlib licensed                                                           | lgpl licensed                                                                                                                                                                         |
| [Nuget Package](https://www.nuget.org/packages/Raylib-cs/)              | just this repo right now                                                                                                                                                              |
| Stable                                                                  | in development                                                                                                                                                                        |
| Works with various dotnet flavors?                                      | Focus on DotNet6.0                                                                                                                                                                    |
| lots of contribs                                                        | just little 'ol me                                                                                                                                                                    |


# Usage Tips / FAQ
- **Is there a wrapper for this function?  or do I have to really cast my Enum to `int`?**
  -  The autogen bindings are left untouched, however convenience wrappers are added.  Usually these will automagically "work" via function overloads, but where this is not possible, try adding an underscore `_` to the end of the function/property.  For example:  `Camera3D.projection_ = CameraProjection.CAMERA_ORTHOGRAPHIC;` or `Gesture gesture = Raylib.GetGestureDetected_();`
-  **I ran the examples in a profiler.   What are all these `sbyte[]` arrays being allocated?**
   -  A pool of `sbyte[]` is allocated for string marshall purposes, to avoid runtime allocations.
- **Why don't you add wrappers for the Math helpers?**
  - crossing between Managed and Native code isn't free.  Better you do all your maths in managed code, and pass the final result to raylib.
- **Why are my matricies corrupt?**
  - Raylib/OpenGl uses column-major matricies, while dotnet/vulkan/directx uses row-major.  When passing your final calculated matrix to raylib for rendering, call `Matrix4x4.Transpose(yourMatrix)`


# How to Contribute

0) assume you are using Visual Studio (or maybe rider?) and can run `dev.sln`
1) fork the repo, build and try out the example project
2) Look at how a lot of the raylib functions used in the core examples have convenience wrappers.
3) Pick one of the raylib example groups not being worked on, and let novaleaf know either on discord or via an [issue](https://github.com/NotNotTech/Raylib-CsLo/issues)
4) port the example group, following the general design as the core examples.


| example group | contrib doing port | done? |
| ------------- | ------------------ | ----- |
| core          | novaleaf           | [x]   |
| shapes        |                    | [ ]   |
| textures      |                    | [ ]   |
| text          |                    | [ ]   |
| models        |                    | [ ]   |
| shaders       |                    | [ ]   |
| audio         |                    | [ ]   |
| physics       |                    | [ ]   |
