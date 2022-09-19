# Binding-Gen
scripts to generate bindings from various `.h` files, leveraging the `ClangSharp` source generators.

how to run:
- checkout the submodules from `../sub-modules`
- build the Raylib Native DLL successfully
  - on windows:  run `premake` then build the native dll from visual studio.  that will output `sub-modules\raylib-with-extras\bin\Release.DLL\raylib-with-extras.dll`
- run `./regen.ps1`


# how to build everything (including native dll) from scratch

1. follow instructions under the root's `/sub-modules` folder
   - on windows:  run `premake` then build the native dll from visual studio
1. 