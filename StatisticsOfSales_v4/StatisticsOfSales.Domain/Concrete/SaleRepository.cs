using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Abstract;

namespace StatisticsOfSales.Domain.Concrete
{
    public class SaleRepository : ISalesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Sale> Sales
        {
            get { return context.Sales; }
        }
        public IEnumerable<Sale> GetSales
        {
            get
            {
                return context.Sales;
            }
        }
        
        
        /*private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/

    }
}

        
