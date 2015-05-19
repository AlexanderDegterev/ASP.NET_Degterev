using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    public interface IFlying
    {
        String Name {get; set;}
        DateTime ProductionDate {get; set;}
        int Price {get; set; }
        ushort Crew { get; set; }  //Экипаж
        int Weight { get; set; }   // Вес
        int FlyingRange { get; set; }  //Дальность полета
        Double FuelConsumption { get; set; }  //расход топлива
        int PassengersCapacity { get; set; }  //вместимость пасссажиров
        int LoadingCapacity { get; set; }  // грузоподъемность

        String GetInfo();
    }
}
