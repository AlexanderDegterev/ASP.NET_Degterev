using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;

namespace EF6App
{
    public class Reader
    {
        public delegate void ReaderEventHandler(string msg);
        
        public void ReadFileAndAddToDb(String filename, ReaderEventHandler handler)
        {
            try
            {
                char[] delimiters = new char[] { ',', ';' };
                using (StreamReader rd = new StreamReader(new FileStream(filename, FileMode.Open)))
                {
                    while (rd.Peek() >= 0)
                    {
                        string line = rd.ReadLine();
                        string[] vals = line.Split(delimiters);
                        Console.WriteLine(line);
                        foreach (var c in vals)
                        {
                            Console.WriteLine(c);
                        }

                        using (ManagerSaleContext db = new ManagerSaleContext())
                        {
                            Console.WriteLine(vals[0]);
                            ManagerSale client1 = new ManagerSale { ManagerSurname = vals[0], ManagerDate = DateTime.Parse(vals[1]), ClientDate = DateTime.Parse(vals[2]), Client = vals[3], Product = vals[4], Sum = Convert.ToInt32(vals[5]) };

                            db.ManagerSales.Add(client1);
                            db.SaveChanges();
                            handler("Objects save");

                            DbSet<ManagerSale> managerSales = db.ManagerSales;
                            handler("List object:");
                            foreach (ManagerSale u in managerSales)
                            {
                                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", u.Id, u.ManagerSurname, u.ManagerDate, u.ClientDate, u.Client, u.Product, u.Sum);
                            }
                        } 
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}