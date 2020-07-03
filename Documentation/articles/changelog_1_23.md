# 1.22

**Released on: 03/07/2020**

Key changes:

- Improved Image asset API.
- Fixed bug with UI elements getting collected while still having callbacks on them.

All Changes:

- Stored active scene inside Game manager to make sure it won't be collected by GC (should not normally happen but added just in case).
- Added method to save image asset.
- Added method to get pixel from image asset.
- Stored child elements in UI elements to make sure they won't get collected by GC while they still have callbacks on them.
- Extended Color API - added properties as bytes and ToString() + Cornflower.