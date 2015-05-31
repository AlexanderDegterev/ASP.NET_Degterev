using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Word : IWord
    {
        private char firstChar;
        public char FirstChar 
        {
            get
            {
                return firstChar;
            }
            set
            {
                firstChar = value;
            }
        }
        public string wordValue;
        public string WordValue 
        {
            get
            {
                return wordValue;
            }
            set
            {
                wordValue = value;
            }
        }
        private int lenght;
        public int Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
            }
        }
        
        public Word(string wordValue)
        {
            this.FirstChar = wordValue.Length > 0 ? wordValue[0] : '\0' ;
            this.WordValue = wordValue;
            this.Lenght = wordValue.Length;
        }
        
    }
    
}

