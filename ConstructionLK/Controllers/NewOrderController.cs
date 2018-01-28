using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
namespace ConstructionLK.Controllers
{
    public class NewOrderController : Controller
    {


        private ConstructionLKContext db = new ConstructionLKContext();
        // GET: NewOrder
        public ActionResult Index()
        {
            return View();
        }


        // check the item is already exist
        public int isExisting(int Id)
        {
            List<Product> cart = (List<Product>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)

                if (cart[i].It.Id == Id)
                    return i;
            return -1;
        }


        [HttpGet]
        public ActionResult order(int id, float price, string Qnt)
        {
            var nprice = db.PublishedItems.SingleOrDefault(p => p.ItemId == id);
            var itemprice = nprice.Price;
            int quantity = Convert.ToInt32(Qnt);

            if (Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(new Product(db.Items.Find(id), quantity));
                Session["cart"] = cart;
            }
            else
            {
                List<Product> cart = (List<Product>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Product(db.Items.Find(id), quantity));
                else
                    Session["cart"] = cart;
            }
            ViewBag.unitPrice = itemprice;
            return View("cart");

        }

        // Cancel an order
        public ActionResult cancelOrder(int id)
        {
            int index = isExisting(id);
            List<Product> cart = (List<Product>)Session["cart"];
            cart.RemoveAt(index);
            return View("cart");


        }



        // continue to payment
        public ActionResult ContinuePayment( float totprice, string user)
        {
            var User= db.Customers.SingleOrDefault(c => c.ApplicationUserId == user);
            ViewBag.User = User;
            ViewBag.totprice = totprice;
            return View();
        }
    }
}