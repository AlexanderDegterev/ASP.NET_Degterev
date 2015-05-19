using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    public abstract class Flying : IFlying
    {

        private Flying(String name, DateTime productiondate, int price, ushort crew, int weight, int flyingRange, Double fuelConsumption, int passengersCapacity, int loadingCapacity)
        {
            this.name = name;
            this.productiondate = productiondate;
            this.price = price;
            this.crew = crew;
            this.weight = weight;
            this.flyingRange = flyingRange;
            this.fuelConsumption = fuelConsumption;
            this.passengersCapacity = passengersCapacity;
            this.loadingCapacity = loadingCapacity;
        }

        public Flying()
        {
            // TODO: Complete member initialization
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
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
                Validate(value);
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
                throw new Exception("Не верное значение");  // stops application
            }
        }
        private void Validate(double valid)
        {
            if (valid <= 0)
            {
                throw new Exception("Не верное значение");
            }
        }

        public string GetInfo()
        {
            return String.Format("Марка: {0}\nЦена: {1}\tДальность: {2}\tРасход:{3}\tДата: {4:d}\nВместимость:{5}\tГрузоподъемность:{6}\n ",
                this.Name, this.Price, this.FlyingRange, this.FuelConsumption, this.ProductionDate, this.PassengersCapacity, this.LoadingCapacity);
        }        
    }
}
