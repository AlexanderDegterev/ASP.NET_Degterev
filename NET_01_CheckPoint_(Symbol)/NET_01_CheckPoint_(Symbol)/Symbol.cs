using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    public class Symbol :ISymbol
    {
        public char SymbolValue { get; set; }

        public Symbol(char ch)
        {
            SymbolValue = ch;
        }
        public Symbol()
        {
        }
        
    }
}
