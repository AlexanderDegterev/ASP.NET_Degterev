using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Tarif : ITariff
    {
        private string _nameTariff;
        public string NameTariff
        {
            get
                {
                    return _nameTariff;
                }
            set
                {
                    _nameTariff = value;
                }
        }

        private double _costTariff;
        public double CostTariff
        {
            get
                {
                    return _costTariff;
                }
            set
                {
                    _costTariff = value;
                }
        }
    }

}
