﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    public interface ISentence : IWord
    {
        string sentence { get; set; }
        int wordsCounter { get; set; }
        bool isQuestion { get; set; }
    }
}