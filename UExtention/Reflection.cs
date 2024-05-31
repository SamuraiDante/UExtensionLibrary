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

namespace UExtensionLibrary.Extensions.Test
{
    public class ReflectionTest
    {
        public enum TestEnum
        {
            First,
            Second,
            Third
        }

        public class TestClass
        {
            public string StringProperty { get; set; } = "Test String";
            public int IntProperty { get; set; } = 42;
            public List<string> ListProperty { get; set; } = new List<string> { "One", "Two", "Three" };
            public string NullProperty { get; set; } = null;
            public TestEnum EnumProperty { get; set; } = TestEnum.Second;
            public string StringField = "Test Field String";
            public int IntField = 84;
            public List<string> ListField = new List<string> { "Four", "Five", "Six" };
            public string NullField = null;
            public TestEnum EnumField = TestEnum.Third;
        }

        public static void RunTests()
        {
            var testObject = new TestClass();

            // Test GetPropertyValue
            Console.WriteLine(testObject.GetPropertyValue("StringProperty")); // Expected: "Test String"
            Console.WriteLine(testObject.GetPropertyValue("IntProperty")); // Expected: "42"
            Console.WriteLine(testObject.GetPropertyValue("ListProperty")); // Expected: "One\t\tTwo\t\tThree"
            Console.WriteLine(testObject.GetPropertyValue("NullProperty")); // Expected: "Null"
            Console.WriteLine(testObject.GetPropertyValue("EnumProperty")); // Expected: "Second"
            Console.WriteLine(testObject.GetPropertyValue("NonExistentProperty")); // Expected: "Property not found"

            // Test GetFieldValue
            Console.WriteLine(Reflection.GetFieldValue(testObject, "StringField")); // Expected: "Test Field String"
            Console.WriteLine(Reflection.GetFieldValue(testObject, "IntField")); // Expected: "84"
            Console.WriteLine(Reflection.GetFieldValue(testObject, "ListField")); // Expected: "Four\t\tFive\t\tSix"
            Console.WriteLine(Reflection.GetFieldValue(testObject, "NullField")); // Expected: "Null"
            Console.WriteLine(Reflection.GetFieldValue(testObject, "EnumField")); // Expected: "Third"
            Console.WriteLine(Reflection.GetFieldValue(testObject, "NonExistentField")); // Expected: "Field not found"
        }

    }
}
