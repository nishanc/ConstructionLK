using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
using Microsoft.AspNet.Identity;

namespace ConstructionLK.Controllers
{   [AllowAnonymous]
    public class UserSelectorController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();
        // GET: UserSelector
        public ActionResult Index()
        {
            if (!(User.IsInRole(RoleName.Customer) || User.IsInRole(RoleName.ServiceProvider)))
            {
                
                return View("IndexToNew");//register
            }

            return View("Index");//create
        }

        public ActionResult UserProfile()
        {
            var userId = User.Identity.GetUserId();
            //AspNetUser email = db.AspNetUsers.SingleOrDefault(a => a.Id == userId);
            //if(email != null && !email.EmailConfirmed)
            //{
            //    return RedirectToAction("Index", "UserSelector");
            //}
            if (!(User.IsInRole(RoleName.Customer) || User.IsInRole(RoleName.ServiceProvider)))
            {
                var user = db.AspNetUsers.Find(userId);
                if (user != null && user.UserSelection == ServiceProviderTypeName.SpIndividual)
                {
                    return RedirectToAction("Create", "ServiceProvidersIndividual");
                }
                if (user != null && user.UserSelection == ServiceProviderTypeName.SpCooperate)
                {
                    return RedirectToAction("Create", "ServiceProvidersCooperate");
                }
                if (user != null && user.UserSelection == 1)
                {
                    return RedirectToAction("Create", "Customers");
                }
                if (user != null && user.UserSelection == 4)
                {
                    return RedirectToAction("Create", "AdministrativeStaff", new { area = "Admin" });
                    
                }
                return View("Index");//create
            }
            //var userId = User.Identity.GetUserId();
            ServiceProvider type = db.ServiceProviders.SingleOrDefault(user => user.ApplicationUserId == userId);
            //var type = db.ServiceProviders.Find(User.Identity.GetUserId());
            if (User.IsInRole(RoleName.Customer))
            {
            
                return RedirectToAction("MyProfile", "Customers", new { id = userId });
            }

            if (type != null && (User.IsInRole(RoleName.ServiceProvider) && type.TypeId == ServiceProviderTypeName.SpIndividual))
            {

                return RedirectToAction("MyProfile", "ServiceProvidersIndividual", new { id = userId });
            }
            if (type != null && (User.IsInRole(RoleName.ServiceProvider) && type.TypeId == ServiceProviderTypeName.SpCooperate))
            {

                return RedirectToAction("MyProfile", "ServiceProvidersCooperate", new { id = userId });
            }
            return HttpNotFound();
        }

    }
}