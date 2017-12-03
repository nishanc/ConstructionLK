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
    public class ServiceProvidersCooperateController : Controller
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
        // GET: ServiceProvidersCooperate
        public ActionResult Index()
        {
            var serviceProviders = db.ServiceProviders.Include(s => s.MembershipType).Include(s => s.ServiceProviderType);
            return View(serviceProviders.ToList());
        }

        // GET: ServiceProvidersCooperate/Details/5
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

        // GET: ServiceProvidersCooperate/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type");
            return View();
        }

        // POST: ServiceProvidersCooperate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,MembershipTypeId,BasedCity,MailingAddress,Bio,FirstName,LastName,DateOfBirth,Telephone,CompanyName,CompanyRegNo,StartedDate,Avatar,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,TypeId,ApplicationUserId")] ServiceProvider serviceProvider)
        {
            Console.WriteLine(">>>>>>>>>>>>>Create");
            if (ModelState.IsValid)
            {
                Console.WriteLine(">>>>>>>>>>>>>Valid");
                db.ServiceProviders.Add(serviceProvider);
                try
                {
                    Console.WriteLine(">>>>>>>>>>>>>Save");
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return RedirectToAction("MyProfile", "ServiceProvidersCooperate", new { id = User.Identity.GetUserId() });
                //return RedirectToAction("Index");
            }

            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", serviceProvider.MembershipTypeId);
            ViewBag.TypeId = new SelectList(db.ServiceProviderTypes, "Id", "Type", serviceProvider.TypeId);
            return View(serviceProvider);
        }

        // GET: ServiceProvidersCooperate/Edit/5
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

        // POST: ServiceProvidersCooperate/Edit/5
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

        // GET: ServiceProvidersCooperate/Delete/5
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

        // POST: ServiceProvidersCooperate/Delete/5
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
