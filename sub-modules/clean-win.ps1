" START!  will recreate windows visual studio cpp solution to build the native raylib library"

# change dir to folder containing script
pushd $PSScriptRoot

rm .\raylib-with-extras\ -Recurse
./premake5.exe vs2022

" DONE!  Now open the solution and build it, then copy the raylib.dll/pdb to the runtimes folder, and root of raylib-cslo project folder too (for local debug).  also be sure to CLEAN output folders in VS to use the new dll!"