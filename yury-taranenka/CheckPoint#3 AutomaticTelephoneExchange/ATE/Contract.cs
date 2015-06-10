using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class Contract
    {
        Guid id;
        Client client;
        public Terminal terminal;
        Tariff tariff;
        DateTime dayOfSigning;
        DateTime expireDay;

        public Contract()
        {
            id = Guid.NewGuid();
            dayOfSigning = DateTime.Now.Date;
            expireDay = dayOfSigning + new TimeSpan(365, 0, 0, 0);
        }

        public Contract(Client client, Terminal terminal, Tariff tariff) : this()
        {
            this.client = client;
            this.terminal = terminal;
            this.tariff = tariff;
        }
    }
}
