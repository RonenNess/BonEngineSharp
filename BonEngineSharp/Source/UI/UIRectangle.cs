using System;
using BonEngineSharp.Assets;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI Rectangle element.
    /// </summary>
    public class UIRectangle : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Rectangle;

        /// <summary>
        /// Get / set rectangle blend mode.
        /// </summary>
        public BlendModes BlendMode
        {
            get { return (BlendModes)_BonEngineBind.BON_UIRectangle_GetBlendMode(_handle); }
            set { _BonEngineBind.BON_UIRectangle_SetBlendMode(_handle, (int)value); }
        }

        /// <summary>
        /// Get / set rectangle fill mode.
        /// </summary>
        public bool Filled
        {
            get { return _BonEngineBind.BON_UIRectangle_GetFilled(_handle); }
            set { _BonEngineBind.BON_UIRectangle_SetFilled(_handle, value); }
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIRectangle(IntPtr handle) : base(handle)
        {
        }
    }
}
