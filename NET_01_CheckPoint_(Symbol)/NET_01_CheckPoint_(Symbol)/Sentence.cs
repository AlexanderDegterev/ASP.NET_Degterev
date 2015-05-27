using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    public class Sentence : ISentence
    {
        public string sentence { get; set; } // коллекция слов
        public int wordsCounter { get; set; }
        public bool isQuestion { get; set; }
        //public string WordValue { get;set; }
        //public int Lenght { get;set; }
        //public bool startsWithLetter { get;set; }
        //public char SymbolValue { get; set; }
    }
}
