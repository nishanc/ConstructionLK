using ConstructionLK.Models;
using ConstructionLK.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionLK.Controllers
{
    public class ItemImagesController : Controller
    {
        // GET: ItemImages
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Gallery(int? id)
        {
            List<ItemImage> all = new List<ItemImage>();
            using(ConstructionLKContext db = new ConstructionLKContext())
            {
                ViewBag.ItemId = id;
                all = db.ItemImages.Where(i=>i.ItemId==id).ToList();
            }
            return View(all);
        }
        public ActionResult Upload(int? id)
        {
            using (ConstructionLKContext db = new ConstructionLKContext())
            {
                var item = db.Items.SingleOrDefault(i=>i.Id==id);
            }
                ViewBag.ItemId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Upload(int id,HttpPostedFileBase file)
        {
            ItemImage itemImage = new ItemImage();
            //var ItemId = h.ItemId;
            itemImage.ItemId = id;
            itemImage.Image = file.FileName;
            byte[] data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0,file.ContentLength);
            itemImage.ImageData = data;

            //if (file.ContentLength>(2*1024*1024))
            //{
            //    ModelState.AddModelError("CustomError", "File size must be less than 2MB");
            //    return View();
            //}
            //if (!(file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
            //{
            //    ModelState.AddModelError("CustomError", "File types allowed: jpeg, png");
            //    return View();
            //}

            var model = new ItemImageViewModel
            {
                Image = file.FileName,
                ImageData = data,
                File = file,
            };
            using (ConstructionLKContext db = new ConstructionLKContext())
            {
                if (ModelState.IsValid)
                {
                    db.ItemImages.Add(itemImage);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        throw e;
                    }
                   
                }
            }
            return RedirectToAction("Gallery", new { id = id });
        }
    }
}