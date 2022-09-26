# Raylib-CsLo
This project contains:
- the auto generated bindings from the `../binding-gen` workflow
- convenience wrappers + helpers for using those bindings
- native dll's generated via the `../sub-modules/RaylibDLLs.sln` project
- nuget deployment script



## Notes for Nuget Package Gen
- great info here for creating cross platform packages: https://dev.to/jeikabu/nupkg-containing-native-libraries-1576



## notes regarding opengl
- windows `ARM` users may be able to install this for opengl 3.3 support: https://www.microsoft.com/en-us/p/opencl-and-opengl-compatibility-pack/9nqpsl29bfff#activetab=pivot:overviewtab
- my dev machine lags aprox 150ms every 20 seconds or so, in opengl `swapbackbuffer`  I need to try upgrading raylib to opengl 4.3 and/or the above ogl comat layer.
  - an old+weak windows laptop doesn't have the lag spike, so I suspect it's my gfx driver.  FIX:  set Nvidia driver "Thread Optimization" to FALSE
