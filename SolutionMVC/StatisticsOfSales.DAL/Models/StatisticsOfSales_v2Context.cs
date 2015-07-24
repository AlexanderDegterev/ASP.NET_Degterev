using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StatisticsOfSales.DAL.Models.Mapping;

namespace StatisticsOfSales.DAL.Models
{
    public partial class StatisticsOfSales_v2Context : DbContext
    {
        static StatisticsOfSales_v2Context()
        {
            Database.SetInitializer<StatisticsOfSales_v2Context>(null);
        }

        public StatisticsOfSales_v2Context()
            : base("Name=StatisticsOfSales_v2Context")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SaleMap());
        }
    }
}
