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
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "admin")]
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
            var salesManager2 = (from s in db.Sales
                group s by s.Manager.ManagerName into g
                select new { amount = g.Sum(x => x.TotalSum), manager = g.Key }).ToList(); 

            return Json(new { Salemanager = salesManager2 }, JsonRequestBehavior.AllowGet);
        }
    }
}
