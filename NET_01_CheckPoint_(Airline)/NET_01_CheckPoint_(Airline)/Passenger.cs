﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    public class Passenger : Flying, IPassenger
    {
        public Make Make { get; set; }
    }
}
