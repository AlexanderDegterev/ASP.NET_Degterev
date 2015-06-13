using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Tarif : ITariff
    {
        private string nameTariff;
        public string NameTariff
        {
            get
                {
                    return nameTariff;
                }
            set
                {
                    nameTariff = value;
                }
        }

        private double costTariff;
        public double CostTariff
        {
            get
                {
                    return costTariff;
                }
            set
                {
                    costTariff = value;
                }
        }
    }

}
