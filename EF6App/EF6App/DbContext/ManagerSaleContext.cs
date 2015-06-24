using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF6App
{
    public class ManagerSaleContext:DbContext
    {
        public ManagerSaleContext()
            :base("DbConnection")
        {}

        public DbSet<ManagerSale> ManagerSales { get; set; }
    }
}
