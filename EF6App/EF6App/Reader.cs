using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Data.SqlClient;

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
                        //Console.WriteLine(line);
                        //foreach (var c in vals)
                        //{ 
                        //    Console.WriteLine(c);
                        //}

                        using (ManagerSaleContext db = new ManagerSaleContext())
                        {
                            Console.WriteLine(vals[0]);
                            ManagerSale client1 = new ManagerSale { ManagerSurname = vals[0], ManagerDate = DateTime.Parse(vals[1]), ClientDate = DateTime.Parse(vals[2]), Client = vals[3], Product = vals[4], Sum = Convert.ToInt32(vals[5]) };

                            if (DbConnectionStatus())
                            {
                                //Console.WriteLine("True");

                                db.ManagerSales.Add(client1);
                                db.SaveChanges();
                                //handler("Objects save");

                                DbSet<ManagerSale> managerSales = db.ManagerSales;
                                //handler("List object:");
                                //foreach (ManagerSale u in managerSales)
                                //{
                                //    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", u.Id, u.ManagerSurname,
                                //        u.ManagerDate, u.ClientDate, u.Client, u.Product, u.Sum);
                                //}
                            }
                            else
                            {
                                handler("connection error");
                            }
                        } 
                    }
                }
                File.Delete(filename);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        private static bool DbConnectionStatus()
        {
            try
            {
                using (SqlConnection sqlConn =
                        new SqlConnection("data source=HOME-nout;Initial Catalog=manager.mdf;Integrated Security=True;"))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false; 
            }
        }
    }
}