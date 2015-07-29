using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsOfSales.Domain.Entities
{
    public partial class Client
    {
        //public Client()
        //{
        //    this.Sales = new HashSet<Sale>();
        //}
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    } 
}
