using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface IRingItem
    {
        DateTime DateIsRinging { get; set; }
        string TelephoneSubscriberSurname { get; set; }
        int/*string*/ Tariff { get; set; }
        DateTime DurationIsRinging { get; set; }
        double CostIsRinging { get; set; }
    }
}
