

using System;

namespace BonEngineSharp.Defs
{
	/// <summary>
	/// Determine which features to enable on initialization.
	/// This allow you to enable / disable special runtime features and flags.
	/// </summary>
	public class BonFeatures
	{
		/// <summary>
		/// If true, will enable Effects asset. 
		/// With BonEngine default GFX implementation, this also forces us to use OpenGL.
		/// </summary>
		public bool EffectsEnabled = false;

		/// <summary>
		/// If true, will force the Gfx manager to use OpenGL implementation.
		/// Note: if Effects are enabled it will force OpenGL regardless of this setting.
		/// </summary>
		public bool ForceOpenGL = false;

		/// <summary>
		/// If true, will register signals handler to finish logs before exiting.
		/// </summary>
		public bool RegisterSignalsHandler = false;

		/// <summary>
		/// If true, will enable logging by default.
		/// </summary>
		public bool Logging = true;
	}

	/// <summary>
	/// Different states the engine can be in.
	/// You can query engine states to better understand whats going on while debugging.
	/// </summary>
	public enum EngineStates
	{
		/// <summary>
		/// Engine was not initialized yet.
		/// </summary>
		BeforeInitialize,

		/// <summary>
		/// Engine is initializing now.
		/// </summary>
		Initialize,

		/// <summary>
		/// Engine is doing managers updates.
		/// </summary>
		InternalUpdate,

		/// <summary>
		/// Engine is doing fixed updates.
		/// </summary>
		FixedUpdate,

		/// <summary>
		/// Engine is doing regular updates.
		/// </summary>
		Update,

		/// <summary>
		/// Engine is drawing.
		/// </summary>
		DrawImage,

		/// <summary>
		/// Engine is doing other main-loop code that isn't updates or drawing.
		/// </summary>
		MainLoopInBetweens,

		/// <summary>
		/// Engine is handling events.
		/// </summary>
		HandleEvents,

		/// <summary>
		/// Engine is stopping.
		/// </summary>
		Stopping,

		/// <summary>
		/// Engine is completely stopped and destroyed.
		/// </summary>
		Destroyed,

		/// <summary>
		/// Engine is currently switching scenes (not set on first scene set).
		/// </summary>
		SwitchScene,
	};

	/// <summary>
	/// Asset types enum - used to identify type of assets.
	/// 
	/// This is not really necessary in C#, but exists to match the definition in the CPP side of it.
	/// </summary>
	public enum AssetType
	{
		/// <summary>
		/// An image asset we can use for rendering.
		/// </summary>
		Image,

		/// <summary>
		/// Sound effect asset we can play as short sounds.
		/// </summary>
		Sound,

		/// <summary>
		/// A long soundtrack asset, used for music.
		/// </summary>
		Music,

		/// <summary>
		/// Configuration file asset.
		/// </summary>
		Config,

		/// <summary>
		/// Font asset, used to draw text.
		/// </summary>
		Font,

		/// <summary>
		/// Effect asset, used to draw sprites with special effects.
		/// </summary>
		Effect,

		/// <summary>
		/// How many asset types we got.
		/// </summary>
		_Count
	}

	/// <summary>
	/// Image filtering modes.
	/// </summary>
	public enum ImageFilterMode
	{
		/// <summary>
		/// Nearest-neighbor filtering (crispy, pixelator result on scaling).
		/// </summary>
		Nearest = 0,

		/// <summary>
		/// Linear filtering (lower quality smoothing).
		/// </summary>
		Linear = 1,

		/// <summary>
		/// Anisotropic filtering (higher quality smoothing).
		/// </summary>
		Anisotropic = 2,

		/// <summary>
		/// Filtering modes count.
		/// </summary>
		_Count = 3,
	}

	/// <summary>
	/// Diagnostics counters we can query from the Diagnostics manager.
	/// </summary>
	public enum DiagnosticsCounters
	{
		/// <summary>
		/// Draw calls during this frame.
		/// </summary>
		DrawCalls,

		/// <summary>
		/// Play sound calls during this frame.
		/// </summary>
		PlaySoundCalls,

		/// <summary>
		/// Currently loaded assets count.
		/// </summary>
		LoadedAssets,

		/// <summary>
		/// Last built-in counter value.
		/// If you want to add custom counters, start here and go up until 'MaxCounters'.
		/// </summary>
		_BuiltInCounterCount,

