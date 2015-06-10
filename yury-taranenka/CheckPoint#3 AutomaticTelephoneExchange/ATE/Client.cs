using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class Client
    {
        Guid id;
        string name;

        public Client(string name) 
        {
            id = Guid.NewGuid();
            this.name = name;
        }

        List<Contract> contracts = new List<Contract>();

        public List<Contract> Contracts
        {
            get { return contracts; }
            set { contracts = value; }
        }

    }
}
