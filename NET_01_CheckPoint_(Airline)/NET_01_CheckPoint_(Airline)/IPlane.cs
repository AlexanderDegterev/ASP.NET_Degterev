using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    interface IPlane : IAirline
    {
        ushort Crew {get; set; }  //Экипаж
        int Weight {get; set; }   // Вес
        int FlyingRange {get; set; }  //Дальность полета
        Double FuelConsumption { get; set; }  //расход топлива
    }
}
