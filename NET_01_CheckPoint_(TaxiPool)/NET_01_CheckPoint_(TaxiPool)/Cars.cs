using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    public abstract class Cars :ICars
    {
        public Cars() { }
        public Cars(string brand, string model, int price, DateTime yearProduction, int fuelUsage, int speed)  //Ok
        {
            this.brand = brand;
            this.model = model;
            this.price = price;
            this.yearProduction = yearProduction;
            this.fuelUsage = fuelUsage;
            this.speed = speed;
        }

        private string brand;  // the brand field
        public string Brand    // the Brand property
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        private string model;
        public string Model { get; set; }
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
        private DateTime yearProduction;
        public DateTime YearProduction { get; set; }
        private int fuelUsage;
        public int FuelUsage  // расход типлива
        {
            get
            {
                return fuelUsage;
            }
            set
            {
                Validate(value);
                fuelUsage = value;
            }
        }
       
        private int speed;
        public int Speed //{ get; set; }
        {
            get
            {
                return speed;
            }
            set
            {
                Validate(value);
                speed = value;
            }
        }

        private void Validate(int valid)
        {
            if (valid <= 0)
            {
                throw new Exception("Не верное значение");
            }
        }
        public string getInfo()
        {
            return String.Format("Марка: {0}\nМодель: {1}\tЦена: {2}\tДата:{3:d}\tРасход: {4}\tСкорость:{5}\n ",
                this.Brand, this.Model, this.Price, this.YearProduction, this.FuelUsage, this.Speed);
        }    
    }
}
