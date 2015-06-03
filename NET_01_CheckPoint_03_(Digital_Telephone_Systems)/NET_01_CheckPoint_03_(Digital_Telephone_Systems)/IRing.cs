using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems_
{
    public interface IRing
    {
        int CostIsRinging { get; set; }
        int/*string*/ Tariff { get; set; }
        string TelephoneSubscriber { get; set; }
        DateTime DurationIsRinging { get; set; }
    }
}
