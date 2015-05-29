using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Symbol
    {
        public char SymbolValue { get; set; }

        public Symbol(char ch)
        {
            SymbolValue = ch;
        }
        public Symbol()
        {
        }
        public string sentence { get; set; }       

        public int wordsCounter { get; set; }

        public bool isQuestion { get; set; }
        
    }
}
