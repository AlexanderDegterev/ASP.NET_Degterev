using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Abstract;

namespace StatisticsOfSales.Domain.Concrete
{
    public class EFSaleRepository : ISalesRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Sale> Sales
        {
            get { return context.Sales; }
        }
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
        public IQueryable<Manager> Managers
        {
            get { return context.Managers; }
        }
        public IQueryable<Client> Clients
        {
            get { return context.Clients; }
        }
    }
}
