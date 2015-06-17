using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EF6App
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            //string textoriginal = reader.ReadOriginal("text2.txt");
            //Console.WriteLine("Print text (Original):\n" + textoriginal);

            string[] str = { "," };
            //using (ManagerSaleContext db = new ManagerSaleContext())
            using (StreamReader rd = new StreamReader(new FileStream("1.csv", FileMode.Open)))
                {
                    string RL;
                    RL = rd.ReadLine();//.Split(str), StringSplitOptions.RemoveEmptyEntries); 
                    Console.WriteLine(RL);   
                str = rd.ReadToEnd().Split(str, StringSplitOptions.RemoveEmptyEntries);
                }
            for (int i = 0; i < str.Length; i++)
            {


                using (ManagerSaleContext db = new ManagerSaleContext())
                {
                    //Console.WriteLine("ReadLine ", str[i]);
                    //ManagerSale client1 = new ManagerSale { ManagerSurname = str[i], ManagerDate = DateTime.Parse(str[i + 1]), ClientDate = new DateTime(2015, 12, 31), Client = "Ivanov", Product = "Car", Sum = 500 };
                    //ManagerSale client2 = new ManagerSale { ManagerSurname = "Jerry", ManagerDate = new DateTime(2015, 06, 16), ClientDate = new DateTime(2015, 06, 16), Client = "Petrov", Product = "Aircraft", Sum = 50000 };

                    //db.ManagerSales.Add(client1);
                    //db.ManagerSales.Add(client2);
                    //db.SaveChanges();
                    Console.WriteLine("Objects save");

                    var managerSales = db.ManagerSales;
                    Console.WriteLine("List object:");
                    foreach (ManagerSale u in managerSales)
                    {
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", u.Id, u.ManagerSurname, u.ManagerDate, u.ClientDate, u.Client, u.Product, u.Product);
                    }

                }
            }
        }
    }
}
