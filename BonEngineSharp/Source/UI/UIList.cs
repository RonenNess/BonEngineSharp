using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI List element.
    /// </summary>
    public class UIList : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.List;

		/// <summary>
		/// Get list background window element.
		/// </summary>
		public UIWindow Background
		{
			get
			{
				if (_background == null)
				{
					_background = new UIWindow(_BonEngineBind.BON_UIList_Background(_handle));
					_background._releaseElementOnDispose = false;
				}
				return _background;
			}
		}
		UIWindow _background;

		/// <summary>
		/// Get / set the height, in pixels, of an item in list.
		/// </summary>
		public int LineHeight
        {
			get { return _BonEngineBind.BON_UIList_GetLineHeight(_handle); }
			set { _BonEngineBind.BON_UIList_SetLineHeight(_handle, value); }
        }

		/// <summary>
		/// Show / hide scrollbar.
		/// </summary>
		/// <param name="show">True to show scrollbar, false to hide it.</param>
		public void ShowScrollbar(bool show)
        {
			_BonEngineBind.BON_UIList_ShowScrollbar(_handle, show);
        }

		/// <summary>
		/// Add item to list.
		/// </summary>
		/// <param name="item">Item text to add.</param>
		public void AddItem(string item)
        {
			_BonEngineBind.BON_UIList_AddItem(_handle, item);
        }

		/// <summary>
		/// Remove item by text.
		/// </summary>
		/// <param name="item">Item to remove.</param>
		/// <param name="removeAll">If true, will remove all occurances of this item. If false, will only remove first item found.</param>
		public void RemoveItem(string item, bool removeAll = true)
        {
			_BonEngineBind.BON_UIList_RemoveItem(_handle, item, removeAll);
        }

		/// <summary>
		/// Return of list contains an item.
		/// </summary>
		/// <param name="item">Item to check.</param>
		/// <returns>Returns true if list contains item.</returns>
		public bool Contains(string item)
        {
			return _BonEngineBind.BON_UIList_Contains(_handle, item);
        }

		/// <summary>
		/// Remove item from list by index.
		/// </summary>
		/// <param name="index">Item index to remove.</param>
		public void RemoveItem(int index)
        {
			_BonEngineBind.BON_UIList_RemoveItemByIndex(_handle, index);
        }

		/// <summary>
		/// Clear list.
		/// </summary>
		public void Clear()
        {
			_BonEngineBind.BON_UIList_Clear(_handle);
        }

		/// <summary>
		/// Get currently selected item index, or -1 if nothing is selected.
		/// </summary>
		public int SelectedIndex => _BonEngineBind.BON_UIList_SelectedIndex(_handle);

		/// <summary>
		/// Get currently selected item text, or null if nothing is selected.
		/// </summary>
		public string SelectedItem => _BonEngineBind.BON_UIList_SelectedItem_Str(_handle);

		/// <summary>
		/// Select item by index.
		/// </summary>
		/// <param name="index">Item index to set.</param>
		public void Select(int index)
        {
			_BonEngineBind.BON_UIList_SelectIndex(_handle, index);
        }

		/// <summary>
		/// Select item by text.
		/// </summary>
		/// <param name="item">Item text to select (will pick first occurance found).</param>
		public void Select(string item)
        {
			_BonEngineBind.BON_UIList_Select(_handle, item);
        }

		/// <summary>
		/// Clear selected index.
		/// </summary>
		public void ClearSelection()
        {
			_BonEngineBind.BON_UIList_ClearSelection(_handle);
        }

		/// <summary>
		/// Create the UI element.
		/// </summary>
		/// <param name="handle">UI element handle inside the low-level engine.</param>
		public UIList(IntPtr handle) : base(handle)
        {
        }
    }
}
