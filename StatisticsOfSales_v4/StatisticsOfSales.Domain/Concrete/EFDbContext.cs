using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;

namespace StatisticsOfSales.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        //public EFDbContext() : base("name=EFDbContext");
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}
