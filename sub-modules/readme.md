# Sub-Modules

external resources needed for creating bindings.

-`./ClangSharp` is a git sub-module pointing to https://github.com/microsoft/clangsharp Used to generate bindings from `.h` files. [It's docs for GenerateBindings](https://github.com/microsoft/clangsharp#generating-bindings) might be useful to read
- `Premake` is a C helper to generate c projects for raylib helpers, visual studio to compile.   general help for using it here: https://github.com/raysan5/raylib/wiki/Easy-Raylib-Setup-for-Windows-with-Visual-Studio
- `./Raylib` is a git sub-module pointing to https://github.com/raysan5/raylib  used for generating the `raylib.dll` used for binding to.
- The `physac` and `raygui` folders are vc projects generated from `premake`, needed to create the `physac.dll` and `raygui.dll` files binded to.