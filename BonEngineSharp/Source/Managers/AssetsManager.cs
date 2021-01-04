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
        public string ToAssetsPath(string path, bool validate = true, bool useAssetsRoot = true)
        {
            // set asset path
            if (useAssetsRoot && !string.IsNullOrEmpty(AssetsRoot))
            {
                path = System.IO.Path.Combine(AssetsRoot, path);
            }

            // validate
            if (validate && !System.IO.File.Exists(path))
            {
                throw new Exception($"Asset file not found: '{path}'!");
            }

            // return path
            return path;
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
        /// <param name="path">Image path.</param>
        /// <param name="filter">Image filtering mode.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded image asset.</returns>
        public ImageAsset LoadImage(string path, ImageFilterMode filter = ImageFilterMode.Nearest, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new ImageAsset(_BonEngineBind.BON_Assets_LoadImage(ToAssetsPath(path, true, useAssetsRoot), (int)filter, useCache));
            ret.Path = path;
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
        /// <param name="path">Config path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded config asset.</returns>
        public ConfigAsset LoadConfig(string path, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new ConfigAsset(_BonEngineBind.BON_Assets_LoadConfig(ToAssetsPath(path, true, useAssetsRoot), useCache));
            ret.Path = path;
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
        /// <param name="config">Config asset to save.</param>
        /// <param name="path">Output file path.</param>
        /// <param name="useAssetsRoot">If true, will append path to assets root. If false, will treat it as relative path to working directory.</param>
        /// <returns>True if saving was successful.</returns>
        public bool SaveConfig(ConfigAsset config, string path, bool useAssetsRoot = true)
        {
            return _BonEngineBind.BON_Assets_SaveConfig(config._handle, useAssetsRoot ? ToAssetsPath(path, false) : path);
        }

        /// <summary>
        /// Saves an image file.
        /// </summary>
        /// <param name="image">Image asset to save.</param>
        /// <param name="path">Output file path.</param>
        /// <param name="useAssetsRoot">If true, will append path to assets root. If false, will treat it as relative path to working directory.</param>
        /// <returns>True if saving was successful.</returns>
        public void SaveImage(ImageAsset image, string path, bool useAssetsRoot = true)
        {
            image.SaveToFile(useAssetsRoot ? ToAssetsPath(path, false) : path);
        }

        /// <summary>
        /// Loads a music asset.
        /// </summary>
        /// <param name="path">Music file path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded music asset.</returns>
        public MusicAsset LoadMusic(string path, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new MusicAsset(_BonEngineBind.BON_Assets_LoadMusic(ToAssetsPath(path, true, useAssetsRoot), useCache));
            ret.Path = path;
            return ret;
        }

        /// <summary>
        /// Loads a sound track asset.
        /// </summary>
        /// <param name="path">Sound track path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded sound asset.</returns>
        public SoundAsset LoadSound(string path, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new SoundAsset(_BonEngineBind.BON_Assets_LoadSound(ToAssetsPath(path, true, useAssetsRoot), useCache));
            ret.Path = path;
            return ret;
        }

        /// <summary>
        /// Loads an effect asset.
        /// </summary>
        /// <param name="path">Effect ini file path.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded effect asset.</returns>
        public EffectAsset LoadEffect(string path, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new EffectAsset(_BonEngineBind.BON_Assets_LoadEffect(ToAssetsPath(path, true, useAssetsRoot), useCache));
            ret.Path = path;
            return ret;
        }

        /// <summary>
        /// Loads a font asset.
        /// </summary>
        /// <param name="path">Font track path.</param>
        /// <param name="fontSize">Font native size to load.</param>
        /// <param name="useCache">Should we use cache for this asset to make future loadings faster?</param>
        /// <param name="useAssetsRoot">If true, path will be relative to 'AssetsRoot'. If false, will be relative to working directory.</param>
        /// <returns>Loaded font asset.</returns>
        public FontAsset LoadFont(string path, int fontSize, bool useCache = true, bool useAssetsRoot = true)
        {
            var ret = new FontAsset(_BonEngineBind.BON_Assets_LoadFont(ToAssetsPath(path, true, useAssetsRoot), fontSize, useCache));
            ret.Path = path;
            return ret;
        }
    }
}
