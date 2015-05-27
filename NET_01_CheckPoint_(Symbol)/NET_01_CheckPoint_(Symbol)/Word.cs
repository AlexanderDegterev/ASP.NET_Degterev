using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    public class Word :IWord
    {
        char firstChar;
        char[] word;
        public string WordValue { get; set; }
        public int Lenght { get; set; }
        public bool startsWithLetter { get; set; }
        private char current;
        
        public Word(char current)
            {
            this.word = current;
            }         
        
        public void addChar(char ch) {
            if (firstChar == '\0')
            {
                firstChar = ch;
            }
            word[1] = ch;
            /*word[]=ch;
            word.Add(ch);
            word.Add(new Word(ch));
            word.add(ch);*/
        }
    
}
}
