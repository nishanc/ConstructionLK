using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
using ConstructionLK.ViewModels;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace ConstructionLK.Areas.Admin.Controllers
{
    public class AdministrativeStaffController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();
        public ActionResult AdminPanel(string id)
        {
            if (id == null)
            {
                //return RedirectToAction("MyProfile", "Customers", new { id = customer.Id });
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            AdministrativeStaff admin = db.AdministrativeStaffs.SingleOrDefault(a => a.ApplicationUserId == id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            if ((!User.IsInRole(RoleName.Customer) || !User.IsInRole(RoleName.CanManageAll) || !User.IsInRole(RoleName.ServiceProvider) || !User.IsInRole(RoleName.AdministrativeStaff)))
            {
                //no role
                RedirectToAction("RegisterAdmin", "Account");
            }

            var administrativeStaffs = db.AdministrativeStaffs.Include(a => a.AspNetUser);
            int counta = administrativeStaffs.Count();
            ViewBag.CountA = counta.ToString();
            var customers = db.Customers.Include(c => c.Id);
            int countc = customers.Count();
            ViewBag.CountC = countc.ToString();
            //var csp = db.ServiceProviders.Include(sp => sp.Id);
            //int countcsp = csp.Count();
            var countcsp = db.ServiceProviders.Count(t => t.ServiceProviderType.Id == ServiceProviderTypeName.SpCooperate);
            ViewBag.CountCSP = countcsp.ToString();
            //var csi = db.ServiceProviders.Include(sp => sp.Id);
            //int countcsi = csi.Count();
            var countisp = db.ServiceProviders.Count(t => t.ServiceProviderType.Id == ServiceProviderTypeName.SpIndividual);
            ViewBag.CountISP = countisp.ToString();


            return View("AdminPanel", admin);
            //return View();
        }



        // GET: Admin/AdministrativeStaff
        public ActionResult Index()
        {

            var administrativeStaffs = db.AdministrativeStaffs.Include(a => a.AspNetUser);
            int count = administrativeStaffs.Count();
            
            return View("_Index",administrativeStaffs.ToList());
        }

        // GET: Admin/AdministrativeStaff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            if (administrativeStaff == null)
            {
                return HttpNotFound();
            }
            return View(administrativeStaff);
        }

        // GET: Admin/AdministrativeStaff/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Admin/AdministrativeStaff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,FirstName,LastName,CreatedDate,ModifiedDate,ApplicationUserId")] AdministrativeStaff administrativeStaff)
        {
            if (ModelState.IsValid)
            {
                db.AdministrativeStaffs.Add(administrativeStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.AspNetUsers, "Id", "Email", administrativeStaff.ApplicationUserId);
            return View(administrativeStaff);
        }

        // GET: Admin/AdministrativeStaff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            if (administrativeStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.AspNetUsers, "Id", "Email", administrativeStaff.ApplicationUserId);
            return View(administrativeStaff);
        }

        // POST: Admin/AdministrativeStaff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,FirstName,LastName,Password,Email,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,ApplicationUserId")] AdministrativeStaff administrativeStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrativeStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.AspNetUsers, "Id", "Email", administrativeStaff.ApplicationUserId);
            return View(administrativeStaff);
        }

        // GET: Admin/AdministrativeStaff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            if (administrativeStaff == null)
            {
                return HttpNotFound();
            }
            return View(administrativeStaff);
        }

        // POST: Admin/AdministrativeStaff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            db.AdministrativeStaffs.Remove(administrativeStaff);
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
