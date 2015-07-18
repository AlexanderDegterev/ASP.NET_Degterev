using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Abstract;

namespace StatisticsOfSales.Domain.Concrete
{
    public class EFProductRepository : ISaleRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Sale> Sales
        {
            get { return context.Sales; }
        } 
    }
}
