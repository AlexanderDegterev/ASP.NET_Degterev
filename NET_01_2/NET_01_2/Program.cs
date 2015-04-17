using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_2
{
    class Item
    {
        private string goods; //= "pants";
        private double price; //= 10.54;
        private double quantity; //= 100;

        public Item()
        {
            // TODO: Complete member initialization
        }

        public double Sum(double price, double quantity) // метод возвращаюший стоимость товара
        {
            return price * quantity;
        }


    }

    public class Program
    {        
        static void Main()
        {
            int total = 100000; //100000 
            double sumall = 0;
            Random rnd = new Random();


            for (int i = 1; i <= total; i++)
            {
                var theItems = new List<Item>
                   {
                     new Item() {goods = ((char)rnd.Next('a', 'z' + 1)).ToString(), price = rnd.Next(100,100000), quantity = rnd.Next(1,100)}
                   };

                foreach (Item theItem in theItems)
                {
                    sumall += theItem.Sum(theItem.price, theItem.quantity);
                    Console.WriteLine("Товар:"+theItem.goods + "  Цена:" + theItem.price + "  Кол-во:" + theItem.quantity + " " + theItem.Sum(theItem.price, theItem.quantity));

                }
            } // end for
            Console.WriteLine("Сумма всех стоимостей товаров:{0:N}", sumall  );
        }


    }
}



