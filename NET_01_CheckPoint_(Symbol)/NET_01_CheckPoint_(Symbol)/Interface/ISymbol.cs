using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface ISymbol : ISentence
    {
        char SymbolValue {get; set;}
    }
}
