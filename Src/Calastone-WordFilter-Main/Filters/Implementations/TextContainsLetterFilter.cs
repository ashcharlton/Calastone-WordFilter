using Calastone_WordFilter_Main.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main.Filters.Implementations
{
    public class TextContainsLetterFilter : ITextFilter
    {
        // Using a char to force a single letter. No need to check a string for a single letter.
        // Making the code more readable. 
        private readonly char _containingLetter;
        private readonly bool _ignoreCase;

        public TextContainsLetterFilter(char containingLetter, bool ignoreCase = true)
        {
            _containingLetter = containingLetter;
            _ignoreCase = ignoreCase;

        }

        public bool IsValidText(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return !text.Contains(
                _containingLetter, 
                _ignoreCase ? StringComparison.InvariantCultureIgnoreCase: StringComparison.InvariantCulture
            );
        }
    }
}
