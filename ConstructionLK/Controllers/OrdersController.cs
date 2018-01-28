using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;

namespace ConstructionLK.Controllers
{
    public class OrdersController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: Orders
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.AspNetUser).Include(o => o.OrderStatus);
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create( float totprice , string user)
        {
            var User = db.Customers.SingleOrDefault(c => c.ApplicationUserId == user);
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            //ViewBag.Status = new SelectList(db.OrderStatus, "Id", "Action");
            ViewBag.totprice = totprice;
           ViewBag.user = User.FirstName;
           // ViewBag.id = User.Id;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Price,Status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(orders);
                db.SaveChanges();
                ViewBag.price = orders.Price;
                ViewBag.orderNumber = orders.Id;
                return RedirectToAction("payment", orders);
               // return View("payment", "Orders");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", orders.UserId);
            ViewBag.Status = new SelectList(db.OrderStatus, "Id", "Action", orders.Status);
            return View(orders);
        }
        public ActionResult payment(Orders orders)
        {
            ViewBag.price = orders.Price;
            ViewBag.orderNumber = orders.Id;
            return View("payment");
        }
        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", orders.UserId);
            ViewBag.Status = new SelectList(db.OrderStatus, "Id", "Action", orders.Status);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Price,Status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", orders.UserId);
            ViewBag.Status = new SelectList(db.OrderStatus, "Id", "Action", orders.Status);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Order.Find(id);
            db.Order.Remove(orders);
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
