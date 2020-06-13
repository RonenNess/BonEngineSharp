using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Config asset type.
    /// This asset loads a config file (.ini format in default implementation) and provide API to retrieve or set data from it.
    /// </summary>
    public class ConfigAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public ConfigAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Config;

        /// <summary>
        /// Get a string value from config.
        /// </summary>
        /// <param name="section">Section to get value from.</param>
        /// <param name="key">Key to get.</param>
        /// <param name="defaultVal">Default value to return if not found.</param>
        /// <returns>Value from config, or defaultVal if not found.</returns>
        public string GetStr(string section, string key, string defaultVal = null)
        {
            return _BonEngineBind.BON_Config_GetStr_(_handle, section, key, default);
        }

        /// <summary>
        /// Get an int value from config.
        /// </summary>
        /// <param name="section">Section to get value from.</param>
        /// <param name="key">Key to get.</param>
        /// <param name="defaultVal">Default value to return if not found.</param>
        /// <returns>Value from config, or defaultVal if not found.</returns>
        public int GetInt(string section, string key, int defaultVal = 0)
        {
            return _BonEngineBind.BON_Config_GetInt(_handle, section, key, defaultVal);
        }

        /// <summary>
        /// Get a float value from config.
        /// </summary>
        /// <param name="section">Section to get value from.</param>
        /// <param name="key">Key to get.</param>
        /// <param name="defaultVal">Default value to return if not found.</param>
        /// <returns>Value from config, or defaultVal if not found.</returns>
        public float GetFloat(string section, string key, float defaultVal = 0f)
        {
            return _BonEngineBind.BON_Config_GetFloat(_handle, section, key, defaultVal);
        }

        /// <summary>
        /// Get a bool value from config.
        /// </summary>
        /// <param name="section">Section to get value from.</param>
        /// <param name="key">Key to get.</param>
        /// <param name="defaultVal">Default value to return if not found.</param>
        /// <returns>Value from config, or defaultVal if not found.</returns>
        public bool GetBool(string section, string key, bool defaultVal = false)
        {
            return _BonEngineBind.BON_Config_GetBool(_handle, section, key, defaultVal);
        }

        /// <summary>
        /// Set value in config.
        /// </summary>
        /// <param name="section">Section to set value in.</param>
        /// <param name="key">Key to set.</param>
        /// <param name="value">Value to set (will be stringified with ToString()).</param>
        public void SetValue(string section, string key, object value)
        {
            _BonEngineBind.BON_Config_SetValue(_handle, section, key, value.ToString());
        }

        /// <summary>
        /// Remove a key from config.
        /// </summary>
        /// <param name="section">Section to remove key from.</param>
        /// <param name="key">Key to remove.</param>
        public void RemoveKey(string section, string key)
        {
            _BonEngineBind.BON_Config_RemoveKey(_handle, section, key);
        }

        /// <summary>
        /// Get all sections in config.
        /// </summary>
        public string[] Sections()
        {
            int count = _BonEngineBind.BON_Config_SectionsCount(_handle);
            string[] ret = new string[count];
            for (var i = 0; i < count; ++i)
            {
                ret[i] = _BonEngineBind.BON_Config_Section_Str(_handle, i);
            }
            return ret;
        }

        /// <summary>
        /// Get all keys in a section.
        /// </summary>
        /// <param name="section">Section to get keys from.</param>
        public string[] Keys(string section)
        {
            int count = _BonEngineBind.BON_Config_KeysCount(_handle, section);
            string[] ret = new string[count];
            for (var i = 0; i < count; ++i)
            {
                ret[i] = _BonEngineBind.BON_Config_Key_Str(_handle, section, i);
            }
            return ret;
        }

        /// <summary>
        /// Convert this config to string in ini format.
        /// </summary>
        /// <returns>Config as ini file string.</returns>
        public string ToIniString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var section in Sections())
            {
                sb.Append("[" + section + "]");
                sb.Append('\n');
                foreach (var key in Keys(section))
                {
                    sb.Append(key);
                    sb.Append(" = ");
                    sb.Append(GetStr(section, key));
                    sb.Append('\n');
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~ConfigAsset()
        {
            Dispose();
        }

    }
}
