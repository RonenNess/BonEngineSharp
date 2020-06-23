using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI slider element.
    /// </summary>
    public class UISlider : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Slider;

        /// <summary>
        /// Get / set slider max value.
        /// </summary>
        public int MaxValue
        {
            get { return _BonEngineBind.BON_UISlider_GetMaxValue(_handle); }
            set { _BonEngineBind.BON_UISlider_SetMaxValue(_handle, value); }
        }

        /// <summary>
        /// Get / set slider value.
        /// </summary>
        public int Value
        {
            get { return _BonEngineBind.BON_UISlider_GetValue(_handle); }
            set { _BonEngineBind.BON_UISlider_SetValue(_handle, value); }
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UISlider(IntPtr handle) : base(handle)
        {
        }
    }
}
