using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        SaleContext db = new SaleContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Sale> sales = db.Sales;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Sales = sales;
            // возвращаем представление
            return View();
        }
    }
}