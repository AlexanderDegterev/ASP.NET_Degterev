using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using StatisticsOfSales_v2.DAL;

namespace StatisticsOfSales_v2.Controllers
{
    public class HomeController : Controller
    {
        private StatisticsOfSales_v2Entities db = new StatisticsOfSales_v2Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Diagrams()
        {
            //var Sale = from s in db.Sales
                //select s;
            
            //ViewBag.Result = result;
            return View();
        }

        public class ResultLine
        {

            public ResultLine() { }

            public string ManagerName { get; set; }
            public string SumTotal { get; set; }
        }

        public JsonResult GetManagerAgePie()
        {
            /*var salesManager = new List<object>();

            salesManager.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
            salesManager.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
            salesManager.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });*/
            /*List<ResultLine> result = db.Sales
                .GroupBy(l => l.Manager.ManagerName)
                .Select(cl => new ResultLine
            {
                ManagerName = cl.First().Manager.ManagerName.ToString(),
                SumTotal = cl.Sum(c => c.TotalSum).ToString(),
            }).ToList();*/

            var groupedData = from b in db.Sales.AsEnumerable()
                              group b by b.ManagerID into g
                              select new
                              {
                                  manager = g.Key,
                                  amount = g.Sum(b => b.TotalSum).ToString()
                              };

            var salesManager2 = (from s in db.Sales
                group s by s.Manager.ManagerName into g
                select new { amount = g.Sum(x => x.TotalSum), manager = g.Key }).ToList(); 
            //(from x in db.Sales group x by x.ManagerID).ToList();
            //ViewBag.SM2 = salesManager2;

            return Json(new { Salemanager = salesManager2 }, JsonRequestBehavior.AllowGet);
        }
    }
}
