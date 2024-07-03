using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Forms;
using UExtensionLibrary.Extensions;

namespace UExtensionLibrary.Classes.CSettings
{
    /// <summary>
    /// Class used to help store various settings in a cache file, quick and dirty
    /// </summary>
    public static class CSettings
    {

        private static readonly string SaveFileLocation = Environment.SpecialFolder.CommonApplicationData.ToString() + @"\" + Application.ProductName + "_Settings.json";
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
        /// <param name="Value"></param>
        /// <returns>System.Object.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static bool Get<T>(string Key, out T Value) 
        {

            bool ReturnValue = false;
            //Uncache the settings file
            Initialize();

            //If we have the key, return the value
            if (Settings.ContainsKey(Key))
            {
                Value = (T)Settings[Key];
                ReturnValue = true;
            }
            else
            {
                Value = default;
                ReturnValue = false;
            }
            //Clean up
            Dispose();

            return ReturnValue;
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

            //Let's us know to save in the dispose method
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
