using BonEngineSharp.Defs;
using BonEngineSharp.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Input manager.
	/// Used to recieve user input, either by querying keyboard keys and mouse directly, or by binding keys to actions and querying action states.
    /// </summary>
    public class InputManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "input";

		/// <summary>
		/// Get if an action id is currently pressed down.
		/// </summary>
		/// <param name="action">Action to check.</param>
		/// <returns>True if any of the keys bound to this action id are down.</returns>
		public bool Down(string action)
        {
			return _BonEngineBind.BON_Input_Down(action);
        }

		/// <summary>
		/// Get if an action id was released in this update or fixed update frame.
		/// </summary>
		/// <param name="action">Action to check.</param>
		/// <returns>True if any of the keys bound to this action id were released during this frame.</returns>
		public bool ReleasedNow(string action)
		{
			return _BonEngineBind.BON_Input_ReleasedNow(action);
		}

		/// <summary>
		/// Get if an action id was pressed in this update or fixed update frame.
		/// </summary>
		/// <param name="action">Action to check.</param>
		/// <returns>True if any of the keys bound to this action id were pressed during this frame.</returns>
		public bool PressedNow(string action)
		{
			return _BonEngineBind.BON_Input_PressedNow(action);
		}

		/// <summary>
		/// Get if akey is currently pressed down.
		/// </summary>
		/// <param name="key">Key to check.</param>		
		/// <returns>True if key is currently down.</returns>
		public bool Down(KeyCodes key)
		{
			return _BonEngineBind.BON_Input_KeyDown((int)key);
		}

		/// <summary>
		/// Get if a key was released in this update or fixed update frame.
		/// </summary>
		/// <param name="key">Key to check.</param>
		/// <returns>True if key was released during this frame.</returns>
		public bool ReleasedNow(KeyCodes key)
		{
			return _BonEngineBind.BON_Input_KeyReleasedNow((int)key);
		}

		/// <summary>
		/// Get if a key was pressed in this update or fixed update frame.
		/// </summary>
		/// <param name="key">Key to check.</param>
		/// <returns>True if key was pressed during this frame.</returns>
		public bool PressedNow(KeyCodes key)
		{
			return _BonEngineBind.BON_Input_KeyPressedNow((int)key);
		}

		/// <summary>
		/// Get text input data.
		/// This data struct contains input information relevant to text typing by user. 
		/// It includes the new characters typed this frame + additional commands like backspace, delete, copy, paste, ect.
		/// </summary>
		/// <returns>Text input data struct.</returns>
		public TextInputData TextInput()
        {
			var _data = _BonEngineBind.BON_Input_GetTextInput();
			var ret = new TextInputData()
			{
				Backspace = _data.Backspace != 0,
				Copy = _data.Copy != 0,
				Paste = _data.Paste != 0,
				Delete = _data.Delete != 0,
				Tab = _data.Tab != 0,
				Up = _data.Up != 0,
				Down = _data.Down != 0,
				Left = _data.Left != 0,
				Right = _data.Right != 0,
				Home = _data.Home != 0,
				End = _data.End != 0,
				Insert = _data.Insert != 0,
				Text = new string(_data.Text)
			};
			return ret;
		}

		/// <summary>
		/// Get mouse wheel / scroll delta of current frame.
		/// </summary>
		public PointI ScrollDelta => new PointI(_BonEngineBind.BON_Input_ScrollDeltaX(), _BonEngineBind.BON_Input_ScrollDeltaY());

		/// <summary>
		/// Get cursor (mouse) position.
		/// </summary>
		public PointI CursorPosition => new PointI(_BonEngineBind.BON_Input_CursorPositionX(), _BonEngineBind.BON_Input_CursorPositionY());

		/// <summary>
		/// Get cursor (mouse) position change since last frame.
		/// </summary>
		public PointI CursorDelta => new PointI(_BonEngineBind.BON_Input_CursorDeltaX(), _BonEngineBind.BON_Input_CursorDeltaY());

		/// <summary>
		/// Binds a key code to an action.
		/// </summary>
		/// <param name="key">Key to bind.</param>
		/// <param name="action">Action to bind to.</param>
		public void BindKey(KeyCodes key, string action)
        {
			_BonEngineBind.BON_Input_SetKeyBind((int)key, action);
        }

		/// <summary>
		/// Set / get clipboard buffer as string.
		/// </summary>
		public string Clipboard
		{
			get { return _BonEngineBind.BON_Input_GetClipboard_Str(); }
			set { _BonEngineBind.BON_Input_SetClipboard(value); }
		}

		/// <summary>
		/// Get array with all keys currently assigned to an action id.
		/// </summary>
		/// <param name="action">Action id to query.</param>
		/// <returns>Array with keys assigned to action id.</returns>
		public KeyCodes[] GetAssignedKeys(string action)
        {
			// get buffer from C++ side
			int length = 0;
			IntPtr buff = _BonEngineBind.BON_Input_GetAssignedKeys(action, ref length);

			// no results? return empty
			if (length == 0 || buff == IntPtr.Zero)
            {
				return new KeyCodes[] { };
            }

			// create array of ints
			int[] temparray = new int[length];
			Marshal.Copy(buff, temparray, 0, length);

			// convert to key codes and return
			return temparray.Select(x => (KeyCodes)x).ToArray();
		}
	}
}
