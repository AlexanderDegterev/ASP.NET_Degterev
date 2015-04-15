using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_2
{
    class Item
    {
        public string goods; //= "pants";
        public double price; //= 10.54;
        public double quantity; //= 100;
        
        // TEST

        /*public Item(string a, double b, double c)
        {
            goods = a;
            price = b;
            quantity = c;
        }*/

        public Item()
        {
            // TODO: Complete member initialization
        }

        public double sum(double price, double quantity) // метод возвращаюший стоимость товара
        {
            return price * quantity;
        }


    }

    public class Program
    {
        //int Total = 5; //100000     
        //Random rnd = new Random();
        //dsdadsdasdasd

        static void Main()
        {
            int Total = 100000; //100000 
            double sumall = 0;
            Random rnd = new Random();


            for (int i = 1; i <= Total; i++)
            {
                var theItems = new List<Item>
                   {
                     new Item() {goods = ((char)rnd.Next('a', 'z' + 1)).ToString(), price = rnd.Next(100,100000), quantity = rnd.Next(1,100)}
                   };

                foreach (Item theItem in theItems)
                {
                    sumall += theItem.sum(theItem.price, theItem.quantity);
                    Console.WriteLine(theItem.goods + " " + theItem.price + " " + theItem.quantity + " " + theItem.sum(theItem.price, theItem.quantity));

                }
            } // end for
            Console.WriteLine("Сумма всех стоимостей товаров:" + sumall + " \n");
        }


    }
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

//Item item1 = new Item("pants",10.54,100);
//item1.goods = "pants";
//item1.price = 10.54;
//item1.quantity = 100;
//item1.sum(item1.price, item1.quantity);

//Console.WriteLine("Наименование:   Цена за еденицу:   Количество:   Стоимость товара:");
//Console.Write(item1.goods + "           " + item1.price + "               " + item1.quantity + "            " + item1.sum(item1.price, item1.quantity) + "\n");
//Console.Write("Наименование:"+item1.goods+"   "); // выводит на экран 
//Console.Write("Цена за еденицу:" + item1.price + " ");
//Console.Write("Количество:" + item1.quantity + " \n");
//Console.WriteLine("Стоимость товара:" + item1.sum(item1.price, item1.quantity));

