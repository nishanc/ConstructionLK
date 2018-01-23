using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
using ConstructionLK.ViewModels;

namespace ConstructionLK.Controllers
{
    public class ServiceProvidersController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext(); 

        // GET: ServiceProviders
        public ActionResult Index()
        {
            //var serviceProviders = db.ServiceProviders.Include(s => s.ServiceProviderType);
            //var serviceProviders = db.ServiceProviders.Include(s => s.ServiceProviderType);
            var serviceProviders = db.ServiceProviders.Include(s => s.MembershipType).Include(s => s.Status);
            return View(serviceProviders.ToList());
        }

        // GET: ServiceProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            ServiceProvider serviceProvider = db.ServiceProviders.Include(c => c.MembershipType).Include(s => s.Status).SingleOrDefault(c => c.Id == id);

            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            return View(serviceProvider);
        }
        public ActionResult DetailsById(string user)
        {
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            ServiceProvider serviceProvider = db.ServiceProviders.Include(c => c.MembershipType).Include(s => s.Status).SingleOrDefault(c => c.ApplicationUserId == user);

            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            return View(serviceProvider);
        }
        // GET: ServiceProviders/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type");
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name");
            //var membershipTypes = db.MembershipTypes.ToList();
            //var viewModel = new NewServiceProviderViewModel
            //{
            //    MembershipTypes = membershipTypes
            //};
            return View();
        }

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,BasedCity,MailingAddress,Bio,FirstName,LastName,DateOfBirth,Telephone,CompanyName,CompanyRegNo,StartedDate,Avatar,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,TypeId,MembershipTypeId")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.ServiceProviders.Add(serviceProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name",serviceProvider.StatusId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name",serviceProvider.StatusId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", serviceProvider.MembershipTypeId);
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,BasedCity,MailingAddress,Bio,FirstName,LastName,DateOfBirth,Telephone,CompanyName,CompanyRegNo,StartedDate,Avatar,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,TypeId,MembershipTypeId")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name",serviceProvider.StatusId);
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name",serviceProvider.MembershipTypeId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            db.ServiceProviders.Remove(serviceProvider);
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
