using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public class Sentence : ISentence
    {
        private string sentenceStr;
        public string SentenceStr
        {
            get
            {
                return sentenceStr;
            }
            set
            {
                sentenceStr = value;
            }
        }
        private List<IWord> words;
        public List<IWord> Words 
        { 
            get
            { 
                return words;
            }
            set
            {
                words = value;
            }
        }
        public int WordsCount 
        { 
            get
            {
                return  Words == null ? 0 : Words.Count;
            }
        }
        private bool isQuestion;
        public bool IsQuestion 
        {
            get
            {
                return isQuestion;
            }
            set
            {
                isQuestion = value;
            }
        }

        char[] patternEndWord = { ' ', ':', ';' };

        public Sentence(string sentence, bool isQuestion)
        {
            this.SentenceStr = sentence;
            this.IsQuestion = isQuestion;
        }
        public override string ToString()
        {
            return String.Format("Sentence: {0}\n Word: {1}\n ", this.SentenceStr, Words == null ? 0 : Words.Count);
        }
    }
}
