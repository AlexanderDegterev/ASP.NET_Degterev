using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Sentence : ISentence
    {
        public string sentence { get; set; } 
        public List<IWord> words { get; set;  }
        public int wordsCount { get
        {
            return  words == null ? 0 : words.Count;
        }
        }
        public bool isQuestion { get; set; }

        char[] patternEndWord = { ' ', ':', ';' };

        public Sentence(string sentence, bool isQuestion)
        {
            this.sentence = sentence;
            this.isQuestion = isQuestion;
        }
        public override string ToString()
        {
            return String.Format("Sentence: {0}\n Word: {1}\n ", this.sentence, words == null ? 0 : words.Count);
        }




        
    }
}
