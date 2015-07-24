using System;
using System.Collections.Generic;

namespace StatisticsOfSales.DAL.Models
{
    public partial class Client
    {
        public Client()
        {
            this.Sales = new List<Sale>();
        }

        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
