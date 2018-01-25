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
    public class ItemPropertiesController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: ItemProperties
        public ActionResult Index()
        {
            var itemProperties = db.ItemProperties.Include(i => i.Item);
            return View(itemProperties.ToList());
        }

        // GET: ItemProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProperty itemProperty = db.ItemProperties.Find(id);
            if (itemProperty == null)
            {
                return HttpNotFound();
            }
            return View(itemProperty);
        }

        // GET: ItemProperties/Create
        public ActionResult Create(int? iid)
        {

            ViewBag.ItemId = iid;
            return View();
        }

        // POST: ItemProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId,PropertyName,Value")] ItemProperty itemProperty)
        {
            if (ModelState.IsValid)
            {
                db.ItemProperties.Add(itemProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemProperty.ItemId);
            return View(itemProperty);
        }

        // GET: ItemProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProperty itemProperty = db.ItemProperties.Find(id);
            if (itemProperty == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemProperty.ItemId);
            return View(itemProperty);
        }

        // POST: ItemProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,PropertyName,Value")] ItemProperty itemProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemProperty.ItemId);
            return View(itemProperty);
        }

        // GET: ItemProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProperty itemProperty = db.ItemProperties.Find(id);
            if (itemProperty == null)
            {
                return HttpNotFound();
            }
            return View(itemProperty);
        }

        // POST: ItemProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemProperty itemProperty = db.ItemProperties.Find(id);
            db.ItemProperties.Remove(itemProperty);
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
