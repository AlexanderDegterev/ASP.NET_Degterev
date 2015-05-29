using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Word :IWord
    {
        public char FirstChar{ get{return word[0];}}
        string word;
        public string WordValue { get; set; }
        public int Lenght { get; set; }
        public bool startsWithLetter { get; set; }
        private char current;

        public Word(string source)
        {
            this.word = source;
        }    
     
    }
    
}

