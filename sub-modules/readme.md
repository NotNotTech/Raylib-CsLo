# Sub-Modules

# summary
Source code for the Native binaries, and build system for Windows, Linux.
This folder started out as containing git sub-modules, which it still does, but also now contains needed build system files, which is needed to build `raylib-with-extras`.




# folder structure
external resources needed for creating bindings.

- `./ClangSharp` is a git sub-module pointing to https://github.com/microsoft/clangsharp Used to generate bindings from `.h` files. [It's docs for GenerateBindings](https://github.com/microsoft/clangsharp#generating-bindings) might be useful to read
- `Premake` is a C helper to generate c projects for raylib helpers, visual studio to compile.   general help for using it here: https://github.com/raysan5/raylib/wiki/Easy-Raylib-Setup-for-Windows-with-Visual-Studio
- `./Raylib` is a git sub-module pointing to https://github.com/raysan5/raylib  used for generating the `raylib-with-extras` native binary, mentioned next.
- The `./raylib-with-extras/` folder contains the build system files needed to create a version of `raylib` that includes the `physac` and `raygui` extras, as these are not included in the default `raylib` binary.


# building `raylib-with-extras` binary for your platform

- build projects for `vs2022`, `linux make`  and `osx xcode` can be found in this folder

- When you build, the compiled native binaries should be put in their respective folder under https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo/runtimes


## rebuilding from scratch on windows
if the raylib (cpp) project structure changes (such as what happened for raylib 4.2) you might need to regenerate the windows solution.   To do so, delete the `raylib-with-extras` folder, edit the `premake5.lua`, then run `premake5.exe vs2022` .  This will generate a new visual studio solution that you can build normally.

# dev notes
these are just notes for use doirn develoment...  please ignore unless you run into problems

-- listing of RID's: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

## build notes
- install wsl stuff: https://docs.microsoft.com/en-us/windows/wsl/tutorials/gui-apps
  - https://developer.nvidia.com/cuda/wsl

- needed to build for linux:
  - `sudo apt install libx11-dev libxcursor-dev libxrandr-dev libxi-dev mesa-common-dev libglu1-mesa-dev`  from https://stackoverflow.com/questions/5299989/x11-xlib-h-not-found-in-ubuntu
  - still didn't work, but this issue on `glfw` mentions:
    - `sudo apt install libgl1-mesa-dev xorg-dev`
      - https://github.com/go-gl/glfw/issues/158
      - **It seems like maybe `xorg-dev` is all that's really needed**
  - above worked
  - build via ubuntu WSL `make config=release.dll_x64`
  - 