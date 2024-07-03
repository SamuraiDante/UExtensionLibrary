

using System;
using System.Linq;
using System.Reflection;

namespace UExtensionLibrary.Extensions
{
    public static partial class ObjectExtentions
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

        /// <summary>
        /// Variation on explicit casting, allows for cast to come at the end, for easier reading/writing
        /// </summary>
        /// <typeparam name="T">Type to cast to</typeparam>
        /// <param name="obj">object to be cast</param>
        /// <returns>(T)obj</returns>
        public static T As<T>(this object obj)
        {
            return (T)obj;
        }
        

    }
}

namespace UExtensionLibrary.Methods
{
    public static partial class Objects
    {
        /// <summary>
        /// Compares each property and field in both objects.
        /// </summary>
        /// <typeparam name="T">Type to use for comparison</typeparam>
        /// <param name="Left">Object to compare to Right</param>
        /// <param name="Right">Object to compare to Left</param>
        /// <returns>true, if all fields and properties are equal</returns>
        public static bool MemberwiseCompare<T>(T Left, T Right)
        {
            bool ReturnValue = true;
            Type ComparisonType = typeof(T);
            PropertyInfo[] Properties = ComparisonType.GetProperties().ToArray();
            foreach (PropertyInfo Property in Properties)
            {
                var LeftValue = Property.GetValue(Left);
                var RightValue = Property.GetValue(Right);
                if (LeftValue != RightValue) { ReturnValue = false; }
            }

            FieldInfo[] Fields = ComparisonType.GetFields().ToArray();
            foreach (FieldInfo Field in Fields)
            {
                var LeftValue = Field.GetValue(Left);
                var RightValue = Field.GetValue(Right);
                if (LeftValue != RightValue) { ReturnValue = false; }
            }
            return ReturnValue;
        }
    }
}
