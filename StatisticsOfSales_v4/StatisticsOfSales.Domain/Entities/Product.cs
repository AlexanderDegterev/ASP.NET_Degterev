using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsOfSales.Domain.Entities
{
    public partial class Product
    {

        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    } 
}
