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

            fillAirportWithAircrafts(airport);

            Console.WriteLine("\n Вывод данных: \n");
            airport.PrintInfoToConsole();
            

            airport.SortByProductionDate();
            Console.WriteLine("\n Сортировка по ProductionDate");
            airport.PrintInfoToConsole();
            
           
            Console.WriteLine("\nВместимость всех Т/С: " + airport.TotalPassengersCapacity() + " пассажиров");
            Console.WriteLine("\nОбщая грузоподъемность всех судов: " + airport.TotalLoadingCapacity() + " кг");

        }

        private static void fillAirportWithAircrafts(AirPort airport)
        {
            airport.Add(new Helicopter()
            {
                Name = "KA-226   ",
                Price = 150000,
                ProductionDate = new DateTime(2015, 05, 15),
                FlyingRange = 3000,
                FuelConsumption = 14,
                PassengersCapacity = 10,
                LoadingCapacity = 8000,
                TypeHelicopter = TypeHelicopter.Medical

            }
                );
            airport.Add(new Passenger("Boing-777", new DateTime(2010, 01, 01), 230000,4,315000,9700,250,145,48000)
            /*{
                Name = "Boing-777",
                Price = 230000,
                ProductionDate = new DateTime(2010, 01, 01),
                Crew = 4,
                Weight = 315000,
                FlyingRange = 9700,
                FuelConsumption = 250,
                PassengersCapacity = 145,
                LoadingCapacity = 48000
            }*/
            );
            airport.Add(new Cargo()
            {
                Name = "Airbus A400",
                Price = 312000,
                ProductionDate = new DateTime(2012, 02, 02),
                FlyingRange = 9900,
                FuelConsumption = 400,
                PassengersCapacity = 0,
                LoadingCapacity = 60000,
                Volume = 350
            }
            );
        }
    }
}
