# 1.1

**Released on: 11/06/2020**

Changes:

- Added diagnostics manager.
- Added performance test example.
- Fixed bug in `Input().Down()` for keyboard keys.
- Added `DeltaTime()` to `Game()` manager.
- Made built in colors and point values instead of functions, slightly more efficient.
- Added more built-in colors and points.
- Improved performance.
- Some validations and protections against access violation due to faulty usage.
- Removed warnings from third party files.
- Renamed DLLEXPORT to BON_DLLEXPORT, to reduce chance of collision with other libs.
- Added C API to allow binding with other languages [in progress].
- Rewrote the cached text textures mechanism to be more efficient, less code, and now text support max width, rotation and other effects.
- Added API to set rendering viewport.
- Added API to draw circles.
