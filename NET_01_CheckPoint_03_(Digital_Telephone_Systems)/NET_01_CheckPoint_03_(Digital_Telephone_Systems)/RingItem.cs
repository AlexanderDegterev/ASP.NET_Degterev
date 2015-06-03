using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems_
{
    public abstract class RingItem : IRingItem
    {
        private DateTime dateIsRinging;
        public DateTime DateIsRinging
        {
            get
            {
                return dateIsRinging;
            }
            set
            {
                dateIsRinging = value;
            }
        }

        private string telephoneSubscriberSurname;
        public string TelephoneSubscriberSurname
        {
            get
            {
                return telephoneSubscriberSurname;
            }
            set
            {
                telephoneSubscriberSurname = value;
            }
        }
        private int tariff;
        public int Tariff
        {
            get
            {
                return tariff;
            }
            set
            {
                tariff = value;
            }
        }

        private DateTime durationIsRinging;
        public DateTime DurationIsRinging
        {
            get
            {
                return durationIsRinging;
            }
            set
            {
                durationIsRinging = value;
            }
        }

            private double costIsRinging;
            public double CostIsRinging
        {
            get
            {
                return costIsRinging;
            }
            set
            {
                costIsRinging = value;
            }
        }
    }
}
