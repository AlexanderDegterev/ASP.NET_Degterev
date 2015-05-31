using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface ISentence 
    {
        string SentenceStr { get; set; }
        List<IWord> Words { get; set; }
        int WordsCount { get; }
        bool IsQuestion { get; set; }
    }
}
