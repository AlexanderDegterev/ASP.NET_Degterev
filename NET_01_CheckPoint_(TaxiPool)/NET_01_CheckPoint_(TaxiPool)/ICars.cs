using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET_01_CheckPoint__TaxiStation_
{
    public interface ICars
    {
        string Brand { get; set; }
        string Model { get; set; }
        int Price { get; set; }
        DateTime YearProduction { get; set; }
        int FuelUsage { get; set; }  // расход типлива
        int Speed { get; set; }  // скорость

        string getInfo();
    }
}
