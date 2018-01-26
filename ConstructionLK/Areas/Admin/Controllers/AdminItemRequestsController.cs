using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;

namespace ConstructionLK.Areas.Admin.Controllers
{
    public class AdminItemRequestsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: Admin/AdminItemRequests
        public ActionResult Index(int? id)
        {

                var itemRequests = db.ItemRequests.Include(i => i.Customer).Include(i => i.Item).Include(i => i.ItemRequestStatus).Include(i => i.ServiceProvider).Where(i=>i.StatusId==id);
                return View(itemRequests.ToList());

        }

        // GET: Admin/AdminItemRequests/Details/5
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
            //var req = db.ItemRequests.SingleOrDefault(i => i.Id == id);
            ViewBag.latitude = itemRequest.Latitude;
            ViewBag.longitude = itemRequest.Longitude;
            try
            {
                var result = db.RequestProgreses.GroupBy(x => x.ReqId)
                          .Select(x => x.OrderByDescending(y => y.Id).FirstOrDefault());
                var p = result.FirstOrDefault(i => i.ReqId == id).value;
                if (p != 0)
                    ViewBag.P = p;
                
            }
            catch (Exception)
            {

                ViewBag.P = 0;
            }
            return View(itemRequest);

        }

        // GET: Admin/AdminItemRequests/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            ViewBag.StatusId = new SelectList(db.ItemRequestStatuses, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Type");
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username");
            return View();
        }

        // POST: Admin/AdminItemRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,CreatedDate,AcceptedDate,ExpDate,CompletedDate,StatusId,LocationId,CustomerId,ServiceProviderId,ItemId,Latitude,Longitude")] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                db.ItemRequests.Add(itemRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username", itemRequest.CustomerId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemRequest.ItemId);
            ViewBag.StatusId = new SelectList(db.ItemRequestStatuses, "Id", "Name", itemRequest.StatusId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // GET: Admin/AdminItemRequests/Edit/5
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
            ViewBag.StatusId = new SelectList(db.ItemRequestStatuses, "Id", "Name", itemRequest.StatusId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // POST: Admin/AdminItemRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,CreatedDate,AcceptedDate,ExpDate,CompletedDate,StatusId,LocationId,CustomerId,ServiceProviderId,ItemId,Latitude,Longitude")] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Username", itemRequest.CustomerId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemRequest.ItemId);
            ViewBag.StatusId = new SelectList(db.ItemRequestStatuses, "Id", "Name", itemRequest.StatusId);
            ViewBag.ServiceProviderId = new SelectList(db.ServiceProviders, "Id", "Username", itemRequest.ServiceProviderId);
            return View(itemRequest);
        }

        // GET: Admin/AdminItemRequests/Delete/5
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

        // POST: Admin/AdminItemRequests/Delete/5
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
    }
}
