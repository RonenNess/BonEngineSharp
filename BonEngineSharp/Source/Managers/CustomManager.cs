using System;


namespace BonEngineSharp.Managers
{
    /// <summary>
    /// A custom manager users can inherit from and register into the engine.
    /// If you need to implement your own custom manager, use this as a base class.
    /// </summary>
    public abstract class CustomManager : IManager, IDisposable
    {
        // handle on cpp side
        private IntPtr _handle = IntPtr.Zero;

        // store copy of the callback handles, otherwise they get collected by the GC even while scene is still alive
        _BonEngineBind.NoParamsCallback _InitializeCbHandle;
        _BonEngineBind.NoParamsCallback _StartCbHandle;
        _BonEngineBind.NoParamsCallback _DisposeCbHandle;
        _BonEngineBind.DoubleParamCallback _UpdateCbHandle;

        /// <summary>
        /// Get or create manager handle (the part in CPP side).
        /// </summary>
        /// <returns>Scene handle.</returns>
        internal IntPtr GetOrCreateHandle()
        {
            if (_handle == IntPtr.Zero)
            {
                _InitializeCbHandle = _Initialize;
                _StartCbHandle = _Start;
                _DisposeCbHandle = _Dispose;
                _UpdateCbHandle = _Update;
                _handle = _BonEngineBind.BON_Manager_Create(_InitializeCbHandle, _StartCbHandle, _DisposeCbHandle, _UpdateCbHandle, Id);
            }
            return _handle;
        }

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~CustomManager()
        {
            Dispose();
        }

        /// <summary>
        /// Dispose the manager.
        /// </summary>
        public void Dispose()
        {
            if (_handle != IntPtr.Zero)
            {
                _Dispose();
                _BonEngineBind.BON_Manager_Destroy(_handle);
                _InitializeCbHandle = null;
                _StartCbHandle = null;
                _DisposeCbHandle = null;
                _UpdateCbHandle = null;
                _handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Initialize manager when engine starts.
        /// </summary>
        protected virtual void _Initialize() { }

        /// <summary>
        /// Called when main loop starts.
        /// </summary>
        protected virtual void _Start() { }

        /// <summary>
        /// Clear / free this manager's resources.
        /// </summary>
        protected virtual void _Dispose() { }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="deltaTime">Delta time since last frame.</param>
        protected virtual void _Update(double deltaTime) { }
    }
}
