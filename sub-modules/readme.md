# Sub-Modules

# summary
Source code for the Native binaries, and build system for Windows, Linux.
This folder started out as containing git sub-modules, which it still does, but also now contains needed build system files, which is needed to build `raylib-with-extras`.




# folder structure
external resources needed for creating bindings.

- `./ClangSharp/` is a git sub-module pointing to https://github.com/microsoft/clangsharp Used to generate bindings from `.h` files. [It's docs for GenerateBindings](https://github.com/microsoft/clangsharp#generating-bindings) might be useful to read
- `./premake.*` is a C helper to generate c projects for raylib helpers, visual studio to compile.   general help for using it here: https://github.com/raysan5/raylib/wiki/Easy-Raylib-Setup-for-Windows-with-Visual-Studio
- `./raylib/` is a git sub-module pointing to https://github.com/raysan5/raylib  used for generating the `raylib-with-extras` native binary, mentioned next.
- `./physac/` and `./raygui/` are git sub-modules for raylib extra features.
- The `./raylib-with-extras/` folder contains the build system files needed to create a version of `raylib` that includes the `physac` and `raygui` extras, as these are not included in the default `raylib` binary.


# building `raylib-with-extras` binary for your platform

- build projects for `vs2022`, `linux make`  and `osx xcode` can be found in this folder

- When you build, the compiled native binaries should be put in their respective folder under https://github.com/NotNotTech/Raylib-CsLo/tree/main/Raylib-CsLo/runtimes

- first, run the `./regen-native-projects.ps1` to create the native projects.  Then build, and copy the library to the associated `../Raylib-CsLo/runtimes` folder.

## windows build notes
- if the raylib (cpp) project structure changes (such as what happened for raylib 4.2) you might need to regenerate the windows solution.   re-run the `regen-native-projects.ps1`.  This will generate a new visual studio solution that you can build normally.
- after building, copy the raylib.dll/pdb to the runtimes folder, and root of raylib-cslo project folder too (for local debug).  also be sure to CLEAN output folders in VS to use the new dll!"

## LINUX build notes
- if on windows, can open this folder in WSL or container, then do the following steps.  (VSCode makes opening in wsl/container easy!)

- needed to build for linux:
  - `sudo apt update`
  - `sudo apt upgrade`
  - `sudo apt install gcc make g++` 
  - `sudo apt install libx11-dev libxcursor-dev libxrandr-dev libxi-dev mesa-common-dev libglu1-mesa-dev`
  - `sudo apt install libgl1-mesa-dev xorg-dev`
  - `cd raylib/src`
  - `make RAYLIB_LIBTYPE=SHARED RAYLIB_MODULE_RAYGUI=TRUE RAYLIB_MODULE_PHYSAC=TRUE`
  - verify shared lib was built ok by inspecting the output of `nm libraylib.so.4.2.0`
  


# dev notes
these are just notes for use doirn develoment...  please ignore unless you run into problems

- listing of RID's: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
- seems that WSL (linux on windows) can support gui apps on win11.  if you are interested in figuring this out: https://docs.microsoft.com/en-us/windows/wsl/tutorials/gui-apps
  - https://developer.nvidia.com/cuda/wsl