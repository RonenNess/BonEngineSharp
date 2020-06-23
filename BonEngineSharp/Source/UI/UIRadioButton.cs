using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI radio button element.
    /// </summary>
    public class UIRadioButton : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Radio;

        /// <summary>
        /// Get / set if users can uncheck this button by clicking it again.
        /// </summary>
        public bool AllowUncheck
        {
            get { return _BonEngineBind.BON_UIRadio_GetAllowUncheck(_handle); }
            set { _BonEngineBind.BON_UIRadio_SetAllowUncheck(_handle, value); }
        }

        /// <summary>
        /// Get radio button caption element.
        /// </summary>
        public UIText Caption
        {
            get
            {
                if (_caption == null)
                {
                    _caption = new UIText(_BonEngineBind.BON_UIRadio_Caption(_handle));
                    _caption._releaseElementOnDispose = false;
                }
                return _caption;
            }
        }
        UIText _caption;

        /// <summary>
        /// Get / set if this radio button is checked.
        /// </summary>
        public bool Checked
        {
            get { return _BonEngineBind.BON_UIRadio_Checked(_handle); }
            set { _BonEngineBind.BON_UIRadio_SetValue(_handle, value); }
        }

        /// <summary>
        /// Toggle radio button state.
        /// </summary>
        public void Toggle()
        {
            _BonEngineBind.BON_UIRadio_Toggle(_handle);
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIRadioButton(IntPtr handle) : base(handle)
        {
        }
    }
}
