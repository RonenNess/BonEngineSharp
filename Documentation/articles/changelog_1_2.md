# 1.2

**Released on: 01/07/2020**

Key changes:

- Added UI system.
- Compiler version --> C++ 17.
- Improved config assets.

All Changes:

- Added UI system with basic UI elements: Element, Text, Image, Window, Button, List, Scrollbars, Slider, Checkbox, Radio button.
- Extended `SpriteSheet` API (contains animation, contains bookmark).
- Added `Lerp` function to points.
- Extended `Gfx` API to get current target size and retrieve render target.
- Added GetOption(), GetPoint(), GetColor() and GetRect() to config assets.
- Added outline to text drawing.
- Changed Rectangle::Zero to be a static const instead of method.
- Changed general game config file to use text options instead of numbers for enums.
- Fixed bug with assets cache that fonts in different sizes and images with different filters had the same key.
- Changed default compiler to C++ 17.
