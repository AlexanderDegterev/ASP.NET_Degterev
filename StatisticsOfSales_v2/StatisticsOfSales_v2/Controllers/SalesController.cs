using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using StatisticsOfSales_v2.DAL;
using PagedList;

namespace StatisticsOfSales_v2.Controllers
{
    public class SalesController : Controller
    {
        private StatisticsOfSales_v2Entities db = new StatisticsOfSales_v2Entities();

        // GET: /Sales/
        //public ActionResult Index()
        //{
        //    var sales = db.Sales.Include(s => s.Client).Include(s => s.Manager).Include(s => s.Product);
        //    return View(sales.ToList());
        //}

        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ManagerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "managerName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (page == null)
            {
                page = 1;
            }
            if (searchString != null)//todo
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var sales = from s in db.Sales
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sales = sales.Where(s => s.Manager.ManagerName.ToUpper().Contains(searchString.ToUpper()) ||
                                         s.Manager.ManagerSurname.ToUpper().Contains(searchString.ToUpper()));
            }
            switch  (sortOrder)
            {
                case "managerName_desc":
                    sales = sales.OrderByDescending(s => s.ManagerID);
                    break;
                case "Date":
                    sales = sales.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    sales = sales.OrderByDescending(s => s.Date);
                    break;
                default:
                    sales = sales.OrderBy(s => s.ManagerID);
                    break;
            }

            int pageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["CountPage"]);//3;todo consts
            int pageNumber = (page ?? 1);
            return View(sales.ToPagedList(pageNumber, pageSize));
            //return View(sales.ToList());
        }

        // GET: /Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: /Sales/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: /Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,ManagerID,Date,ClientID,ProductID,TotalSum")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", sale.ClientID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", sale.ManagerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            return View(sale);
        }

        // GET: /Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", sale.ClientID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", sale.ManagerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            return View(sale);
        }

        // POST: /Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,ManagerID,Date,ClientID,ProductID,TotalSum")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", sale.ClientID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", sale.ManagerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            return View(sale);
        }

        // GET: /Sales/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again.";
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: /Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Sale sale = db.Sales.Find(id);
                db.Sales.Remove(sale);
                db.SaveChanges();
            }
            catch (DataException)
            {

                return RedirectToAction("Delete", new { id = id, saveChangesError = true});
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
