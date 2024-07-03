using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UExtensionLibrary.Extensions
{
    public static class Reflection
    {
        /// <summary>
        /// Gets the specified property's value.
        /// </summary>
        /// <param name="objObject">The containing object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The property's value or a message indicating failure.</returns>
        public static object GetPropertyValue(this object objObject, string propertyName)
        {
            if (objObject == null || string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(objObject), "Object or property name cannot be null.");
            }

            try
            {
                PropertyInfo propertyInfo = objObject.GetType().GetProperty(propertyName);
                if (propertyInfo == null)
                {
                    return "Property not found";
                }

                object value = propertyInfo.GetValue(objObject);
                return GetValueAsString(value);
            }
            catch (Exception ex)
            {
                return $"Unable to determine value: {ex.Message}";
            }
        }

        /// <summary>
        /// Gets the specified field's value.
        /// </summary>
        /// <param name="objObject">The containing object.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The field's value or a message indicating failure.</returns>
        public static object GetFieldValue(this object objObject, string fieldName)
        {
            if (objObject == null || string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException(nameof(objObject), "Object or field name cannot be null.");
            }

            try
            {
                FieldInfo fieldInfo = objObject.GetType().GetField(fieldName);
                if (fieldInfo == null)
                {
                    return "Field not found";
                }

                object value = fieldInfo.GetValue(objObject);
                return GetValueAsString(value);
            }
            catch (Exception ex)
            {
                return $"Unable to determine value: {ex.Message}";
            }
        }

        /// <summary>
        /// Converts an object value to a string representation.
        /// </summary>
        /// <param name="value">The object value.</param>
        /// <returns>A string representation of the value.</returns>
        private static string GetValueAsString(object value)
        {
            if (value == null)
            {
                return "Null";
            }

            if (value is string strValue)
            {
                return strValue;
            }

            if (value is IEnumerable enumerableValue && !(value is string))
            {
                var items = enumerableValue.Cast<object>().Select(item => item?.ToString() ?? "Null").ToArray();
                return items.Any() ? string.Join("\t\t", items) : "Empty";
            }

            return value.ToString();
        }
    }
}

