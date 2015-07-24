using System;
using System.Collections.Generic;

namespace StatisticsOfSales.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
