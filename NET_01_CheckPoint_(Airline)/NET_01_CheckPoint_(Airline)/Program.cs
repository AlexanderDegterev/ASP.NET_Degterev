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
                Name = "KA-226    ",
                Price = 150000,
                ProductionDate = new DateTime(2015, 05, 15) 
            }
                );
            airport.Add(new Passenger()
            {
                Name = "Boing-777",
                Price = 230000,
                ProductionDate = new DateTime(2010, 01, 01),
                Crew = 4,
                Weight = 315000,
                FlyingRange = 9700
            }
            );
            airport.Add(new Fleighter()
            {
                Name = "Airbus A400",
                Price = 312000,
                ProductionDate = new DateTime(2012, 02, 02)                
            }
            );

            Console.WriteLine("\n Вывод данных: \n");
            foreach (var i in airport)
            {                
                Console.WriteLine("Марка: {0}\t, Цена: {1}\t, Дата Производства: {2}", i.Name, i.Price, i.ProductionDate.ToString("MM/dd/yyyy"));
            }           

        }
    }
}
