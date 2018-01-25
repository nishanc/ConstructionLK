using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;
namespace ConstructionLK.Controllers
{
    public class ProductController : Controller
    {
        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }


    public class Product
    {
       private Item it = new Item();
        private  int quantity;
        //private float price;

        public Product(Item it, int quantity)
        {
            this.It = it;
            this.Quantity = quantity;
            //this.Price = price;
        }

        public Item It
        {
            get
            {
                return it;
            }

            set
            {
                it = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        //public float Price
        //{
        //    get
        //    {
        //        return price;
        //    }

        //    set
        //    {
        //        price = value;
        //    }
        //}
    }
}