# 1.4.2

**[TBD]**

Key Changes:

- Added music fader utility.

All Changes:

- Setting music volume to 0 used to call StopMusic(). Changed this behavior as setting music volume to 0 is not the same as stopping it and have different use cases.
- Setting channel volume to 0 used to call StopChannel(). Changed this behavior as setting sound volume to 0 is not the same as stopping it and have different use cases.