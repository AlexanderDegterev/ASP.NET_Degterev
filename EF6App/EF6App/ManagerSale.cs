using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6App
{
    public class ManagerSale
    {
        public int Id { get; set; }
        public string ManagerSurname { get; set; }
        public DateTime ManagerDate { get; set; }
        public DateTime ClientDate { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public int Sum { get; set; }

    }
}
