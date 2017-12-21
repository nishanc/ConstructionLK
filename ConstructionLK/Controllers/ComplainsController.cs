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
    public class ComplainsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: Complains
        public ActionResult Index()
        {
            var complains = db.Complains.Include(c => c.AspNetUser).Include(c => c.ComplainAction);
            return View(complains.ToList());
        }

        // GET: Complains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // GET: Complains/Create
        public ActionResult Create()
        {
            ViewBag.ComplainedBy = new SelectList(db.AspNetUsers, "Id", "Email");

            ViewBag.ComplainedAbout = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ActionId = new SelectList(db.ComplainActions, "Id", "Action");
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ComplainedDate,ActionId,ComplainedBy,ComplainedAbout,ComplainBody")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Complains.Add(complain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplainedAbout = new SelectList(db.AspNetUsers, "Id", "Email", complain.ComplainedAbout);
            ViewBag.ActionId = new SelectList(db.ComplainActions, "Id", "Action", complain.ActionId);
            return View(complain);
        }

        // GET: Complains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplainedAbout = new SelectList(db.AspNetUsers, "Id", "Email", complain.ComplainedAbout);
            ViewBag.ActionId = new SelectList(db.ComplainActions, "Id", "Action", complain.ActionId);
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ComplainedDate,ActionId,ComplainedBy,ComplainedAbout,ComplainBody")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplainedAbout = new SelectList(db.AspNetUsers, "Id", "Email", complain.ComplainedAbout);
            ViewBag.ActionId = new SelectList(db.ComplainActions, "Id", "Action", complain.ActionId);
            return View(complain);
        }

        // GET: Complains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.Complains.Find(id);
            db.Complains.Remove(complain);
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
