using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionLK.Models;

namespace ConstructionLK.Controllers
{
    public class BlogPostCommentsController : Controller
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: BlogPostComments
        public ActionResult Index()
        {
            var blogPostComments = db.BlogPostComments.Include(b => b.BlogPost).Include(b => b.Customer);
            return View(blogPostComments.ToList());
        }

        // GET: BlogPostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
            if (blogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(blogPostComment);
        }

        // GET: BlogPostComments/Create
        public ActionResult Create(int id)
        {
            ViewBag.PostId = id;
//ViewBag.UserId = db.BlogPostComments.Include(b => b.BlogPost).Include(b => b.Customer.Id).SingleOrDefault(b => b.Customer.Id == BlogPostComment.UserId);
            //ViewBag.UserId = db.BlogPostComments.Include(b => b.BlogPost).Include(b => b.Customer).id;
            return View();
        }

        // POST: BlogPostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostId,ContentOfComment,UserId")] BlogPostComment blogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.BlogPostComments.Add(blogPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.BlogPosts, "Id", "PostContent", blogPostComment.PostId);
            ViewBag.UserId = db.BlogPostComments.Include(b => b.BlogPost).Include(b => b.Customer.Id).SingleOrDefault(b=>b.Customer.Id==blogPostComment.UserId);
            //ViewBag.UserId = new SelectList(db.Customers, "Id", "Username", blogPostComment.UserId);
            return View(blogPostComment);
        }

        // GET: BlogPostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
            if (blogPostComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.BlogPosts, "Id", "PostContent", blogPostComment.PostId);
            ViewBag.UserId = new SelectList(db.Customers, "Id", "Username", blogPostComment.UserId);
            return View(blogPostComment);
        }

        // POST: BlogPostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,ContentOfComment,UserId")] BlogPostComment blogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.BlogPosts, "Id", "PostContent", blogPostComment.PostId);
            ViewBag.UserId = new SelectList(db.Customers, "Id", "Username", blogPostComment.UserId);
            return View(blogPostComment);
        }

        // GET: BlogPostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
            if (blogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(blogPostComment);
        }

        // POST: BlogPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
            db.BlogPostComments.Remove(blogPostComment);
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
