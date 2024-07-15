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
    public static class CSettings<T> where T : new()
    {

        private static readonly string SaveFileLocation = Environment.SpecialFolder.CommonApplicationData.ToString() + @"\" + Application.ProductName + "_" + typeof(T).Name + ".json";


        /// ------------------------------------------------------------------------------------------
        ///  Name: Get
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the value for the specified key. </summary>
        /// <param name="Key">The setting key</param>
        /// <param name="Value"></param>
        /// <returns>System.Object.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static bool Load(out T Value) 
        {

            bool ReturnValue = false;
            //Uncache the settings file
            FileInfo fiSettings = new FileInfo(SaveFileLocation);

            if (fiSettings.Exists)
            {
                ReturnValue = true;
                Value = Serialization.DeserializeFile<T>(fiSettings.FullName);
            }
            else
            {
                //If we dont have a save yet send back a fresh one
                Value = new T();
            }

           


            return ReturnValue;
        }

        /// ------------------------------------------------------------------------------------------
        ///  Name: Set
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Sets the value for the specified key. </summary>
        /// <param name="Key">The setting key.</param>
        /// <param name="Value">The value to assign</param>
        ///  ------------------------------------------------------------------------------------------
        public static void Save(T Value)
        {
            FileInfo fiSettings = new FileInfo(SaveFileLocation);
            if (fiSettings.Exists) fiSettings.Delete();
            Serialization.CacheObject(Value, fiSettings.FullName);
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
