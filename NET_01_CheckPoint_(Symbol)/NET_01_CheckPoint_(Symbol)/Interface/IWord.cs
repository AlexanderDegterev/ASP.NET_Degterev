using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    public interface IWord 
    {
        char FirstChar { get; set; }
        string WordValue { get; set; }
        int Lenght { get; set; }
    }
}
