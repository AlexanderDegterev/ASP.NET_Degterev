using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public abstract class Airline : IAirline
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
        private void Validate(int valid)
        {
            if (valid <= 0)
            {
                throw new Exception("Не верное значение");
            }
        }
    }
}
