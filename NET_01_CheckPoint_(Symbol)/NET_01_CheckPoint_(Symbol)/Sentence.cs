using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Sentence : ISentence
    {
        public string sentence { get; set; } // коллекция слов
        public String[] words { get; set;  } 
        public bool isQuestion { get; set; }
        //public string WordValue { get;set; }
        //public int Lenght { get;set; }
        //public bool startsWithLetter { get;set; }
        //public char SymbolValue { get; set; }

        public int wordsCount { get; set; }

        char[] patternEndWord = { ' ', ':', ';' };

        public Sentence(string sentence, bool isQuestion)
        {
            this.sentence = sentence;
            this.words = sentence.Split(patternEndWord);
            this.wordsCount = words.Length;
            this.isQuestion = isQuestion;
        }
        public override string ToString()
        {
            return String.Format("Sentence: {0}\n Word: {1}\n ", this.sentence,this.words.Length);
        }




        
    }
}
