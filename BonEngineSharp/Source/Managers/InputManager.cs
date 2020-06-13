using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

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
	}
}
