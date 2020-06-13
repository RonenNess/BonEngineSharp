using System;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Assets manager.
    /// Responsible to load or create game assets. Use this manager when you want to load textures, sound effects, music, config, ect.
    /// </summary>
    public class AssetsManager : IManager
    {
        /// <summary>
        /// Optional root folder to load all assets from
        /// </summary>
        public string AssetsRoot = "";

        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "assets";

        /// <summary>
        /// Add 'AssetsRoot' to an asset path.
        /// </summary>
        public string ToAssetsPath(string filename, bool validate)
        {
            // set asset path
            if (!string.IsNullOrEmpty(AssetsRoot))
            {
                filename = System.IO.Path.Combine(AssetsRoot, filename);
            }

            // validate
            if (validate && !System.IO.File.Exists(filename))
            {
                throw new Exception($"Asset file not found: '{filename}'!");
            }

            // return path
            return filename;
        }

        /// <summary>
        /// Clear assets cache.
        /// Note: this will not release assets that you still hold a reference to.
        /// </summary>
        public void ClearCache()
        {
            _BonEngineBind.BON_Assets_ClearCache();
        }

        /// <summary>
        /// Loads an image asset.
        /// </summary>
        /// <param name="filename">Image path.</param>
        /// <param name="filter">Image filtering mode.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <returns>Loaded image asset.</returns>
        public ImageAsset LoadImage(string filename, ImageFilterMode filter = ImageFilterMode.Nearest, bool useCache = true)
        {
            var ret = new ImageAsset(_BonEngineBind.BON_Assets_LoadImage(ToAssetsPath(filename, true), (int)filter, useCache));
            return ret;
        }

        /// <summary>
        /// Creates an empty image.
        /// </summary>
        /// <param name="size">Image size.</param>
        /// <param name="filter">Image filtering mode.</param>
        /// <returns>Loaded image asset.</returns>
        public ImageAsset CreateEmptyImage(PointI size, ImageFilterMode filter = ImageFilterMode.Nearest)
        {
            var ret = new ImageAsset(_BonEngineBind.BON_Assets_CreateEmptyImage(size.X, size.Y, (int)filter));
            return ret;
        }

        /// <summary>
        /// Loads a config asset.
        /// </summary>
        /// <param name="filename">Config path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <returns>Loaded config asset.</returns>
        public ConfigAsset LoadConfig(string filename, bool useCache = true)
        {
            var ret = new ConfigAsset(_BonEngineBind.BON_Assets_LoadConfig(ToAssetsPath(filename, true), useCache));
            return ret;
        }

        /// <summary>
        /// Creates an empty config.
        /// </summary>
        public ConfigAsset CreateEmptyConfig()
        {
            var ret = new ConfigAsset(_BonEngineBind.BON_Assets_CreateEmptyConfig());
            return ret;
        }

        /// <summary>
        /// Saves a config file.
        /// </summary>
        /// <returns>True if saving was successful.</returns>
        public bool SaveConfig(ConfigAsset config, string path)
        {
            return _BonEngineBind.BON_Assets_SaveConfig(config._handle, ToAssetsPath(path, false));
        }

        /// <summary>
        /// Loads a music asset.
        /// </summary>
        /// <param name="filename">Music file path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <returns>Loaded music asset.</returns>
        public MusicAsset LoadMusic(string filename, bool useCache = true)
        {
            var ret = new MusicAsset(_BonEngineBind.BON_Assets_LoadMusic(ToAssetsPath(filename, true), useCache));
            return ret;
        }

        /// <summary>
        /// Loads a sound track asset.
        /// </summary>
        /// <param name="filename">Sound track path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <returns>Loaded sound asset.</returns>
        public SoundAsset LoadSound(string filename, bool useCache = true)
        {
            var ret = new SoundAsset(_BonEngineBind.BON_Assets_LoadSound(ToAssetsPath(filename, true), useCache));
            return ret;
        }

        /// <summary>
        /// Loads a font asset.
        /// </summary>
        /// <param name="filename">Font track path.</param>
        /// <param name="fontSize">Font native size to load.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <returns>Loaded font asset.</returns>
        public FontAsset LoadFont(string filename, int fontSize, bool useCache = true)
        {
            var ret = new FontAsset(_BonEngineBind.BON_Assets_LoadFont(ToAssetsPath(filename, true), fontSize, useCache));
            return ret;
        }
    }
}
