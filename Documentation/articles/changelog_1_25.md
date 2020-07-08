# 1.25

**Released on: WIP**

Key changes:

- Fixed bug with reading non-existing key from config file.

All Changes:

- Fixed bug with reading non-existing key from config file (used to return random characters).
- Added logs to scene changing.
- Removed the "Dispose" call from scene Unload, to allow reusing scene after it was unloaded.