		/// <summary>
		/// Max counters value.
		/// </summary>
		_MaxCounters = 50,
	};

	/// <summary>
	/// Window startup modes - used when recreating the window via the Gfx manager.
	/// </summary>
	public enum WindowModes
	{
		/// <summary>
		/// Windowed mode.
		/// </summary>
		Windowed,

		/// <summary>
		/// Windowed mode without border.
		/// </summary>
		WindowedBorderless,

		/// <summary>
		/// Fullscreen mode (change resolution).
		/// </summary>
		Fullscreen,
	}

	/// <summary>
	/// Possible rendering blend modes for drawing images and shapes.
	/// </summary>
	public enum BlendModes
	{
		/// <summary>
		/// Render without any transparency or opacity.
		/// </summary>
		Opaque = 0,

		/// <summary>
		/// Render with alpha channels.
		/// </summary>
		AlphaBlend = 1,

		/// <summary>
		/// Render with additive (lighten) effect.
		/// </summary>
		Additive = 2,

		/// <summary>
		/// Render with mod effect.
		/// </summary>
		Mod = 3,

		/// <summary>
		/// Render with multiply (darken) effect.
		/// </summary>
		Multiply = 4,

		/// <summary>
		/// Blend modes count.
		/// </summary>
		_Count = 5,
	};

#pragma warning disable CS1591
	/// <summary>
	/// Keyboard and mouse key codes.
	/// Use these codes to query the Input manager directly, or to bind keys to game actions and query actions instead.
	/// </summary>
	public enum KeyCodes
	{
		KeyUnknown,
		KeyReturn,
		KeyEscape,
		KeyBackspace,
		KeyTab,
		KeySpace,
		KeyExclaim,
		KeyQuotedbl,
		KeyHash,
		KeyPercent,
		KeyDollar,
		KeyAmpersand,
		KeyQuote,
		KeyLeftparen,
		KeyRightparen,
		KeyAsterisk,
		KeyPlus,
		KeyComma,
		KeyMinus,
		KeyPeriod,
		KeySlash,
		Key0,
		Key1,
		Key2,
		Key3,
		Key4,
		Key5,
		Key6,
		Key7,
		Key8,
		Key9,
		KeyColon,
		KeySemicolon,
		KeyLess,
		KeyEquals,
		KeyGreater,
		KeyQuestion,
		KeyAt,
		KeyLeftbracket,
		KeyBackslash,
		KeyRightbracket,
		KeyCaret,
		KeyUnderscore,
		KeyBackquote,
		KeyA,
		KeyB,
		KeyC,
		KeyD,
		KeyE,
		KeyF,
		KeyG,
		KeyH,
		KeyI,
		KeyJ,
		KeyK,
		KeyL,
		KeyM,
		KeyN,
		KeyO,
		KeyP,
		KeyQ,
		KeyR,
		KeyS,
		KeyT,
		KeyU,
		KeyV,
		KeyW,
		KeyX,
		KeyY,
		KeyZ,
		KeyCapslock,
		KeyF1,
		KeyF2,
		KeyF3,
		KeyF4,
		KeyF5,
		KeyF6,
		KeyF7,
		KeyF8,
		KeyF9,
		KeyF10,
		KeyF11,
		KeyF12,
		KeyPrintscreen,
		KeyScrolllock,
		KeyPause,
		KeyInsert,
		KeyHome,
		KeyPageup,
		KeyDelete,
		KeyEnd,
		KeyPagedown,
		KeyRight,
		KeyLeft,
		KeyDown,
		KeyUp,
		KeyNumlockclear,
		KeyKpDivide,
		KeyKpMultiply,
		KeyKpMinus,
		KeyKpPlus,
		KeyKpEnter,
		KeyKp1,
		KeyKp2,
		KeyKp3,
		KeyKp4,
		KeyKp5,
		KeyKp6,
		KeyKp7,
		KeyKp8,
		KeyKp9,
		KeyKp0,
		KeyKpPeriod,
		KeyApplication,
		KeyPower,
		KeyKpEquals,
		KeyF13,
		KeyF14,
		KeyF15,
		KeyF16,
		KeyF17,
		KeyF18,
		KeyF19,
		KeyF20,
		KeyF21,
		KeyF22,
		KeyF23,
		KeyF24,
		KeyExecute,
		KeyHelp,
		KeyMenu,
		KeySelect,
		KeyStop,
		KeyAgain,
		KeyUndo,
		KeyCut,
		KeyCopy,
		KeyPaste,
		KeyFind,
		KeyMute,
		KeyVolumeup,
		KeyVolumedown,
		KeyKpComma,
		KeyKpEqualsas400,
		KeyAlterase,
		KeySysreq,
		KeyCancel,
		KeyClear,
		KeyPrior,
		KeyReturn2,
		KeySeparator,
		KeyOut,
		KeyOper,
		KeyClearagain,
		KeyCrsel,
		KeyExsel,
		KeyKp00,
		KeyKp000,
		KeyThousandsseparator,
		KeyDecimalseparator,
		KeyCurrencyunit,
		KeyCurrencysubunit,
		KeyKpLeftparen,
		KeyKpRightparen,
		KeyKpLeftbrace,
		KeyKpRightbrace,
		KeyKpTab,
		KeyKpBackspace,
		KeyKpA,
		KeyKpB,
		KeyKpC,
		KeyKpD,
		KeyKpE,
		KeyKpF,
		KeyKpXor,
		KeyKpPower,
		KeyKpPercent,
		KeyKpLess,
		KeyKpGreater,
		KeyKpAmpersand,
		KeyKpDblampersand,
		KeyKpVerticalbar,
		KeyKpDblverticalbar,
		KeyKpColon,
		KeyKpHash,
		KeyKpSpace,
		KeyKpAt,
		KeyKpExclam,
		KeyKpMemstore,
		KeyKpMemrecall,
		KeyKpMemclear,
		KeyKpMemadd,
		KeyKpMemsubtract,
		KeyKpMemmultiply,
		KeyKpMemdivide,
		KeyKpPlusminus,
		KeyKpClear,
		KeyKpClearentry,
		KeyKpBinary,
		KeyKpOctal,
		KeyKpDecimal,
		KeyKpHexadecimal,
		KeyLctrl,
		KeyLshift,
		KeyLalt,
		KeyLgui,
		KeyRctrl,
		KeyRshift,
		KeyRalt,
		KeyRgui,
		KeyMode,
		KeyAudionext,
		KeyAudioprev,
		KeyAudiostop,
		KeyAudioplay,
		KeyAudiomute,
		KeyMediaselect,
		KeyWww,
		KeyMail,
		KeyCalculator,
		KeyComputer,
		KeyAcSearch,
		KeyAcHome,
		KeyAcBack,
		KeyAcForward,
		KeyAcStop,
		KeyAcRefresh,
		KeyAcBookmarks,
		KeyBrightnessdown,
		KeyBrightnessup,
		KeyDisplayswitch,
		KeyKbdillumtoggle,
		KeyKbdillumdown,
		KeyKbdillumup,
		KeyEject,
		KeySleep,
		KeyApp1,
		KeyApp2,
		KeyAudiorewind,
		KeyAudiofastforward,
		MouseLeft,
		MouseMiddle,
		MouseRight,
		MouseX1,
		MouseX2,
	};
#pragma warning restore CS1591

