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
        public int wordsCounter { get { return sentence[0]; } }
        public bool isQuestion { get; set; }
        //public string WordValue { get;set; }
        //public int Lenght { get;set; }
        //public bool startsWithLetter { get;set; }
        //public char SymbolValue { get; set; }

        public Sentence(string source)
        {
            this.sentence = source;
        }
        public override string ToString()
        {
            return String.Format("Предложение: {0}\n ", this.sentence);
        }




        
    }
}
