using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface IWord 
    {
        string WordValue { get; set; }
        int Lenght { get; set; }
        bool startsWithLetter { get; set; }  // SOGLASNAYA
        
       
                
    }
}
