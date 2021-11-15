# Raylib-CsLo
LowLevel autogen bindings to Raylib 4.0 and convenience wrappers on top.  


- Requires use of `unsafe`
- A focus on performance.  No runtime allocations if at all possible.
- because these are autogen, there won't be any intellisense docs. [read the raylib cheatsheet for docs](https://www.raylib.com/cheatsheet/cheatsheet.html)


# 🚧🚨🚧 UNDER CONSTRUCTION 🚧🚨🚧
Currently the bindings work, but because these are bare-bones, autogen bindings, they are not user friendly, even for `unsafe` use.
Right now only about 10 core examples have been ported.

## Release timeline

### `PRE-ALPHA`
- **The current status.**
- You can look around, try out the samples, but I would not recomend using it.  

### `ALPHA`
- A Nuget package will be released at that time.
- Triggered when all the [core examples](https://www.raylib.com/examples.html) are ported. This will ensure that a minimal set of convenience wrappers are in place to keep things from getting too miserable.

### `BETA`
- Triggered when the `model` and `shaders` examples are ported. 


### `RELEASE`
- Triggered when all examples are ported.  You can contribute to make this happen.


# Differences from `raylib-cs`




| `raylib-cs`                                           | `raylib-cslo`                                                                                                                  |
| ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| is hand crafted.                                      | is autogen, with convienence wrappers on top.                                                                                  |
| has docs inline and does not require unsafe           | Wrappers to make the raylib examples work with minimal changes, but other bindings not in examples will probably be neglected. |
| has a long track record                               | didn't exist till mid november 2021!                                                                                           |
| mit licensed                                          | lgpl licensed                                                                                                                  |
| New Raylib version? Harder to detect breaking changes | New Raylib version? Breaking changes are easy to spot and fix                                                                  |
| Nuget Package                                         | just this repo right now                                                                                                       |
| Stable                                                | in development                                                                                                                 |
| Works with various dotnet flavors?                    | Focus on DotNet6.0                                                                                                             |
| lots of contribs                                      | just little 'ol me                                                                                                             |


