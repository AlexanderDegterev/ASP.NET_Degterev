using System;
using System.Collections.Generic;

namespace StatisticsOfSales.DAL.Models
{
    public partial class Sale
    {
        public int SaleID { get; set; }
        public int ManagerID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public Nullable<decimal> SUM { get; set; }
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
    }
}
