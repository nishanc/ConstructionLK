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
    public class ItemRequestsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: ItemRequests
        public ActionResult Index()
        {
            var itemRequests = db.ItemRequests.Include(i => i.CustomerId).Include(i => i.ItemId).Include(i => i.LocationId).Include(i => i.ServiceProviderId);
            return View(itemRequests.ToList());
        }

        // GET: ItemRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRequest itemRequest = db.ItemRequests.Find(id);
            if (itemRequest == null)
            {
                return HttpNotFound();
            }
            return View(itemRequest);
        }

        // GET: ItemRequests/Create
        public ActionResult Create(string id)
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Type");
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username");
            return View();
        }

        // POST: ItemRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,CreatedDate,AcceptedDate,ExpDate,CompletedDate,Status,LocationId,CustomerId,ServiceProviderId,ItemId")] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                db.ItemRequests.Add(itemRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username", itemRequest.CustomerId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemRequest.ItemId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Type", itemRequest.LocationId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // GET: ItemRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRequest itemRequest = db.ItemRequests.Find(id);
            if (itemRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username", itemRequest.CustomerId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemRequest.ItemId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Type", itemRequest.LocationId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // POST: ItemRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,CreatedDate,AcceptedDate,ExpDate,CompletedDate,Status,LocationId,CustomerId,ServiceProviderId,ItemId")] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username", itemRequest.CustomerId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemRequest.ItemId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Type", itemRequest.LocationId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // GET: ItemRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRequest itemRequest = db.ItemRequests.Find(id);
            if (itemRequest == null)
            {
                return HttpNotFound();
            }
            return View(itemRequest);
        }

        // POST: ItemRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemRequest itemRequest = db.ItemRequests.Find(id);
            db.ItemRequests.Remove(itemRequest);
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

        public JsonResult GetLocation()
        {
            var data = db.Locations.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
