using System;
using System.Collections.Generic;
using System.IO;
using UExtensionLibrary.Extensions;

namespace UExtensionLibrary.Classes
{
    public static class CSettings
    {

        private static readonly string SaveFileLocation = Environment.SpecialFolder.CommonApplicationData.ToString();
        private static Dictionary<String, object> Settings;
        private static bool IsDirty = false;

        /// ------------------------------------------------------------------------------------------
        ///  Name: Initialize
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Initializes this instance, mainly getting Settings file data. </summary>
        ///  ------------------------------------------------------------------------------------------
        private static void Initialize()
        {
            FileInfo fiSettings = new FileInfo(SaveFileLocation);
            Settings = fiSettings.Exists ? Serialization.DeserializeFile<Dictionary<String, object>>(fiSettings.FullName) : new Dictionary<string, object>();
        }

        /// ------------------------------------------------------------------------------------------
        ///  Name: Dispose
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Clears memory and saves any changes to file </summary>
        ///  ------------------------------------------------------------------------------------------
        private static void Dispose()
        {
            if (IsDirty)
            {
                FileInfo fiSettings = new FileInfo(SaveFileLocation);
                if (fiSettings.Exists) fiSettings.Delete();
                Serialization.CacheObject(Settings, fiSettings.FullName); 
            }
            Settings = null;
        }


        /// ------------------------------------------------------------------------------------------
        ///  Name: Get
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the value for the specified key. </summary>
        /// <param name="Key">The setting key</param>
        /// <returns>System.Object.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static object Get(string Key)
        {
            object objReturn = null;

            Initialize();

            objReturn = Settings[Key];

            Dispose();

            return objReturn;
        }

        /// ------------------------------------------------------------------------------------------
        ///  Name: Set
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Sets the value for the specified key. </summary>
        /// <param name="Key">The setting key.</param>
        /// <param name="Value">The value to assign</param>
        ///  ------------------------------------------------------------------------------------------
        public static void Set(string Key, object Value)
        {
            Initialize();

            IsDirty = true;
            if (Settings.ContainsKey(Key)) Settings[Key] = Value;
            else Settings.Add(Key, Value);

            Dispose();
        }


        /// ------------------------------------------------------------------------------------------
        ///  Name: ClearValues
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Clears all values for all settings, but leaves Settings. </summary>
        ///  ------------------------------------------------------------------------------------------
        public static void ClearValues()
        {
            
        }

    }
}
