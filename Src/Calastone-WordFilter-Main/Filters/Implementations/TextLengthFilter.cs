using Calastone_WordFilter_Main.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main.Filters.Implementations
{
    public class TextLengthFilter : ITextFilter
    {
        private readonly int _minTextLength;

        public TextLengthFilter(int minTextLength)
        {
            _minTextLength = minTextLength;
        }

        public bool IsValidText(string text)
        {
            return text.Length >= _minTextLength;
        }
    }
}
