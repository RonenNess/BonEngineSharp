using System;
using System.Collections.Generic;
using System.Text;
using BonEngineSharp.Managers;

namespace BonEngineSharp
{
    /// <summary>
    /// The main engine class.
    /// This object manages all the managers and runs the main loop. Normally you don't need to access it directly.
    /// </summary>
    public class Engine
    {
        // Manager instances.
        Dictionary<string, IManager> _managers = new Dictionary<string, IManager>();

        /// <summary>
        /// Get current engine state.
        /// </summary>
        public Defs.EngineStates CurrentState => (Defs.EngineStates)_BonEngineBind.BON_Engine_CurrentState();

        /// <summary>
        /// Get total updates count.
        /// </summary>
        public UInt64 UpdatesCount => _BonEngineBind.BON_Engine_UpdatesCount();

        /// <summary>
        /// Get total fixed updates count.
        /// </summary>
        public UInt64 FixedUpdatesCount => _BonEngineBind.BON_Engine_FixedUpdatesCount();

        /// <summary>
        /// Is the engine running?
        /// </summary>
        public bool Running => _BonEngineBind.BON_Engine_Running();

        /// <summary>
        /// Is the engine destroyed?
        /// </summary>
        public bool Destroyed => _BonEngineBind.BON_Engine_Destroyed();

        /// <summary>
        /// Get / set the fixed updates interval, in seconds.
        /// </summary>
        public double FixedUpdatesInterval
        {
            get { return _BonEngineBind.BON_Engine_GetFixedUpdatesInterval(); }
            set { _BonEngineBind.BON_Engine_SetFixedUpdatesInterval(value); }
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        public Engine()
        {
            // init all managers (note: these are just wrappers, the actual logic is in cpp).
            RegisterManager(new GfxManager());
            RegisterManager(new SfxManager());
            RegisterManager(new InputManager());
            RegisterManager(new AssetsManager());
            RegisterManager(new GameManager());
            RegisterManager(new DiagnosticsManager());
            RegisterManager(new LogManager());

            // set built-in manager getters
            Gfx = _managers["gfx"] as GfxManager;
            Sfx = _managers["sfx"] as SfxManager;
            Input = _managers["input"] as InputManager;
            Assets = _managers["assets"] as AssetsManager;
            Game = _managers["game"] as GameManager;
            Diagnostics = _managers["diagnostics"] as DiagnosticsManager;
            Log = _managers["log"] as LogManager;
        }

        /// <summary>
        /// Get Gfx manager.
        /// </summary>
        public GfxManager Gfx { get; private set; }

        /// <summary>
        /// Get Sfx manager.
        /// </summary>
        public SfxManager Sfx { get; private set; }

        /// <summary>
        /// Get Input manager.
        /// </summary>
        public InputManager Input { get; private set; }

        /// <summary>
        /// Get Assets manager.
        /// </summary>
        public AssetsManager Assets { get; private set; }

        /// <summary>
        /// Get Game manager.
        /// </summary>
        public GameManager Game { get; private set; }

        /// <summary>
        /// Get Diagnostics manager.
        /// </summary>
        public DiagnosticsManager Diagnostics { get; private set; }

        /// <summary>
        /// Get Log manager.
        /// </summary>
        public LogManager Log { get; private set; }

        /// <summary>
        /// Register a manager.
        /// </summary>
        private void RegisterManager(IManager manager)
        {
            _managers[manager.Id] = manager;
        }

        /// <summary>
        /// Get manager of generic type by id.
        /// </summary>
        public T GetManager<T>(string id) where T : IManager
        {
            return _managers[id] as T;
        }
    }
}
