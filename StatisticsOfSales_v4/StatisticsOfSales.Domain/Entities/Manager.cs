using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsOfSales.Domain.Entities
{
    public partial class Manager
    {
        public Manager()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
 
}
