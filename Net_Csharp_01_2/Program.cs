using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Csharp_01_2
{
    class Item
    {
        public string goods = "pants";
        public double price = 10.54;
        public double quantity = 100;
        
        public  double sum(double price, double quantity) // метод возвращаюший стоимость товара
        {
            double a = price;
            double b = quantity;

            return a*b;
        }

        /*public void writeResult()
        {
            Console.WriteLine("Вычислить общую стоимость товара:? y/n:");
            string s = Console.ReadLine();
            s = s.ToLower();
            if (s == "y")
            {
                Console.WriteLine("Стоимость товара:" +sum(price,quantity));
                return;
            }
        }*/
                
    }

    class Program
    {

        /*public static double sum(double price, double quantity)
        {
            double a = price;
            double b = quantity;

            return a * b;
        }*/

        
         static void Main()
        {
            Item item1 = new Item();
            //item1.goods = "pants";
            //item1.price = 10.54;
            //item1.quantity = 100;
            item1.sum(item1.price, item1.quantity);
            
            Console.WriteLine("Наименование:   Цена за еденицу:   Количество:   Стоимость товара:");
            Console.Write(item1.goods + "           " + item1.price + "               " + item1.quantity + "            " + item1.sum(item1.price, item1.quantity) + "\n");
            //Console.Write("Наименование:"+item1.goods+"   "); // выводит на экран 
            //Console.Write("Цена за еденицу:" + item1.price + " ");
            //Console.Write("Количество:" + item1.quantity + " \n");
            //Console.WriteLine("Стоимость товара:" + item1.sum(item1.price, item1.quantity));
                        
         }

        
    }
}
