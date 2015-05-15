using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public abstract class Plane : Airline, IPlane
    {
        private ushort crew;
        public ushort Crew
        {
            get
            {
                return crew;
            }
            set
            {
                Validate(value); 
                value = crew;
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
                Validate(value);
                value = weight;
            }
        }
        private int flyinggange;
        public int FlyingRange
        {
            get
            {
                return flyinggange;
            }
            set
            {
                Validate(value);
                value = flyinggange;
            }
        }

        private double fuelconsumption;
        public double FuelConsumption
        {
            get
            {
                return fuelconsumption;
            }
            set
            {
                ValidateFuel(value);
                value = fuelconsumption;
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
    }
}
