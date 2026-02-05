using Calastone_WordFilter_Main.Filters.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calastone_WordFilter.Unit.Tests.FilterTests
{
    public class TextContainsLetterFilterTests
    {
        [Theory]
        [InlineData("Fact", 't', true, false)]
        [InlineData("Fact", 'T', false, true)]
        [InlineData("Fact", 'T', true, false)]
        [InlineData("FacT", 'T', true, false)]
        [InlineData("Face", 't', true, true)]
        [InlineData("Face", 't', false, true)]
        [InlineData("", 't', false, false)]
        [InlineData("", 't', true, false)]
        [InlineData("", 'T', false, false)]
        [InlineData("", 'T', true, false)]
        [InlineData(null, 'T', true, false)]
        [InlineData(null, 'T', false, false)]
        [InlineData(null, 't', true, false)]
        [InlineData(null, 't', false, false)]
        public void Checking_Text_Contains_Letter_Return_Correct_Valid_Response(string text, char containingLetter, bool ignoreCase, bool isTextValid)
        {
            // Arrange
            var textContainsLetterFilter = new TextContainsLetterFilter(containingLetter, ignoreCase);

            // Act
            var isValid = textContainsLetterFilter.IsValidText(text);

            // Assert
            Assert.Equal(isTextValid, isValid);
        }
    }
}
