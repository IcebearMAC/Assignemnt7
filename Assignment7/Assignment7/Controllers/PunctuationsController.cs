using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment7.DataAccess;
using Assignment7.Models;

namespace Assignment7.Controllers
{
    public class PunctuationsController : Controller
    {
        private EducationContext db = new EducationContext();

        // GET: Punctuations
        public ActionResult Index()
        {
            return View(db.Punctuations.ToList());
        }

        // GET: Punctuations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punctuation punctuation = db.Punctuations.Find(id);
            if (punctuation == null)
            {
                return HttpNotFound();
            }
            return View(punctuation);
        }

        // GET: Punctuations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Punctuations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text")] Punctuation punctuation)
        {
            if (ModelState.IsValid)
            {
                db.Punctuations.Add(punctuation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(punctuation);
        }

        // GET: Punctuations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punctuation punctuation = db.Punctuations.Find(id);
            if (punctuation == null)
            {
                return HttpNotFound();
            }
            return View(punctuation);
        }

        // POST: Punctuations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text")] Punctuation punctuation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punctuation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(punctuation);
        }

        // GET: Punctuations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punctuation punctuation = db.Punctuations.Find(id);
            if (punctuation == null)
            {
                return HttpNotFound();
            }
            return View(punctuation);
        }

        // POST: Punctuations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Punctuation punctuation = db.Punctuations.Find(id);
            db.Punctuations.Remove(punctuation);
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
