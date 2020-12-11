# 1.4.1

**[11/12/2020]**

Key Changes:

- Fixed bug in removing columns from UI elements.

All Changes:

- Made assets 'Path' be relative to assets root, and added 'FullPath' to represent the whole path.
- Added format validations to Point and Rectangle parsing + better error handling in SpriteSheet load.
- Fixed setting IsRecievingInput to false in TextInput UI elements.
- Added 'UseAssetsRoot' flag to Assets Manager loading methods.
- Fixed setting UIImage to null.
- Increased max section name size, max key size, and max line size in asset config.