# 1.4.1

**[TBD]**

Key Changes:

- Fixed bug in removing columns from UI elements.

All Changes:

- Made assets 'Path' be relative to assets root, and added 'FullPath' to represent the whole path.
- Added format validations to Point and Rectangle parsing + better error handling in SpriteSheet load.
- Fixed setting IsRecievingInput to false in TextInput UI elements.
- Added 'UseAssetsRoot' flag to Assets Manager loading methods.
- Fixed setting UIImage to null.