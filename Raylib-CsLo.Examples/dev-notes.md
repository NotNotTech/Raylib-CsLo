


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
  - search: `#define (\w+)\s+(.+)`
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
- strings
  - example: `char[] text = new char[64]`
  - search:``


## recipie for generating wrappers

```
example input
search
replace

any lines not including sbyte
^((?!sbyte).)*$

wrap sbyte* inputs


only string parm --> void
public static void TakeScreenshot(sbyte* fileName);
public static void (\w*)\(sbyte\* (\w+)\);
public static void $1(string $2){using var so$2 = $2.MarshalUtf8(); $1(so$2.AsPtr());}



other string params 1x
public static Boolean GuiWindowBox(Rectangle bounds, sbyte* title);
public static (\w*) (\w*)\((.*)sbyte\* (\w+)(.*)\);
public static $1 $2($3string $4$5){\nusing var so$4 = $4.MarshalUtf8();\n return $2($3so$4.AsPtr()$5);\n}

just return string
public static sbyte* GetMonitorName(int monitor);




```