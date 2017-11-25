using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
using Microsoft.AspNet.Identity;

namespace ConstructionLK.Controllers
{
    public class ServiceProvidersIndividualController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();
        public ActionResult MyProfile(string id)
        {
            if (id == null)
            {
                //return RedirectToAction("MyProfile", "Customers", new { id = customer.Id });
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            ServiceProvider serviceProvider = db.ServiceProviders.SingleOrDefault(sp => sp.ApplicationUserId == id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            if ((!User.IsInRole(RoleName.Customer) || !User.IsInRole(RoleName.CanManageAll) || !User.IsInRole(RoleName.ServiceProvider)))
            {
                //no role
                RedirectToAction("Index", "UserSelector");
            }
            //var principal = (RolePrincipal)User;
            //if (!principal.GetRoles().Any())
            //{
            //    //no role
            //    RedirectToAction("Index", "UserSelector");
            //}

            return View("MyProfile", serviceProvider);
            //return View();
        }
        // GET: ServiceProvidersIndividual
        public ActionResult Index()
        {
            var serviceProviders = db.ServiceProviders.Include(s => s.MembershipType).Include(s => s.ServiceProviderType);
            return View(serviceProviders.ToList());
        }

        // GET: ServiceProvidersIndividual/Details/5
        public ActionResult Details(int? id)
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

        // GET: ServiceProvidersIndividual/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type");
            return View();
        }

        // POST: ServiceProvidersIndividual/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,MembershipTypeId,Password,BasedCity,MailingAddress,Bio,FirstName,LastName,DateOfBirth,Telephone,CompanyName,CompanyRegNo,StartedDate,Avatar,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,TypeId,ApplicationUserId")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.ServiceProviders.Add(serviceProvider);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("MyProfile", "ServiceProvidersIndividual", new { id = User.Identity.GetUserId() });
            }

            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", serviceProvider.MembershipTypeId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // GET: ServiceProvidersIndividual/Edit/5
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
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", serviceProvider.MembershipTypeId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // POST: ServiceProvidersIndividual/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,MembershipTypeId,Password,BasedCity,MailingAddress,Bio,FirstName,LastName,DateOfBirth,Telephone,CompanyName,CompanyRegNo,StartedDate,Avatar,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,TypeId")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", serviceProvider.MembershipTypeId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // GET: ServiceProvidersIndividual/Delete/5
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

        // POST: ServiceProvidersIndividual/Delete/5
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
