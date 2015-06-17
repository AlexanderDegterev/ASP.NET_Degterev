using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EF6App
{
    public class Reader
    {
        public static List<ManagerSale> ReadFile(String filename)
            {
                List<ManagerSale> res = new List<ManagerSale>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ManagerSale p = new ManagerSale();
                        p.piece (line);
                        res.Add(p);
                    }
                }
 
                return res;
            
       
    }

       /* {
            try
            {
                Encoding enc = Encoding.GetEncoding(1251);  //CP1251
                string content = System.IO.File.ReadAllText(filename, enc);
                return content;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return "error";
            }
        }*/
            
    }
}
