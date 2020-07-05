using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI Button element.
    /// </summary>
    public class UIVerticalScrollbar : UIImage
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Scrollbar;

        /// <summary>
        /// Get / set slider max value.
        /// </summary>
        public int MaxValue
        {
            get { return _BonEngineBind.BON_UIScrollbar_GetMaxValue(_handle); }
            set { _BonEngineBind.BON_UIScrollbar_SetMaxValue(_handle, value); }
        }

        /// <summary>
        /// Get / set slider value.
        /// </summary>
        public int Value
        {
            get { return _BonEngineBind.BON_UIScrollbar_GetValue(_handle); }
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIVerticalScrollbar(IntPtr handle) : base(handle)
        {
        }
    }
}
