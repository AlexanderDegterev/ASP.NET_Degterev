using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxiStation taxipool = new TaxiStation();

            FillingTransportTaxiPool(taxipool);

            Console.WriteLine("\n Вывод данных: \n");
            taxipool.PrintInfoToConsole();

            taxipool.SortByFuelUsage();
            Console.WriteLine("\n Сортировка по потреблению топлива");
            taxipool.PrintInfoToConsole();

            Console.WriteLine("\nСтоимость всех авто в автопарке: " + taxipool.TotalCost());

            taxipool.RangeSpeed(160, 250);

           /* airport.SortByFlyingRange();
            Console.WriteLine("\n Сортировка по дальности полетов");
            airport.PrintInfoToConsole();

            Console.WriteLine("\nВместимость всех судов: " + airport.TotalPassengersCapacity() + " пассажиров");
            Console.WriteLine("\nОбщая грузоподъемность всех судов: " + airport.TotalLoadingCapacity() + " кг");

            airport.FuelСonsumption(50, 250);*/
            
        }

        private static void FillingTransportTaxiPool(TaxiStation taxipool)
        {
            taxipool.Add(new Cargo()
            {
                Brand = "Volvo",
                Model = "FH12",
                Price = 99000,
                YearProduction = new DateTime(2010, 10, 3),
                FuelUsage = 28,
                Speed = 160,
                Volume = 80
            }
                );
            taxipool.Add(new Bus()
            {
                Brand = "Volvo",
                Model = "B5L",
                Price = 145000,
                YearProduction = new DateTime(2015, 05, 17),
                FuelUsage = 23,
                Speed = 150,
                CapacityPassanger = 50,
                TypeBus = TypeBus.Business
            }
                );
            taxipool.Add(new Passenger()
            {
                Brand = "Volvo",
                Model = "S80",
                Price = 45000,
                YearProduction = new DateTime(2014, 10, 10),
                FuelUsage = 10,
                Speed = 250,
                CapacityPassanger = 5,
                TypePass = TypePass.Business
            }
                );
            taxipool.Add(new Passenger()
            {
                Brand = "Audi",
                Model = "A6",
                Price = 28000,
                YearProduction = new DateTime(2013, 05, 10),
                FuelUsage = 9,
                Speed = 250,
                CapacityPassanger = 5,
                TypePass = TypePass.Standart
            }
                );
        }
    }
}
