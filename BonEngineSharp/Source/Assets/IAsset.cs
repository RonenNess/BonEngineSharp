using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Asset base class.
    /// This is the basic class all Assets inherit from and its main purpose is to manage the handle to the CPP-side asset.
    /// </summary>
    public abstract class IAsset : IDisposable
    {
        /// <summary>
        /// The asset's handle in BonEngine.
        /// </summary>
        internal protected IntPtr _handle = IntPtr.Zero;

        // if true, will release (delete) the cpp side asset when disposed.
        internal bool _releaseElementOnDispose = true;

        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public IAsset(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Get if this asset got a handle.
        /// </summary>
        protected bool HaveHandle => _handle != IntPtr.Zero;

        /// <summary>
        /// Get asset type.
        /// </summary>
        public abstract AssetType AssetType { get; }

        /// <summary>
        /// Is this asset valid?
        /// </summary>
        public virtual bool IsValid => _handle != IntPtr.Zero && _BonEngineBind.BON_Asset_IsValid(_handle);

        /// <summary>
        /// Asset's file path, if have one.
        /// </summary>
        public virtual string Path => _handle != IntPtr.Zero ? _BonEngineBind.BON_Asset_Path_Str(_handle) : null;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~IAsset()
        {
            Dispose();
        }

        /// <summary>
        /// Destroy the asset pointer by releasing its handle.
        /// </summary>
        public void Dispose()
        {
            if (HaveHandle)
            {
                BonEngine._Engine.Log.Debug($"[C#] Asset of type '{AssetType.ToString()}' and path '{Path}' is being disposed. Release pointer: {_releaseElementOnDispose.ToString()}.");
                if (_releaseElementOnDispose) { _BonEngineBind.BON_Assets_FreeAssetPointer(_handle); }
                _handle = IntPtr.Zero;
            }
        }
    }
}
