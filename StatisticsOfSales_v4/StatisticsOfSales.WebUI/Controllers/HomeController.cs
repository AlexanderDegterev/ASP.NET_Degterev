﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Abstract;
using StatisticsOfSales.Domain.Concrete;
using Ninject;

namespace StatisticsOfSales.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ISalesRepository saleRepo;
        public HomeController(ISalesRepository salesRepository)
        {
            this.saleRepo = salesRepository;
        }
        public ViewResult List()
        {
            //var sales123 = from s in saleRepository.GetSales()
            //    select s;
            return View(saleRepo.Sales);
        }
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
            return View();
        }

        //private EFDbContext db = new EFDbContext();
        

        public JsonResult GetManagerAgePie()
        {

            /*var db = SaleRepository;
            var groupedData = from b in db.Sales.AsEnumerable()
                              group b by b.ManagerID into g
                              select new
                              {
                                  manager = g.Key,
                                  amount = g.Sum(b => b.TotalSum).ToString()
                              };*/

            //var salesManager2 = (from s in db.Sales
            //                     group s by s.Manager.ManagerName into g
            //                     select new { amount = g.Sum(x => x.TotalSum), manager = g.Key }).ToList();
            //ISalesRepository calc = ninjectKernel.Get<ISalesRepository>();
            var salesDb = from s in saleRepo.Sales select s;
            var salesManager2 = (from s in saleRepo.Sales
                group s by s.ManagerID
                into g
                select new {amount = g.Sum(x => (x.TotalSum)), manager = g.Key}).ToList();

            return Json(new { Salemanager = salesManager2 }, JsonRequestBehavior.AllowGet);
        }

    }
}