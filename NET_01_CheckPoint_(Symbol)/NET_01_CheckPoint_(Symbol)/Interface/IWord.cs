using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface IWord 
    {
        char firstChar { get; set; }
        string wordValue { get; set; }
        int lenght { get; set; }
        //bool startsWithLetter { get; set; }  // SOGLASNAYA

        
    }
}
