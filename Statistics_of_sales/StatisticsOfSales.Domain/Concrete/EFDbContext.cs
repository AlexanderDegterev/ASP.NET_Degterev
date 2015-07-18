using System;
using System.Collections.Generic;
using System.Data.Entity;
using StatisticsOfSales.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsOfSales.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
    }
}
