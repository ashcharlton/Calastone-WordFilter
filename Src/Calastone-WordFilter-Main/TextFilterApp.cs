using Calastone_WordFilter_Main.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main
{
    public class TextFilterApp
    {
        private readonly IEnumerable<ITextFilter> _filters;

        public TextFilterApp(IEnumerable<ITextFilter> filters)
        {
            _filters = filters;
        }

        public async Task RunAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at {filePath}");
                return;
            }

            string rawText = await File.ReadAllTextAsync(filePath);

            // Sanitize and split into words (handling punctuation)
            var words = GetCleanWords(rawText);

            var filteredWords = words.Where(word =>
                _filters.All(filter => filter.IsValidText(word))
            ).ToArray();

            Console.WriteLine(string.Join(" ", filteredWords));
        }

        private IEnumerable<string> GetCleanWords(string input)
        {
            return Regex.Matches(input, @"\p{L}+(?:['`]\p{L}+)*")
                        .Cast<Match>()
                        .Select(m => m.Value);
        }
    }
}
