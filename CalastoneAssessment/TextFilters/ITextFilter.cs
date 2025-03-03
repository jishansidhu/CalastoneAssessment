using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TextFilters
{
    public interface ITextFilter
    {
        void SetNext(ITextFilter nextFilter);
        string Apply(string text);
    }
}
