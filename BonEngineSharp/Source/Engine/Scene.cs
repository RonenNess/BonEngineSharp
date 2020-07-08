using System;
using System.Collections.Generic;
using System.Text;

namespace BonEngineSharp
{
    /// <summary>
    /// A BonEngine scene.
    /// This is the main class you use to implement your game logic, by overriding its protected key methods: Load, Unload, Start, Update, FixedUpdate and Draw. 
    /// These methods are invoked by the Engine while running its main loop.
    /// 
    /// You can also use multiple scenes to implement different 'screens' or level types in your game (for example a scene for main menu and a scene for actual game).
    /// </summary>
    public class Scene : Managers.ManagerGetters, IDisposable
    {
        // Internal stuff
        #region Internal API

        // the scene pointer in the cpp side
        private IntPtr _handle = IntPtr.Zero;

        // store copy of the callback handles, otherwise they get collected by the GC even while scene is still alive
        _BonEngineBind.NoParamsCallback _LoadCbHandle;
        _BonEngineBind.NoParamsCallback _UnloadCbHandle;
        _BonEngineBind.NoParamsCallback _StartCbHandle;
        _BonEngineBind.NoParamsCallback _DrawCbHandle;
        _BonEngineBind.DoubleParamCallback _UpdateCbHandle;
        _BonEngineBind.DoubleParamCallback _FixedUpdateCbHandle;

        /// <summary>
        /// Get or create scene handle (the part in CPP side).
        /// </summary>
        /// <returns>Scene handle.</returns>
        internal IntPtr GetOrCreateHandle()
        {
            if (_handle == IntPtr.Zero)
            {
                _LoadCbHandle = _Load;
                _UnloadCbHandle = _Unload;
                _StartCbHandle = _Start;
                _DrawCbHandle = _Draw;
                _UpdateCbHandle = _Update;
                _FixedUpdateCbHandle = _FixedUpdate;
                _handle = _BonEngineBind.BON_Scene_Create(
                    _LoadCbHandle,
                    _UnloadCbHandle,
                    _StartCbHandle,
                    _DrawCbHandle,
                    _UpdateCbHandle,
                    _FixedUpdateCbHandle);
            }
            return _handle;
        }

        /// <summary>
        /// Destroy the scene.
        /// </summary>
        ~Scene()
        {
            Dispose();
        }

        /// <summary>
        /// Destroy this scene.
        /// Do not call this on the active scene! You don't need to call this, it will be called automatically.
        /// </summary>
        public void Dispose()
        {
            if (_handle != IntPtr.Zero)
            {
                _BonEngineBind.BON_Scene_Destroy(_handle);
                _LoadCbHandle = null;
                _UnloadCbHandle = null;
                _StartCbHandle = null;
                _DrawCbHandle = null;
                _UpdateCbHandle = null;
                _FixedUpdateCbHandle = null;
            }
        }

        #endregion

        // Internal private implementation of all the basic callbacks.
        // This methods will invoke the user's methods.
        #region Internal Callbacks Wrappers

        /// <summary>
        /// On scene load.
        /// </summary>
        private void _Load()
        {
            Load();
        }

        /// <summary>
        /// On scene unload.
        /// </summary>
        private void _Unload()
        {
            Unload();
        }

        /// <summary>
        /// On scene start.
        /// </summary>
        private void _Start()
        {
            Start();
        }

        /// <summary>
        /// On update.
        /// </summary>
        /// <param name="deltaTime">Time passed, in seconds, since last call.</param>
        private void _Update(double deltaTime)
        {
            Update(deltaTime);
        }

        /// <summary>
        /// On fixed update.
        /// </summary>
        /// <param name="deltaTime">Time passed, in seconds, since last call. Will be constant value.</param>
        private void _FixedUpdate(double deltaTime)
        {
            FixedUpdate(deltaTime);
        }

        /// <summary>
        /// On draw.
        /// </summary>
        private void _Draw()
        {
            Draw();
        }

        #endregion

        // All the methods users can implement (Update, Draw, Load, ect..)
        #region Callbacks To Implement

        /// <summary>
        /// Called when scene loads, which is when it becomes the newly active scene.
        /// 
        /// For scenes that are not the first scene, this occurs at the begining of the main loop, after the previous frame have completely ended.
        /// </summary>
        protected virtual void Load()
        {
        }

        /// <summary>
        /// Called when scene unloads - either when being replaced by another scene, or when game exit while this scene is active.
        /// </summary>
        protected virtual void Unload()
        {
        }

        /// <summary>
        /// Called when scene loads, but only after the main loop started and everything in initialized.
        /// 
        /// Mostly useful for first scenes, as any scene loaded after it will be loaded inside the main loop and call this immediately after Load().
        /// </summary>
        protected virtual void Start()
        {
        }

        /// <summary>
        /// Called every frame once, and used to update things. Most of your game logic goes here (with exception of things that go into FixedUpdate(), if you need any).
        /// </summary>
        /// <param name="deltaTime">Time passed, in seconds, since last call.</param>
        protected virtual void Update(double deltaTime)
        {
        }

        /// <summary>
        /// Called with constant intervals before the normal Update() calls. Useful for physics-related calculations.
        /// Note: for every Update() call there may be zero or more FixedUpdate() calls, depending on your game running speed and fixed interval.
        /// </summary>
        /// <param name="deltaTime">Time passed, in seconds, since last call. Will be constant value.</param>
        protected virtual void FixedUpdate(double deltaTime)
        {
        }

        /// <summary>
        /// Called every frame right after Update(). Used to draw the scene.
        /// </summary>
        protected virtual void Draw()
        {
        }

        #endregion

        #region Additional API

        /// <summary>
        /// Get if this the first scene loaded.
        /// </summary>
        public bool IsFirstScene { get; internal set; }

        #endregion
    }
}
