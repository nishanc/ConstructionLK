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
        // GET: UserSelector
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            if(User.IsInRole(RoleName.Customer))
            {
            
                return RedirectToAction("MyProfile", "Customers", new { id = User.Identity.GetUserId() });
            }

            if (User.IsInRole(RoleName.CanManageAll))
            {

                return RedirectToAction("MyProfile", "ServiceProvidersIndividual", new { id = User.Identity.GetUserId() });
            }
            if (User.IsInRole(RoleName.ServiceProvider))
            {

                return RedirectToAction("MyProfile", "ServiceProvidersCooperate", new { id = User.Identity.GetUserId() });
            }
            return HttpNotFound();
        }

    }
}