using Calastone_WordFilter_Main.Filters.Implementations;

namespace Calastone_WordFilter.Unit.Tests.FilterTests
{
    public class TextLengthFilterTests
    {
        [Theory]
        [InlineData("Foo", 2, true)]
        [InlineData("Test", 5, false)]
        [InlineData("Bar", 3, true)]
        [InlineData(null, 3, false)]
        [InlineData("Test", 0, true)]
        [InlineData(null, 0, false)]
        [InlineData("", 3, false)]
        [InlineData("", 0, false)]
        public void IsValidText_Returns_The_Correct_Result(string text, int minTextLength, bool isTextValid)
        {
            // Arrange
            var textLengthFilter = new TextLengthFilter(minTextLength);

            // Act
            var isValid = textLengthFilter.IsValidText(text);

            // Assert
            Assert.Equal(isTextValid, isValid);
        }
    }
}