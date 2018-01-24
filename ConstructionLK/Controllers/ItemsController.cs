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
    public class ItemsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();
        [AllowAnonymous]
        // GET: Items
        public ActionResult Index(int id)
        {
            //var items = db.Items.Include(i => i.ItemStatus).Include(i => i.ItemSubCategory).Include(i => i.ItemType).Include(i => i.ServiceProvider);

            var items = db.Items.Include(i => i.ItemSubCategory).Include(i => i.ItemType).Include(i => i.ServiceProvider).Include(i=>i.ItemStatus).Where(i=>i.TypeId==id);
            //var items = db.Items.Include(i => i.ItemSubCategory).Include(i => i.ItemType).Include(i => i.ServiceProvider);

            if (User.IsInRole(RoleName.CanManageAll))
                return View(items.ToList());

                return View("ReadOnlyIndex", items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.ItemStatus, "Id", "Name");
            ViewBag.SubCategoryId = new SelectList(db.ItemSubCategories, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ItemTypes, "Id", "Type");
            ViewBag.UserId = new SelectList(db.ServiceProviders, "Id", "Username");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemName,ItemCode,Description,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,SubCategoryId,TypeId,UserId,Price,Tax")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.ItemStatus, "Id", "Name",item.StatusId);
            ViewBag.SubCategoryId = new SelectList(db.ItemSubCategories, "Id", "Name", item.SubCategoryId);
            ViewBag.TypeId = new SelectList(db.ItemTypes, "Id", "Type", item.TypeId);
            ViewBag.UserId = new SelectList(db.ServiceProviders, "Id", "Username", item.UserId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.ItemStatus, "Id", "Name", item.StatusId);
            ViewBag.SubCategoryId = new SelectList(db.ItemSubCategories, "Id", "Name", item.SubCategoryId);
            ViewBag.TypeId = new SelectList(db.ItemTypes, "Id", "Type", item.TypeId);
            ViewBag.UserId = new SelectList(db.ServiceProviders, "Id", "Username", item.UserId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemName,ItemCode,Description,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,SubCategoryId,TypeId,UserId,Price,Tax")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.ItemStatus, "Id", "Name", item.StatusId);
            ViewBag.SubCategoryId = new SelectList(db.ItemSubCategories, "Id", "Name", item.SubCategoryId);
            ViewBag.TypeId = new SelectList(db.ItemTypes, "Id", "Type", item.TypeId);
            ViewBag.UserId = new SelectList(db.ServiceProviders, "Id", "Username", item.UserId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // buy method 
        public ActionResult Buy(int id)
        {
            Item item = db.Items.Find(id);
            return View("BuyProduct", item);// sent to add the quntity 
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
