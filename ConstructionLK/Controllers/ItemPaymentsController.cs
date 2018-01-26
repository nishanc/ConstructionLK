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
    public class ItemPaymentsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: ItemPayments
        public ActionResult Index()
        {
            var itemPayments = db.ItemPayments.Include(i => i.ItemRequest);
            return View(itemPayments.ToList());
        }

        // GET: ItemPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPayment itemPayment = db.ItemPayments.Find(id);
            if (itemPayment == null)
            {
                return HttpNotFound();
            }
            return View(itemPayment);
        }

        // GET: ItemPayments/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.ItemRequests, "Id", "Message");
            return View();
        }

        // POST: ItemPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateAndTime,Amount,RequestId")] ItemPayment itemPayment)
        {
            if (ModelState.IsValid)
            {
                db.ItemPayments.Add(itemPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.ItemRequests, "Id", "Message", itemPayment.RequestId);
            return View(itemPayment);
        }

        // GET: ItemPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPayment itemPayment = db.ItemPayments.Find(id);
            if (itemPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.ItemRequests, "Id", "Message", itemPayment.RequestId);
            return View(itemPayment);
        }

        // POST: ItemPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateAndTime,Amount,RequestId")] ItemPayment itemPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.ItemRequests, "Id", "Message", itemPayment.RequestId);
            return View(itemPayment);
        }

        // GET: ItemPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPayment itemPayment = db.ItemPayments.Find(id);
            if (itemPayment == null)
            {
                return HttpNotFound();
            }
            return View(itemPayment);
        }

        // POST: ItemPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPayment itemPayment = db.ItemPayments.Find(id);
            db.ItemPayments.Remove(itemPayment);
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
