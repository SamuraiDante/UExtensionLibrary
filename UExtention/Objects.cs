

using System;
using UExtensionLibrary.Reflection;

namespace UExtensionLibrary.Objects
{
    public static class Objects
    {
        /// <summary>
        /// Performs check to see if object is DBNull, and if so changes it to .Net null
        /// </summary>
        /// <param name="objBase">Object to check</param>
        /// <returns>If object is DBNull, returns null, else returns object</returns>
        public static object SafeValue(this object objBase)
        {

            if (DBNull.Value.Equals(objBase)) objBase = null;
            return objBase;
        }
        /// <summary>
        /// Checks if object is null, then looks for the property.
        /// </summary>
        /// <param name="CheckObject">Object to check for null</param>
        /// <param name="CheckObjectProperty">Property to get value from</param>
        /// <param name="NullResultString">String to return if @CheckObject is null</param>
        /// <returns>If Object is null, returns @NullResultString, else returns specified properties value as string</returns>
        public static string SafeDisplay(this object CheckObject, string CheckObjectProperty, string NullResultString)
        {
            string ReturnString = NullResultString;
            if (CheckObject != null) ReturnString = CheckObject.GetPropertyValue(CheckObjectProperty).ToString();
            return ReturnString;
        }

    }
}
