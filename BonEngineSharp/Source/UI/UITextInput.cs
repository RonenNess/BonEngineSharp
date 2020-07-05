using System;
using System.ComponentModel.DataAnnotations;
using BonEngineSharp.Defs;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI single-line text input element.
    /// </summary>
    public class UITextInput : UIImage
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.TextInput;

        /// <summary>
        /// Get / set the character used to mark the caret position in the text input element.
        /// </summary>
        public char CaretCharacter
        {
            get { return _BonEngineBind.BON_UITextInput_GetCaretCharacter(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetCaretCharacter(_handle, value); }
        }

        /// <summary>
        /// Get / set the interval, in seconds, of the caret blinking animation.
        /// </summary>
        public float CaretBlinkingInterval
        {
            get { return _BonEngineBind.BON_UITextInput_GetCaretBlinkingInterval(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetCaretBlinkingInterval(_handle, value); }
        }

        /// <summary>
        /// Get / set text input mode.
        /// </summary>
        public UITextInputMode InputMode
        {
            get { return (UITextInputMode)_BonEngineBind.BON_UITextInput_GetInputMode(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetInputMode(_handle, (int)value); }
        }

        /// <summary>
        /// Get / set if the text input is currently active and accepting input.
        /// This is set automatically when you click on the element and unset when you click outside / press enter, 
        /// however you can set it manually to focus the user on the element, or if you want to force him to stop typing.
        /// </summary>
        public bool IsReceivingInput
        {
            get { return _BonEngineBind.BON_UITextInput_GetReceivingInput(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetReceivingInput(_handle, value); }
        }

        /// <summary>
        /// Get / set if the text input allow tabs (treated as 4 spaces).
        /// </summary>
        public bool AllowTabs
        {
            get { return _BonEngineBind.BON_UITextInput_GetAllowTabs(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetAllowTabs(_handle, value); }
        }

        /// <summary>
        /// Get / set text input max length limit.
        /// Set to 0 for no limit.
        /// </summary>
        public int MaxLength
        {
            get { return _BonEngineBind.BON_UITextInput_GetMaxLength(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetMaxLength(_handle, value); }
        }

        /// <summary>
        /// Get / set the text input current value.
        /// </summary>
        public string Value
        {
            get { return _BonEngineBind.BON_UITextInput_GetValue_Str(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetValue(_handle, value); }
        }

        /// <summary>
        /// Get / set the text input placeholder value.
        /// </summary>
        public string PlaceholderText
        {
            get { return _BonEngineBind.BON_UITextInput_GetPlaceholder_Str(_handle); }
            set { _BonEngineBind.BON_UITextInput_SetPlaceholder(_handle, value); }
        }

        /// <summary>
        /// Get text element.
        /// </summary>
        public UIText TextElement
        {
            get
            {
                if (_text == null)
                {
                    _text = new UIText(_BonEngineBind.BON_UITextInput_Text(_handle));
                    _text._releaseElementOnDispose = false;
                }
                return _text;
            }
        }
        UIText _text;

        /// <summary>
        /// Get placeholder element.
        /// </summary>
        public UIText PlaceholderElement
        {
            get
            {
                if (_placeholder == null)
                {
                    _placeholder = new UIText(_BonEngineBind.BON_UITextInput_Placeholder(_handle));
                    _placeholder._releaseElementOnDispose = false;
                }
                return _placeholder;
            }
        }
        UIText _placeholder;

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UITextInput(IntPtr handle) : base(handle)
        {
        }
    }
}
