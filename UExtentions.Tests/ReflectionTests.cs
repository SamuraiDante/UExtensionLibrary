using System;
using System.Collections.Generic;
using Xunit;

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

        public class ReflectionTests
        {
            [Fact]
            public void GetPropertyValue_ReturnsCorrectString()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("StringProperty");
                Assert.Equal("Test String", result);
            }

            [Fact]
            public void GetPropertyValue_ReturnsCorrectInt()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("IntProperty");
                Assert.Equal("42", result);
            }

            [Fact]
            public void GetPropertyValue_ReturnsCorrectList()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("ListProperty");
                Assert.Equal("One\t\tTwo\t\tThree", result);
            }

            [Fact]
            public void GetPropertyValue_ReturnsNullForNullProperty()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("NullProperty");
                Assert.Equal("Null", result);
            }

            [Fact]
            public void GetPropertyValue_ReturnsCorrectEnum()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("EnumProperty");
                Assert.Equal("Second", result);
            }

            [Fact]
            public void GetPropertyValue_ReturnsPropertyNotFound()
            {
                var testObject = new TestClass();
                var result = testObject.GetPropertyValue("NonExistentProperty");
                Assert.Equal("Property not found", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsCorrectString()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "StringField");
                Assert.Equal("Test Field String", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsCorrectInt()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "IntField");
                Assert.Equal("84", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsCorrectList()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "ListField");
                Assert.Equal("Four\t\tFive\t\tSix", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsNullForNullField()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "NullField");
                Assert.Equal("Null", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsCorrectEnum()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "EnumField");
                Assert.Equal("Third", result);
            }

            [Fact]
            public void GetFieldValue_ReturnsFieldNotFound()
            {
                var testObject = new TestClass();
                var result = Reflection.GetFieldValue(testObject, "NonExistentField");
                Assert.Equal("Field not found", result);
            }
        }
    }
}
