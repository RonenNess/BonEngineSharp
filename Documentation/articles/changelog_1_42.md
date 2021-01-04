# 1.4.2

**[TBD]**

Key Changes:

- Added music fader utility.
- Changed default flags to prefer OpenGL by default.
- Changed default flags to enable effects by default.

All Changes:

- Setting music volume to 0 used to call StopMusic(). Changed this behavior as setting music volume to 0 is not the same as stopping it and have different use cases.
- Setting channel volume to 0 used to call StopChannel(). Changed this behavior as setting sound volume to 0 is not the same as stopping it and have different use cases.
- Changed default flags to prefer OpenGL by default.
- Changed default flags to enable effects by default.
- Added method to draw 2d polygons.