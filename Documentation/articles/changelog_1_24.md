# 1.24

**Released on: 05/07/2020**

Key changes:

- Added TextInput element.
- Added text input API to Input manager.
- Extended all UI elements API by matching inheritance to CPP side.

All Changes:

- Made UI elements on C# side inherit from each other the same way they do in C++ side, effectively extending their API (now you can access 'UIIMage' methods from 'UIButton').
- Added Text Input element.
- Added 'active element' output param to UI updates.
- Added method to get keys assigned to action id.
- Added 'Contains' method to UI list.
- Added Text Input element.
- Fixed bug with UI text with empty string.
- Added clipboard methods to Input manager.
- Added text input methods to Input manager.
- Added word wrap flag to UI text element.