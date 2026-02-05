using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main.Extensions
{
    public static class StringExtensions
    {
        // Pre-compiling the regex for better performance
        private static readonly Regex InnerPunctuationRegex =
            new Regex(@"(?<=[a-zA-Z])\p{P}(?=[a-zA-Z])", RegexOptions.Compiled);

        /// <summary>
        /// Removes punctuation found specifically within words (e.g., can't -> cant).
        /// </summary>
        public static string Sanitise(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return InnerPunctuationRegex.Replace(input, string.Empty);
        }
    }
}
