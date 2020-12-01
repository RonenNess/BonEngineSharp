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
        /// Optional tag you can attach to assets to identify them later in logs.
        /// </summary>
        public string Tag;

        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public IAsset(IntPtr handle)
        {
            _handle = handle;
            Tag = System.IO.Path.GetFileName(Path);
        }

        /// <summary>
        /// Get if this asset got a handle.
        /// </summary>
        protected internal bool HaveHandle => _handle != IntPtr.Zero;

        /// <summary>
        /// Get asset type.
        /// </summary>
        public abstract AssetType AssetType { get; }

        /// <summary>
        /// Is this asset valid?
        /// </summary>
        public virtual bool IsValid => HaveHandle && _BonEngineBind.BON_Asset_IsValid(_handle);

        /// <summary>
        /// Asset's full file path, if have one.
        /// </summary>
        public virtual string FullPath => HaveHandle ? _BonEngineBind.BON_Asset_Path_Str(_handle) : null;

        /// <summary>
        /// Asset's file path, relative to Assets root (what we used when loading it).
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// Get asset full identifier.
        /// </summary>
        protected internal string FullIdentifier => $"[{AssetType.ToString()} | {Tag ?? string.Empty} | {Path} | {_handle.ToString("X")}]";

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~IAsset()
        {
            BonEngine._Engine.Log.Debug($"[C#] Asset {FullIdentifier} - destructor called.");
            Dispose();
        }

        /// <summary>
        /// Destroy the asset pointer by releasing its handle.
        /// </summary>
        public void Dispose()
        {
            if (HaveHandle)
            {
                BonEngine._Engine.Log.Debug($"[C#] Asset {FullIdentifier} is being disposed. Release handle pointer: {_releaseElementOnDispose.ToString()}.");
                if (_releaseElementOnDispose) { _BonEngineBind.BON_Assets_FreeAssetPointer(_handle); }
                _handle = IntPtr.Zero;
            }
        }
    }
}
