using System;
using System.Collections.Generic;
using BonEngineSharp.Managers;

namespace BonEngineSharp
{
    /// <summary>
    /// Main entry point class.
    /// 
    /// This is the equivilent of the 'bon' root namespace, and provide the main method to start the engine (Start) and the _Engine getter.
    /// </summary>
    public static class BonEngine
    {
        // list of registered custom managers
        static Dictionary<string, CustomManager> _customManager = new Dictionary<string, CustomManager>();

        /// <summary>
        /// BonEngine version - must match the underlying CPP version.
        /// </summary>
        public static float Version => 1.24f;

        // did we call 'Start' already?
        static bool _wasInit;

        /// <summary>
        /// Start the engine.
        /// </summary>
        /// <param name="scene">Scene to set as first scene.</param>
        public static void Start(Scene scene)
        {
            if (_wasInit) { throw new Exception("BonEngine.Start() was already called!"); }
            _wasInit = true;
            scene.IsFirstScene = true;
            _BonEngineBind.Initialize();
            _BonEngineBind.BON_Start(scene.GetOrCreateHandle());
        }

        /// <summary>
        /// Stop the engine and exit.
        /// </summary>
        public static void Stop()
        {
            _BonEngineBind.BON_Stop();
        }

        /// <summary>
        /// Register a custom manager to the engine.
        /// </summary>
        /// <param name="manager">Manager instance.</param>
        public static void RegisterCustomManager(CustomManager manager)
        {
            _BonEngineBind.BON_Manager_Register(manager.GetOrCreateHandle());
            _customManager[manager.Id] = manager;
        }

        /// <summary>
        /// Get a custom manager instance.
        /// </summary>
        /// <param name="id">Manager id.</param>
        /// <returns>Custom manager instance.</returns>
        public static CustomManager GetCustomManager(string id)
        {
            return _customManager[id];
        }

        /// <summary>
        /// Get engine instance.
        /// </summary>
        public static Engine _Engine { get; private set; } = new Engine();
    }
}