	/// <summary>
	/// Log levels to use when writing logs.
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// Invalid log level - will never show.
		/// </summary>
		None = -1,

		/// <summary>
		/// Debug logs.
		/// </summary>
		Debug = 0,

		/// <summary>
		/// Info logs.
		/// </summary>
		Info = 1,

		/// <summary>
		/// Warning logs.
		/// </summary>
		Warn = 2,

		/// <summary>
		/// Errors log.
		/// </summary>
		Error = 3,

		/// <summary>
		/// Critical logs.
		/// </summary>
		Critical = 4,
	};

	/// <summary>
	/// A wrapper around <see cref="System.Int32"/> to hold channel id.
	/// Channel ids represent the mix channel we play sound effects on. You can use this channel id to control the playing sound volume, panning, duration ect.
	/// Note that there are two special channel ids you should watch for: AllChannels (-1), used to affect all channels at once, and Invalid (-2), which is what you get when engine couldn't play a sound.
	/// </summary>
	public struct SoundChannelId
	{
		// A struct's fields should not be exposed
		private int value;

		/// <summary>
		/// Channel id for actions on all channels.
		/// </summary>
		public static readonly SoundChannelId AllChannels = -1;

		/// <summary>
		/// Invalid channel id, for when we fail to allocate channel.
		/// </summary>
		public static readonly SoundChannelId Invalid = -2;

		/// <summary>
		/// Is it a valid single channel?
		/// </summary>
		public bool IsValidSingle => value >= 0;

		/// <summary>
		/// Is it a valid value?
		/// </summary>
		public bool IsValid => value != Invalid;

		// As we are using implicit conversions we can keep the constructor private
		private SoundChannelId(int value)
		{
			this.value = value;
		}

		/// <summary>
		/// Implicitly converts a <see cref="System.Int32"/> to a Record.
		/// </summary>
		/// <param name="value">The <see cref="System.Int32"/> to convert.</param>
		/// <returns>A new Record with the specified value.</returns>
		public static implicit operator SoundChannelId(int value)
		{
			return new SoundChannelId(value);
		}
		/// <summary>
		/// Implicitly converts a Record to a <see cref="System.Int32"/>.
		/// </summary>
		/// <param name="record">The Record to convert.</param>
		/// <returns>
		/// A <see cref="System.Int32"/> that is the specified Record's value.
		/// </returns>
		public static implicit operator int(SoundChannelId record)
		{
			return record.value;
		}
	}

	/// <summary>
	/// Audio format options.
	/// </summary>
	public enum AudioFormats
	{
		/// <summary>
		/// Unsigned 8-bit samples.
		/// </summary>
		U8,

		/// <summary>
		/// Signed 8-bit samples.
		/// </summary>
		S8,

		/// <summary>
		/// Unsigned 16-bit samples.
		/// </summary>
		U16LSB,

		/// <summary>
		/// Signed 16-bit samples.
		/// </summary>
		S16LSB,

		/// <summary>
		/// Unsigned 16-bit samples, big endian.
		/// </summary>
		U16MSB,

		/// <summary>
		/// Signed 16-bit samples, big endian.
		/// </summary>
		S16MSB
	}

	/// <summary>
	/// UI text alignment.
	/// </summary>
	public enum UITextAlignment
	{
		/// <summary>
		/// Align text left.
		/// </summary>
		Left = 0,

		/// <summary>
		/// Align text right.
		/// </summary>
		Right = 1,

		/// <summary>
		/// Align text to center.
		/// </summary>
		Center = 2
	}

	/// <summary>
	/// UI Size unit types.
	/// </summary>
	public enum UISizeType
	{
		/// <summary>
		/// Coordinates are in absolute pixels.
		/// </summary>
		Pixels = 0,

		/// <summary>
		/// Coordinates are relative to parent size.
		/// </summary>
		PercentOfParent = 1,
	}

	/// <summary>
	/// Contains text input information from the input manager.
	/// </summary>
	public struct TextInputData
	{
		/// <summary>
		/// Was backspace pressed (need to remove a character).
		/// </summary>
		public bool Backspace;

		/// <summary>
		/// Was delete pressed (need to delete a character).
		/// </summary>
		public bool Delete;

		/// <summary>
		/// Was copy command issued (ctrl+c).
		/// </summary>
		public bool Copy;

		/// <summary>
		/// Was paste command issued (ctrl+v).
		/// </summary>
		public bool Paste;

		/// <summary>
		/// Was tab pressed.
		/// </summary>
		public bool Tab;

		/// <summary>
		/// Was up pressed.
		/// </summary>
		public bool Up;

		/// <summary>
		/// Was down pressed.
		/// </summary>
		public bool Down;

		/// <summary>
		/// Was left pressed.
		/// </summary>
		public bool Left;

		/// <summary>
		/// Was right pressed.
		/// </summary>
		public bool Right;

		/// <summary>
		/// Was Home pressed.
		/// </summary>
		public bool Home;

		/// <summary>
		/// Was End pressed.
		/// </summary>
		public bool End;

		/// <summary>
		/// Was Insert pressed.
		/// </summary>
		public bool Insert;

		/// <summary>
		/// New characters entered this frame.
		/// </summary>
		public string Text;
	};

	/// <summary>
	/// UI size - represent a UI element size with width, height and types.
	/// </summary>
	public struct UISize
	{
		/// <summary>
		/// Width value.
		/// </summary>
		public int Width;

		/// <summary>
		/// Height value.
		/// </summary>
		public int Height;

		/// <summary>
		/// Width units type.
		/// </summary>
		public UISizeType WidthType;

		/// <summary>
		/// Height units type.
		/// </summary>
		public UISizeType HeightType;

		/// <summary>
		/// Create the UI size struct.
		/// </summary>
		public UISize(int width, UISizeType widthType, int height, UISizeType heightType)
		{
			Width = width;
			WidthType = widthType;
			Height = height;
			HeightType = heightType;
		}
	}

	/// <summary>
	/// Represent value with 4 sides - top, bottom, left, right.
	/// </summary>
	public struct UISides
	{
		/// <summary>
		/// Left side value.
		/// </summary>
		public int Left;

		/// <summary>
		/// Right side value.
		/// </summary>
		public int Right;

		/// <summary>
		/// Top side value.
		/// </summary>
		public int Top;

		/// <summary>
		/// Bottom side value.
		/// </summary>
		public int Bottom;

		/// <summary>
		/// Create the UI sides struct.
		/// </summary>
		public UISides(int left, int top, int right, int bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}

	/// <summary>
	/// All built-in UI types.
	/// </summary>
	public enum UIElementType
	{
		/// <summary>
		/// Base element type.
		/// </summary>
		Element,

		/// <summary>
		/// Button element.
		/// </summary>
		Button,

		/// <summary>
		/// Checkbox element.
		/// </summary>
		Checkbox,

		/// <summary>
		/// Radio button element.
		/// </summary>
		Radio,

		/// <summary>
		/// Image element.
		/// </summary>
		Image,

		/// <summary>
		/// List element.
		/// </summary>
		List,

		/// <summary>
		/// DropDown element.
		/// </summary>
		DropDown,

		/// <summary>
		/// Text / paragraph element.
		/// </summary>
		Text,

		/// <summary>
		/// Scrollbar element.
		/// </summary>
		Scrollbar,

		/// <summary>
		/// Slider element.
		/// </summary>
		Slider,

		/// <summary>
		/// Inline text input element.
		/// </summary>
		TextInput,

		/// <summary>
		/// Container window element.
		/// </summary>
		Window,
	}

	/// <summary>
	/// UI Image drawing types.
	/// This defines how to scale and what parts of the UI image to draw.
	/// </summary>
	public enum UIImageTypes
	{
		/// <summary>
		/// Draw image stretched over the calculated destination rect.
		/// </summary>
		Stretch,

		/// <summary>
		/// Draw image as tiles that cover the calculated destination rect.
		/// </summary>
		Tiled,

		/// <summary>
		/// Draw image as a 9-sliced texture with 4 sides, 4 corners, and tiled center.
		/// </summary>
		Sliced,

		/// <summary>
		/// Draw image once, no matter the element size, scaled by texture scale.
		/// </summary>
		Single,
	}

	/// <summary>
	/// UI Element state.
	/// </summary>
	public enum UIElementState
	{
		/// <summary>
		/// There's no interaction with this element.
		/// </summary>
		Idle,

		/// <summary>
		/// User points on this element.
		/// </summary>
		PointedOn,

		/// <summary>
		/// User clicks or somehow interacts with element.
		/// </summary>
		PressedDown,

		/// <summary>
		/// User right-clicks element.
		/// </summary>
		AltPressedDown,
	}

	/// <summary>
	/// UI text input modes - determine what type of characters a UI text input accepts, and how to process them.
	/// </summary>
	[Flags]
	public enum UITextInputMode
	{
		/// <summary>
		/// Allow any text input.
		/// Don't use this one as flag, set it as value.
		/// </summary>
		AnyText = 0,

		/// <summary>
		/// Allow only numbers.
		/// </summary>
		NumbersOnly = 1,

		/// <summary>
		/// Don't allow numbers.
		/// </summary>
		NoNumbers = 1 << 1,

		/// <summary>
		/// Make all input uppercase.
		/// </summary>
		Uppercase = 1 << 2,

		/// <summary>
		/// Make all input lowercase.
		/// </summary>
		Lowercase = 1 << 3,

		/// <summary>
		/// Allow only characters.
		/// </summary>
		AlphaOnly = 1 << 4,
	}
}
