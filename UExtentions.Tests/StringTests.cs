

namespace UExtensionLibrary.Extensions.Test
{
    public class StringsTests
    {
        [Fact]
        public void GetFirstBetween_ReturnsCorrectSubstring()
        {
            string input = "This is a [sample] string.";
            string start = "[";
            string end = "]";
            string expected = "sample";

            string result = input.GetFirstBetween(start, end);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetFirstBetween_ReturnsNullIfStartNotFound()
        {
            string input = "This is a sample string.";
            string start = "[";
            string end = "]";

            string result = input.GetFirstBetween(start, end);

            Assert.Null(result);
        }

        [Fact]
        public void GetFirstBetween_ReturnsNullIfEndNotFound()
        {
            string input = "This is a [sample string.";
            string start = "[";
            string end = "]";

            string result = input.GetFirstBetween(start, end);

            Assert.Null(result);
        }

        [Fact]
        public void CharacterInstanceCount_ReturnsCorrectCount()
        {
            string input = "Hello, World!";
            char character = 'o';
            int expected = 2;

            int result = input.CharacterInstanceCount(character);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TrimSplit_WithCharArraySeparator_ReturnsTrimmedStrings()
        {
            string input = "  one , two , three  ";
            char[] separator = new char[] { ',' };
            string[] expected = new string[] { "one", "two", "three" };

            string[] result = input.TrimSplit(separator);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TrimSplit_WithStringSeparator_ReturnsTrimmedStrings()
        {
            string input = "  one , two , three  ";
            string separator = ",";
            string[] expected = new string[] { "one", "two", "three" };

            string[] result = input.TrimSplit(separator);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToByteArray_ReturnsCorrectByteArray()
        {
            string input = "Hello";
            byte[] expected = new byte[] { 72, 101, 108, 108, 111 };

            byte[] result = input.ToByteArray();

            Assert.Equal(expected, result);
        }
    }
}