using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public abstract class Flying : IFlying
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // if (name != null)
                name = value;
            }
        }

        private DateTime productiondate;
        public DateTime ProductionDate
        {
            get
            {
                return productiondate;
            }
            set
            {
                productiondate = value;
            }
        }

        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                Validate(value);
                price = value;
            }
        }
        private ushort crew;
        public ushort Crew
        {
            get
            {
                return crew;
            }
            set
            {
                crew = value;
            }
        }

        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        private int flyingRange;
        public int FlyingRange
        {
            get
            {
                return flyingRange;
            }
            set
            {
                flyingRange = value;
            }
        }

        private double fuelConsumption;
        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                ValidateFuel(value);
                fuelConsumption = value;
            }
        }
        private int passengersCapacity;
        public int PassengersCapacity
        {
            get
            {
                return passengersCapacity;
            }
            set
            {
                passengersCapacity = value;
            }
        }
        private int loadingCapacity;
        public int LoadingCapacity
        {
            get
            {
                return loadingCapacity;
            }
            set
            {
                loadingCapacity = value;
            }
        }

        


        private void Validate(int valid)
        {
            if (valid <= 0)
            {
                throw new Exception("Не верное значение");
            }
        }
        private void ValidateFuel(double valid)
        {
            if (valid <= 0)
            {
                throw new Exception("Не верное значение");
            }
        }

        public string getInfo()
        {
            return String.Format("Марка: {0}\tЦена: {1}\tДальность: {2}\tРасход:{3}\tДата: {4:d}\t Вместимость:{5}\t  Грузоподъемность:{6}\t ",
                this.Name, this.Price, this.FlyingRange, this.FuelConsumption, this.ProductionDate, this.PassengersCapacity, this.LoadingCapacity);
        }

        
        


        /*List<Item> items = new List<Item>();
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
                }*/
    }
}
