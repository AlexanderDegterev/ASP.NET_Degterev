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

        public void piece(string line)
        {
            string[] parts = line.Split('%');  //Разделитель в CSV файле.
            ManagerSurname = parts[0];
            ManagerDate = new DateTime(2015, 12, 31);//DateTime.Parse(parts[1]);
            ClientDate = new DateTime(2015, 06, 16);//DateTime.Parse(parts[2]);
            Client = parts[3];
            Product= parts[4];
            Sum = int.Parse(parts[5]);
        }
    }
}
