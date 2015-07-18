using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticsOfSales.Domain.Abstract;
using StatisticsOfSales.Domain.Entities;

namespace StatisticsOfSales.WebUI.Controllers
{
    public class SaleController : Controller
    {
         private ISaleRepository repository; 
         public SaleController(ISaleRepository saleRepository) 
    {
        this.repository = saleRepository; 
    }

         public ViewResult List()
         {
             return View(repository.Sales);
         } 

    }
}
