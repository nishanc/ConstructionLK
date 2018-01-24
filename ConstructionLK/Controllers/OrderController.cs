using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
namespace ConstructionLK.Controllers
{
    public class OrderController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: Order
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
        public ActionResult order(int id, string Qnt)
        {
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
            return View("Cart");

        }

        // Cancel an order
        public ActionResult cancelOrder(int id)
        {
            int index = isExisting(id);
            List<Product> cart = (List<Product>)Session["cart"];
            cart.RemoveAt(index);
            return View("cart");
        }
    }
}