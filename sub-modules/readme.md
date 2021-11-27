# Sub-Modules

external resources needed for creating bindings.

-`./ClangSharp` is a git sub-module pointing to https://github.com/microsoft/clangsharp Used to generate bindings from `.h` files. [It's docs for GenerateBindings](https://github.com/microsoft/clangsharp#generating-bindings) might be useful to read
- `Premake` is a C helper to generate c projects for raylib helpers, visual studio to compile.   general help for using it here: https://github.com/raysan5/raylib/wiki/Easy-Raylib-Setup-for-Windows-with-Visual-Studio
- `./Raylib` is a git sub-module pointing to https://github.com/raysan5/raylib  used for generating the `raylib.dll` used for binding to.
- The `physac` and `raygui` folders are vc projects generated from `premake`, needed to create the `physac.dll` and `raygui.dll` files binded to.



build notes
- install wsl stuff: https://docs.microsoft.com/en-us/windows/wsl/tutorials/gui-apps
  - https://developer.nvidia.com/cuda/wsl



- needed:
  - `sudo apt install libx11-dev libxcursor-dev libxrandr-dev libxi-dev mesa-common-dev libglu1-mesa-dev`  from https://stackoverflow.com/questions/5299989/x11-xlib-h-not-found-in-ubuntu
  - still didn't work, but this issue on `glfw` mentions:
    - `sudo apt install libgl1-mesa-dev xorg-dev`
      - https://github.com/go-gl/glfw/issues/158
  - above worked
  - build via ubuntu WSL `make config=release.dll_x64`
  - 