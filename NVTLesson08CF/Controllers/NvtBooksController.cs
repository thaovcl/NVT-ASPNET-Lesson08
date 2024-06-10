using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NVTLesson08CF.Models;

namespace NVTLesson08CF.Controllers
{
    public class NvtBooksController : Controller
    {
        private NvtBookStore db = new NvtBookStore();

        // GET: NvtBooks
        public ActionResult Index()
        {
            var nvtBooks = db.NvtBooks.Include(n => n.GetNvtCategory);
            return View(nvtBooks.ToList());
        }

        // GET: NvtBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtBook nvtBook = db.NvtBooks.Find(id);
            if (nvtBook == null)
            {
                return HttpNotFound();
            }
            return View(nvtBook);
        }

        // GET: NvtBooks/Create
        public ActionResult Create()
        {
            ViewBag.NvtCategoryId = new SelectList(db.NvtCategories, "NvtCategoryId", "CategoryName");
            return View();
        }

        // POST: NvtBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NvtBookId,NvtTitle,NvtAuthor,NvtYear,NvtPublisher,NvtPicture,NvtCategoryId")] NvtBook nvtBook)
        {
            if (ModelState.IsValid)
            {
                db.NvtBooks.Add(nvtBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NvtCategoryId = new SelectList(db.NvtCategories, "NvtCategoryId", "CategoryName", nvtBook.NvtCategoryId);
            return View(nvtBook);
        }

        // GET: NvtBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtBook nvtBook = db.NvtBooks.Find(id);
            if (nvtBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.NvtCategoryId = new SelectList(db.NvtCategories, "NvtCategoryId", "CategoryName", nvtBook.NvtCategoryId);
            return View(nvtBook);
        }

        // POST: NvtBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NvtBookId,NvtTitle,NvtAuthor,NvtYear,NvtPublisher,NvtPicture,NvtCategoryId")] NvtBook nvtBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvtBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NvtCategoryId = new SelectList(db.NvtCategories, "NvtCategoryId", "CategoryName", nvtBook.NvtCategoryId);
            return View(nvtBook);
        }

        // GET: NvtBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtBook nvtBook = db.NvtBooks.Find(id);
            if (nvtBook == null)
            {
                return HttpNotFound();
            }
            return View(nvtBook);
        }

        // POST: NvtBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NvtBook nvtBook = db.NvtBooks.Find(id);
            db.NvtBooks.Remove(nvtBook);
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
