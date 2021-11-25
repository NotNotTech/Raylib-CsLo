these files+folders contain the native raylib libraries used on various platforms, and are copped into the nuget package.

some helpful hints:

- the sub folders are named based on "Runtime Identifiers" (RID) found here: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
- this blog post explains the general workflow needed: https://dev.to/jeikabu/nupkg-containing-native-libraries-1576



# other notest

- guideline for nativer interop: https://docs.microsoft.com/en-us/dotnet/standard/native-interop/best-practices
- **how dotnet6 searches for native libraries**: https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform
  - so should do `DllImport("raylib")` and everything else works