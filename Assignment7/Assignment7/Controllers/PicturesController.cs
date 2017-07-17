using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.Tests;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class PicturesController : Controller
    {
        private PicturesRepository db = new PicturesRepository();

        // GET: Pictures
        public ActionResult Index()
        {
            ViewBag.NbTests = PicturesTest.NB_TESTS;
            ViewBag.Score = PicturesTest.Score;

            return View(db.Pictures());
        }

        // GET: Pictures/Test
        [HttpGet]
        public ActionResult Test(bool? @continue)
        {
            if (@continue == null)
                PicturesTest.Init();

            Picture nextPicture = PicturesTest.Next();

            if (nextPicture == null)
                return RedirectToAction("Index");

            ViewBag.Picture = nextPicture;
            ViewBag.NbTests = PicturesTest.NB_TESTS;
            ViewBag.NoTest = PicturesTest.NoTest;
            ViewBag.Score = PicturesTest.Score;

            return View();
        }

        // POST: Pictures/Test
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test([Bind(Include = "AnimalName,EnteredName")] PictureResult result)
        {
            if (ModelState.IsValid && result.EnteredName != null && result.EnteredName.Length > 0)
                if (PicturesTest.Test(result.AnimalName, result.EnteredName))
                    return RedirectToAction("Test", new { @continue = true });
                else
                    return RedirectToAction("WrongAnswer", db.Picture(result.AnimalName));
            else
            {
                ViewBag.Picture = db.Picture(result.AnimalName);
                ViewBag.NbTests = PicturesTest.NB_TESTS;
                ViewBag.NoTest = PicturesTest.NoTest;
                ViewBag.Score = PicturesTest.Score;

                return View(result);
            }
        }

        public ActionResult WrongAnswer(Picture picture)
        {
            ViewBag.NbTests = PicturesTest.NB_TESTS;
            ViewBag.NoTest = PicturesTest.NoTest;

            return View(picture);
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
