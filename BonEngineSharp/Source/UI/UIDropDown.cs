using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI DropDown element.
    /// </summary>
    public class UIDropDown : UIList
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.DropDown;

        /// <summary>
        /// Show / hide the list component of the DropDown.
        /// </summary>
        /// <param name="show">Show / hide the list.</param>
        public void ShowList(bool show)
        {
            _BonEngineBind.BON_UIDropDown_ShowList(_handle, show);
        }

        /// <summary>
        /// Set / get DropDown placeholder text.
        /// </summary>
        public string PlaceholderText
        {
            get { return _BonEngineBind.BON_UIDropDown_GetPlaceholderText_Str(_handle); }
            set { _BonEngineBind.BON_UIDropDown_SetPlaceholderText(_handle, value); }
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIDropDown(IntPtr handle) : base(handle)
        {
        }
    }
}
