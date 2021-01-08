# 1.5.1

**[09/01/2021]**

Key Changes:

- Huge refactor that now the engine works only on OpenGL with custom default effect without using SDL default. This solves a lot of issues when trying to mix custom shaders with SDL default rendering pipeline.

All Changes:

- Setting music volume to 0 used to call StopMusic(). Changed this behavior as setting music volume to 0 is not the same as stopping it and have different use cases.
- Setting channel volume to 0 used to call StopChannel(). Changed this behavior as setting sound volume to 0 is not the same as stopping it and have different use cases.
- Added method to draw 2d polygons.
- Added new blend modes.
- Added music fader utility.
- Added rotation and origin to rectangles.