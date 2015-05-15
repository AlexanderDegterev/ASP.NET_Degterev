using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    class Program
    {
        static void Main(string[] args)
        {
            AirPort airport = new AirPort();

            airport.Add(new Helicopter()
            {
                Name = "KA-226   ",
                Price = 150000,
                ProductionDate = new DateTime(2015, 05, 15),
                FlyingRange = 3000,
                FuelConsumption = 14,
                PassengersCapacity = 10,
                LoadingCapacity = 8000
                
            }
                );
            airport.Add(new Passenger()
            {
                Name = "Boing-777",
                Price = 230000,
                ProductionDate = new DateTime(2010, 01, 01),
                Crew = 4,                
                Weight = 315000,
                FlyingRange = 9700,
                FuelConsumption = 250,
                PassengersCapacity = 145
            }
            );
            airport.Add(new Cargo()
            {
                Name = "Airbus A400",
                Price = 312000,
                ProductionDate = new DateTime(2012, 02, 02),
                FlyingRange = 9900,
                FuelConsumption = 400,
                PassengersCapacity = 0
            }
            );

            Console.WriteLine("\n Вывод данных: \n");
            foreach (var i in airport)
            {                
                Console.WriteLine(i.getInfo());
            }

            airport.SortByProductionDate();
            Console.WriteLine("\n Сортировка по ProductionDate");
            
            double sumpas = 0;
            foreach (var i in airport)
            {
                sumpas += i.FuelConsumption;

                Console.WriteLine(i.getInfo());
                //Console.WriteLine(i.CapacityPassenger());
            }
            Console.WriteLine("Sum "+ sumpas);
        
           /* public int CapacityPassenger()
        {
            ICollection<IFlying> flying = new List<IFlying>();
            //return flying.Sum(a => a.PassengersCapacity);
            return flying.Sum(item => item.PassengersCapacity);
            
        }
            Console.WriteLine("Площадь круга равна {0:#.###}", CapacityPassenger());*/
            

        }
    }
}
