using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI window element.
    /// </summary>
    public class UIWindow : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Window;

        /// <summary>
        /// Get window title element.
        /// </summary>
        public UIText Title
        {
            get
            {
                if (_title == null)
                {
                    _title = new UIText(_BonEngineBind.BON_UIWindow_Title(_handle));
                    _title._releaseElementOnDispose = false;
                }
                return _title;
            }
        }
        UIText _title;

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIWindow(IntPtr handle) : base(handle)
        {
        }
    }
}
