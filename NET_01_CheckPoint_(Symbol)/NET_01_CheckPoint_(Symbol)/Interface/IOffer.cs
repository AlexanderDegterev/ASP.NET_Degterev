using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    interface IOffer : IWord
    {
        int CountWord { get; set; }
    }
}
