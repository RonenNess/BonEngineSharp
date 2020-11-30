# 1.3.5

**[30/11/2020]**

Key Changes:

- Added option to override cursor position in UI manager.
- Added Columns mechanism to UI elements (`CreateColumn()` method).
- Added UI Rectangle element.

All Changes:

- Added way to query UI element size in pixels.
- Made UI elements calculate dest rect as soon as they are added to parent, so we can query them before an Update call.
- Fixed CAPI to set UI element margin.
- Fixed scrollbar when render target is smaller than screen size + made scrollbar smoother.
- Added built-in Orange color.
- Misc quality of life UIElement methods.