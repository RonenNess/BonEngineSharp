using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI Button element.
    /// </summary>
    public class UIButton : UIImage
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Button;

        /// <summary>
        /// Get button caption element.
        /// </summary>
        public UIText Caption
        {
            get
            {
                if (_caption == null)
                {
                    _caption = new UIText(_BonEngineBind.BON_UIButton_Caption(_handle));
                    _caption._releaseElementOnDispose = false;
                }
                return _caption;
            }
        }
        UIText _caption;

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIButton(IntPtr handle) : base(handle)
        {
        }
    }
}
