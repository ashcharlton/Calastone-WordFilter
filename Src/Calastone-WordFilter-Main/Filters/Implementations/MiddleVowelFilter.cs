using Calastone_WordFilter_Main.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main.Filters.Implementations
{
    public class MiddleVowelFilter : ITextFilter
    {
        private readonly bool _ignoreCase;

        public MiddleVowelFilter(bool ignoreCase)
        {
            _ignoreCase = ignoreCase;
        }
        
        public bool IsValidText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            // Odd letter counts will have single middle character
            // Even letter counts will have 2. 
            // So getting the substring will require an offset to dynamically tell the substring method the size of the substring.
            var centerOffset = text.Length % 2 == 0 ? 1 : 0;

            var middleLetters = text.Substring(text.Length / 2 - centerOffset, centerOffset + 1);

            var vowelRegex = new Regex("[aeiou]", _ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);

            return !vowelRegex.IsMatch(middleLetters);
        }
    }
}
