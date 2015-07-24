using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class SaleContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
    }
}