using Calastone_WordFilter_Main.Filters.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calastone_WordFilter.Unit.Tests.FilterTests
{
    public class MiddleVowelFilterTests
    {
        [Theory]
        [InlineData("Fact", true, false)]
        [InlineData("FAct", false, true)]
        [InlineData("FAct", true, false)]
        [InlineData("Atta", true, true)]
        [InlineData("Atta", false, true)]
        [InlineData("ATTa", false, true)]
        [InlineData("ATTa", true, true)]
        [InlineData("", false, false)]
        [InlineData("", true, false)]
        [InlineData(null, true, false)]
        [InlineData(null, false, false)]
        public void Check_Text_Matches_Vowel_Regex_Should_Return_Correct_Valid_Result(string text, bool ignoreCase, bool isTextValid)
        {
            // Arrange
            var middleVowelFilter = new MiddleVowelFilter(ignoreCase);

            // Act
            var isValid = middleVowelFilter.IsValidText(text);

            // Assert
            Assert.Equal(isTextValid, isValid);
        }
    }
}
