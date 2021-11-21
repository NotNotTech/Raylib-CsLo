# `Raylib-CsLo` Examples

These examples are direct ports of the original `raylib 4.0` examples, with as few modifications made to the original sources as possible.

Some important notes if you want to run/use/copy these examples:
- DotNet 6 `global using`
  - Refer to the top of `Program.cs` to see the various `using` statements.  This allows C# to emulate the scopes used by the original C examples, which lets us make minimal changes to the C code.
- Run this project to see all examples run in order.   you can simply comment out examples you don't want in the `Program.cs` file
- For Math/ConsolePrint/DateTime/FileIo, it would be better that you don't follow the examples, but rather "normal" dotnet workflows like using `System.Io.File` or math helpers found directly in `System.Numerics`.  Invoking native code is relatively expensive, adding perhaps `0.01ms` per call.  These native invokes were left as-is so that the original C code could be used with minimal changes.





# Porting examples
Here are guidelines for porting examples

- put each example group in it's own folder/namespace
  - see `Core`,`Models`,`Shaders` for an example
  - 


## recipies for porting examples

for translating the C code, here are search-replace regex used (via `VsCode`)

should be applied in order, as former transforms impact later

- convert `#define`
  - example: `#define MAX_BUNNIES        50000`
  - search: `#define (\w+)\s+(\w+)`
  - replace: `const int $1 = $2;`
- partial string replacement
  - search: `char (\w+)\[(\w+)\] = "(.+)\\0"`
  - replace `string $1 = $"$3"`
- class definition
  - search `#include "raylib.h"`
  - replace `public unsafe static class TEMPLATE {`
- class end
  - search `    return 0;`
  - replace `    return 0; }`
- main function
  - search `int main(void)`
  - replace `public static int main()`
- struct declaration
  - example: `(Vector2){ scrollingBack, 20 }`
  - search `\((\w+)\)\{(.+?)\}`
  - replace `new $1($2)`
- arrays
  - example:`const Color colors[] =`
  - search `const (\w+) (\w+)\[\] =`
  - replace `$1[] $2 = new $1[]`
- arrays
  - example:`Rectangle colorRec[MAX_COLORS] = { 0 }`
  - search `(\w+) (\w+)\[(\w+)\] = \{ 0 \}`
  - replace `$1[] $2 = new $1[$3]`
- struct declaration
  - example: `Vector2 position = { (float)(screenWidth / 2 - texture.width / 2), (float)(screenHeight / 2 - texture.height / 2 - 20) };`
  - search `\((\w+)\)\{(.+?)\}`
  - replace `$1 $2 = new $1($3)`
- arrays
  - example:`Color colors[MAX_COLORS_COUNT] =`
  - search `(\w+\s*) (\w+)\[(\w+)\] =`
  - replace `$1[] $2 = new $1[$3]`
- struct ctor
  - example: `Rectangle btnSaveRec = { 750, 10, 40, 30 }`
  - search: `(\w+\s*) (\w+\s*) = \{(\s*?\w+?\s*?)\}`
  - replace: `$1 $2 = new $1($3)`
- struct ctor
  - example: `Rectangle btnSaveRec = { 750, 10, 40, 30 }`
  - search: `(\w+\s*?) (\w+\s*?) = \{(.*?)\}`
  - replace: `$1 $2 = new $1($3)`
- struct ctor
  - example: `(Rectangle) {`
  - search: `\((\w+)\) \{`
  - replace: `new $1(`
- alloc
  - example: `Color* pixels = (Color*)malloc(width * height * sizeof(Color));`
  - search:``