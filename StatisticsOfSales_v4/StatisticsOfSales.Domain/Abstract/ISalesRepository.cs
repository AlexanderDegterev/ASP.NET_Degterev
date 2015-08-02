using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Concrete;

namespace StatisticsOfSales.Domain.Abstract
{
    public interface ISalesRepository
    {
        IQueryable<Sale> Sales { get; }
        //IEnumerable<Sale> GetSales();
    }
}
