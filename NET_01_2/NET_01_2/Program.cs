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
        public string Goods
        {

            get { return goods; }
            set
            {
                ValidateGoods(value);
                goods = value;
            }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                ValidatePrice(value);
                price = value;
            }
        }

        private double quantity;
        public double Quantity
        {
            get { return quantity; }
            set
            {
                ValidateQuantity(value);
                quantity = value;
            }
        }

        public Item()
        {
            // TODO: Complete member initialization         

        }


        private void ValidateGoods(string goods)
        {
            if (goods == Char.ToString('a'))
            {
                throw new Exception("Пустой товар");
            }
        }

        private void ValidatePrice(double price)
        {
            if (price <= 0)
            {
                throw new Exception("некорректная цена повара");
            }
        }
        private void ValidateQuantity(double quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("некорректная кол-во повара");
            }
        }

        public double Sum() // метод возвращаюший стоимость товара
        {
            return price * quantity;
        }
        //public double Sum(params double [] values) // Метод возвращаюший сумму из [] кол-ва
        //{
        //    double result = 0;
        //    foreach (double value in values)
        //    result += value;
        //    return result;
        //}        

        public class Program
        {
            public static void Main()
            {
                int total = 100000; //100000 
                double sumall = 0;
                Random rnd = new Random();
                
                List<Item> items = new List<Item>();
                {
                    for (int i = 1; i <= total; i++)
                    {
                        items.Add(new Item() { Goods = ((char)rnd.Next('b', 'z' + 1)).ToString(), Price = rnd.Next(1, 10000), Quantity = rnd.Next(1, 100) });
                    }
                    foreach (Item aItem in items)
                    {
                        sumall += aItem.Sum();
                        Console.WriteLine("Товар:" + aItem.Goods + "  Цена:" + aItem.Price + "  Кол-во:" + aItem.Quantity + " " + aItem.Sum());

                    };
                    Console.WriteLine("Сумма всех стоимостей товаров:{0:N}", sumall);
                }


            }
        }
    }
}