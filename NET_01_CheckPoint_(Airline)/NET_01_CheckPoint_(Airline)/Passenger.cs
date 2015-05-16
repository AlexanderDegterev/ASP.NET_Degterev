using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    class Passenger : Flying, IPassenger
    {
        private string p1;
        public string P1
        {
            get
            {
                return p1;
            }
            set
            {
                p1 = value;
            }
        }
        private DateTime dateTime;
        private int p2;
        private int p3;
        private int p4;
        private int p5;
        private int p6;
        private int p7;
        private int p8;

        public Passenger(string p1, DateTime dateTime, int p2, int p3, int p4, int p5, int p6, int p7, int p8)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.dateTime = dateTime;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
            this.p7 = p7;
            this.p8 = p8;
        }      
        public Make Make { get; set; }
    }
}
