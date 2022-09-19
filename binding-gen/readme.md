# Binding-Gen
scripts to generate bindings from various `.h` files, leveraging the `ClangSharp` source generators.

how to run:
- checkout the submodules from `../sub-modules`
- run `./regen.ps1`


# how to build everything (including native dll) from scratch

1. follow instructions under the root's `/sub-modules` folder
   - on windows:  run `premake` then build the native dll from visual studio
1. build the Raylib Native DLL successfully, under `../sub-modules/`
   - on windows:  run `premake` then build the native dll from visual studio.  that will output `sub-modules\raylib-with-extras\bin\Release.DLL\raylib-with-extras.dll`
1. copy the built library to it's associated folder under `/Raylib-CsLo/runtimes/`, which is needed for nuget package bundling.  
   - also copy the library to the `/Ralylib-CsLo/` project folder so that when you run the code locally it can use the right library.
1. run the binding generation code as described above (run `./regen.ps1`)


