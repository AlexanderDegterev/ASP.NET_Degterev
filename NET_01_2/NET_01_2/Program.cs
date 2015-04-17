using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_2
{
    class Item
    {
        private string goods;
        public string Goods {
             
            get { return goods; }
            set { goods = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        
        private double quantity;
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item()
        {
            // TODO: Complete member initialization         
            
        }

        public double Sum() // метод возвращаюший стоимость товара
        {
            return price * quantity;
        }

        public static bool isvalidation(double price, double quantity)
        {
            if (price > 0 && quantity > 0)

                return true;
            else
                return false;
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
                     new Item() {Goods = ((char)rnd.Next('a', 'z' + 1)).ToString(), Price = rnd.Next(10,10000), Quantity = rnd.Next(1,100)}
                     //Item.isvalidation();
                   };

                foreach (Item theItem in theItems)
                {
                    sumall += theItem.Sum();
                    Console.WriteLine("Товар:" + theItem.Goods + "  Цена:" + theItem.Price + "  Кол-во:" + theItem.Quantity + " " + theItem.Sum());

                }
            } // end for
            Console.WriteLine("Сумма всех стоимостей товаров:{0:N}", sumall  );
        }


    }
}



