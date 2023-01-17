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


# additional notes
Raylib-cslo uses ClangSharp for the autogen work.  the alternative to autogen bindings is to manually write signatures and add `[DllImport]`.  you can do that, but for big projects it's quite time consuming, plus if the native library changes signatures (new version) you don't really have any way of knowing that the signature is broken, other than your app crashing.  That's why I use autogen bindings and add a convenience wrapper over the top.  So when a new version of raylib is released, I regenerate the native bindings, then fix any build breaks with my helpers/wrappers.  Mostly I don't wrap things except for making it easy to use.  

If this is updated to a new version of ClangSharp (the version currently used is from early 2021) it may also be worth investigating simplifying the wrappers some, as IIRC dotnet7 improved native invoke so maybe some of the stuff I do to make it easy is not needed anymore (especially around string marshaling).  The reason this had to be done is raylib uses utf8, but dotnet uses utf16.



- `gen-raylib.rsp` is the config file passed to ClangSharp, so read the clangsharp docs on how those options work
- `regen.ps1` is a powershell script that does the binding gen work.   raylib has a bunch of `.h` files that have the api signatures in them.   that's why I need to go thorough them each (raylib, raymath, rlgl, etc)
  - at the end of the regen.ps1 is me fixing up the weirdness/bugs in clangsharp to make it build or have the right marshalling that I want
if you get a new version of clangharp maybe you don't need to do the last part
