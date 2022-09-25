
# `Audio` EXAMPLES

Please see the various `*.cs` files inthis folder for complete examples.  However, please note that these examples require the `global using` statements found in the `../Program.cs` file to run properly.   The easiest way to run them is to just comment out the examples you don't want, and run the example project.


## `4.2.x` BUG!
*[Raylib Native Regression Bug]* Memory corruption in the Streaming Audio system.  Causes corruption of Native Raylib state upon closing a streaming session.   This is a bug in the native code, so we need to await an upstream fix.   see <https://github.com/raysan5/raylib/issues/2714>

## pics

Here are thumbnails of the examples included in this folder:


![Examples Part 1](./examples-audio-1.png)