using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Word : IWord
    {
        public char firstChar { get; set; }//{ get { return wordValue[0]; } }
        public string wordValue { get; set; }
        public int lenght { get; set; }
        //public bool startsWithLetter { get; set; }

        //public Word() { }

        //public Word()
        //{
        //    this.firstChar = firstChar;
        //    this.wordValue = wordValue;
        //    this.lenght = lenght;
        //    this.startsWithLetter = startsWithLetter;
        //}

        public Word(string wordValue)
            
        {
            this.firstChar = wordValue.Length > 0 ? wordValue[0] : '\0' ;
            this.wordValue = wordValue;
            this.lenght = wordValue.Length;
            //this.startsWithLetter = startsWithLetter;

        }
        
    }
    
}

