using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface ISentence 
    {
        string sentence { get; set; }
        List<IWord> words { get; set; }
        int wordsCount { get; }
        bool isQuestion { get; set; }
    }
}
