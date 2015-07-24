using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatisticsOfSales.DAL.Models;

namespace StatisticsOfSales.WebUI.Controllers
{
    public class SalesController : Controller
    {
        private StatisticsOfSales_v2Context db = new StatisticsOfSales_v2Context();

        // GET: /Sales/
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Client).Include(s => s.Manager).Include(s => s.Product);
            return View(db.sales.ToList());
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
        public ActionResult Create([Bind(Include="SaleID,ManagerID,Date,ClientID,ProductID,SUM")] Sale sale)
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
        public ActionResult Edit([Bind(Include="SaleID,ManagerID,Date,ClientID,ProductID,SUM")] Sale sale)
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
        public ActionResult Delete(int? id)
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

        // POST: /Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
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
