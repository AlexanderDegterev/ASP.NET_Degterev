using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_OOP
{
    class Truck : IComparable<Truck>, IVehicle, ITruck
    {
        public string Brand { get; set;}
        public string Model { get; set; }
        public int Price { get; set; }
        public int CreationYear { get; set; }
        public int Power { get; set; }  // мощьность
        public string Type { get; set; }  // тип
        public int Axles { get; set; }  // кол-во осей
        
        public Truck() { }
        public Truck(string Brand, string Model, int Price, int CreationYear, int Power, string Type,int Axles) 
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
            this.CreationYear = CreationYear;
            this.Power = Power;
            this.Type = Type;
            this.Axles = Axles;

        }

    // Реализуем интерфейс IComparable<T>
        public int CompareTo(Truck obj)
        {
            if (this.Price > obj.Price)
                return 1;
            if (this.Price < obj.Price)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return String.Format("Марка: {0}\tМодель: {1}\tЦена: {2}\tМощьность:{3}\t  ",
                this.Brand,this.Model,this.Price,this.Power);
        }
}
}
