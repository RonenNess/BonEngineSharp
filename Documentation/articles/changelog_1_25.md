# 1.25

**Released on: 10/07/2020**

Key changes:

- Removed 'Dispose' from scene unload, to allow reusing scenes.

All Changes:

- Fixed bug with reading non-existing key from config file (used to return random characters).
- Added lots of extra logs.
- Removed the "Dispose" call from scene Unload, to allow reusing scene after it was unloaded.
- Fixed bug with list having scrollbar and then resized into not needing one.