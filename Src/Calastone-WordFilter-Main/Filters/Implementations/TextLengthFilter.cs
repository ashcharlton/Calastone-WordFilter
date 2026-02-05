using Calastone_WordFilter_Main.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Calastone_WordFilter_Main.Extensions;

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
            if(string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return text.Sanitise().Length >= _minTextLength;
        }
    }
}
