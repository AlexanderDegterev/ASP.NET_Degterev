﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface IDTS
    {
        string nameDTS {get;set;}
        PortCondition PortCondition { get; set; }
    }
}
