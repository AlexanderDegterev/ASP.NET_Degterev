using System;
using System.Collections.Generic;

namespace StatisticsOfSales.DAL.Models
{
    public partial class Manager
    {
        public Manager()
        {
            this.Sales = new List<Sale>();
        }

        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
