using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    public class Program
    {

        //Интерфейсы, Конструкторы, NameConvention
        private static void Main(string[] args)
        {
            AirPort airport = new AirPort();

            FillAirportWithAircrafts(airport);

            Console.WriteLine("\n Data output: \n");
            PrintInfoToConsole(airport);
            
            airport.SortByProductionDate();
            Console.WriteLine("\n Sorting according to date of production");
            PrintInfoToConsole(airport);

            Console.WriteLine("\n Sorting according to range of flights");
            PrintInfoToConsole(airport.SortByFlyingRange());

            //Console.WriteLine("\nВместимость всех судов: " + airport.TotalPassengersCapacity() + " пассажиров");
            Console.WriteLine("\nCapacity of all courts: " + airport.TotalPassengersCapacity2() + " passengers");
            //Console.WriteLine("\nОбщая грузоподъемность всех судов: " + airport.TotalLoadingCapacity() + " кг");
            Console.WriteLine("\nGeneral loading capacity of all courts: " + airport.TotalLoadingCapacity2() + " kg");

            airport.FuelСonsumption(50,250);
        }

        private static void PrintInfoToConsole(ICollection<IFlying> flyings)
        {
            foreach (var item in flyings)
            {
                Console.WriteLine(item.GetInfo());
            }
        }

        private static void FillAirportWithAircrafts(AirPort airport) // вынести в отдельный класс
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
            airport.Add(new Passenger()   //("Boing-777", new DateTime(2010, 01, 01), 230000,4,315000,9700,250,145,48000)
            {
                Name = "Boing-777",
                Price = 230000,
                ProductionDate = new DateTime(2010, 01, 01),
                Crew = 4,
                Weight = 315000,
                FlyingRange = 9700,
                FuelConsumption = 250,
                PassengersCapacity = 145,
                LoadingCapacity = 48000
            }
            );
            airport.Add(new Passenger()   //("Boing-777", new DateTime(2010, 01, 01), 230000,4,315000,9700,250,145,48000)
            {
                Name = "SuperJet-100",
                Price = 100000,
                ProductionDate = new DateTime(2014, 01, 01),
                Crew = 4,
                Weight = 215000,
                FlyingRange = 5600,
                FuelConsumption = 160,
                PassengersCapacity = 145,
                LoadingCapacity = 48000
            }
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
