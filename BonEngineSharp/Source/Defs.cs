

namespace BonEngineSharp.Defs
{
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
}
