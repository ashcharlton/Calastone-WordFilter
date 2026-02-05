using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calastone_WordFilter_Main.Filters.Interfaces
{
    public interface ITextFilter
    {
        bool IsValidText(string text);
    }
}
