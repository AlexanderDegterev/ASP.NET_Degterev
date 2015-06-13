using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class CallItem : ICallItem
    {
        public DateTime DateOfCall { get; set; }
        public IClient Client { get; set; }
        public TimeSpan CallDuration { get; set; }
        public double CostOfCall { get; set; }
    
        public CallItem(IClient client,TimeSpan callDuration)
        {
            this.DateOfCall = DateTime.Now;
            this.Client = client;
            this.CallDuration = callDuration;
            int tarifValue = (int)client.ClientTariff;
            this.CostOfCall = tarifValue * CallDuration.TotalMinutes;
        }
        public override string ToString()
        {
            return Client.ClientName + " " + Client.ClientSurname + " " + Client.ClientTariff + " " + Client.ClientTerminal.PhoneNumber + " " + CallDuration.ToString()+ " " + CostOfCall;
        }

    }
}
