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
    public class ItemLocationsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: ItemLocations
        public ActionResult Index()
        {
            var itemLocations = db.ItemLocations.Include(i => i.Item);
            return View(itemLocations.ToList());
        }

        // GET: ItemLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLocations itemLocations = db.ItemLocations.Find(id);
            if (itemLocations == null)
            {
                return HttpNotFound();
            }
            return View(itemLocations);
        }

        // GET: ItemLocations/Create
        public ActionResult Create(int? iid)
        {
            ViewBag.ItemId = iid;
            return View();
        }

        // POST: ItemLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Latitude,Longitude,ItemId")] ItemLocations itemLocations)
        {
            if (ModelState.IsValid)
            {
                db.ItemLocations.Add(itemLocations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemLocations.ItemId);
            return View(itemLocations);
        }

        // GET: ItemLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLocations itemLocations = db.ItemLocations.Find(id);
            if (itemLocations == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemLocations.ItemId);
            return View(itemLocations);
        }

        // POST: ItemLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Latitude,Longitude,ItemId")] ItemLocations itemLocations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemLocations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemLocations.ItemId);
            return View(itemLocations);
        }

        // GET: ItemLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLocations itemLocations = db.ItemLocations.Find(id);
            if (itemLocations == null)
            {
                return HttpNotFound();
            }
            return View(itemLocations);
        }

        // POST: ItemLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemLocations itemLocations = db.ItemLocations.Find(id);
            db.ItemLocations.Remove(itemLocations);
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
