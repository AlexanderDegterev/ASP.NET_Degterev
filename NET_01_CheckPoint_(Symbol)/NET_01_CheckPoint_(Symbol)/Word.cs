using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Word : IWord
    {
        public char firstChar { get; set; }
        public string wordValue { get; set; }
        public int lenght { get; set; }
        
        public Word(string wordValue)
        {
            this.firstChar = wordValue.Length > 0 ? wordValue[0] : '\0' ;
            this.wordValue = wordValue;
            this.lenght = wordValue.Length;
        }
        
    }
    
}

