using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI checkbox element.
    /// </summary>
    public class UICheckBox : UIImage
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Checkbox;

        /// <summary>
        /// Get / set if users can uncheck this checkbox by clicking it again.
        /// </summary>
        public virtual bool AllowUncheck
        {
            get { return _BonEngineBind.BON_UICheckbox_GetAllowUncheck(_handle); }
            set { _BonEngineBind.BON_UICheckbox_SetAllowUncheck(_handle, value); }
        }

        /// <summary>
        /// Get Checkbox caption element.
        /// </summary>
        public virtual UIText Caption
        {
            get
            {
                if (_caption == null)
                {
                    _caption = new UIText(_BonEngineBind.BON_UICheckbox_Caption(_handle));
                    _caption._releaseElementOnDispose = false;
                }
                return _caption;
            }
        }
        UIText _caption;

        /// <summary>
        /// Get / set if this checkbox is checked.
        /// </summary>
        public virtual bool Checked
        {
            get { return _BonEngineBind.BON_UICheckbox_Checked(_handle); }
            set { _BonEngineBind.BON_UICheckbox_SetValue(_handle, value); }
        }

        /// <summary>
        /// Toggle checkbox state.
        /// </summary>
        public virtual void Toggle()
        {
            _BonEngineBind.BON_UICheckbox_Toggle(_handle);
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UICheckBox(IntPtr handle) : base(handle)
        {
        }
    }
}
