using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_OOP
{
    class Program
        // переделать 1) класс Venicle наследует IVenicle(abstract) 2) Truct только для truct
        //3) Вынести compareTo в отдельный класс
    {
        static void Main(string[] args)
        {
            List<Truck> truck = new List<Truck>();

            // Создадим множество автомобилей
            Truck[] autoArr = new Truck[5];
            truck.Add(new Truck("Toyota", "Corolla", 25000, 2015, 140, "Грузовик", 2));
            truck.Add(new Truck("Volvo", "FH12", 99000, 2014, 440,"Грузовик",3));
            truck.Add(new Truck("MAN", "550", 50000, 2013, 540,"Грузовик",2));
            truck.Add(new Truck("MAZ", "411562", 60000, 2014, 460,"Грузовик",3));
            truck.Add(new Truck("Mers", "Arosa", 100000, 2010, 380,"Грузовик",2));

            Console.WriteLine("Исходный каталог автомобилей: \n");
            foreach (Truck a in truck)
                Console.WriteLine(a);

            Console.WriteLine("\nТеперь автомобили отсортированны по стоимости: \n");
            truck.Sort();
            foreach (Truck a in truck)
                Console.WriteLine(a);
        }
    }
}
