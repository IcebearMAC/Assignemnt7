using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.Tests;
using Assignment7.ViewModels;
using System.Linq;
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

            return View(db.Pictures().OrderBy(p => p.AnimalName));
        }

        // GET: Pictures/Test
        [HttpGet]
        public ActionResult Test(bool? @continue)
        {
            if (@continue == null)
                PicturesTest.Init();

            Picture nextPicture = PicturesTest.Next();

            if (PicturesTest.Score == null)
            {
                PicturesTest.Init();
                nextPicture = PicturesTest.Next();
            }

            if (nextPicture == null)
            {
                PicturesTest.End();
                return RedirectToAction("Index", "Scores");
            }

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
                {
                    Picture picture = db.Picture(result.AnimalName);
                    return RedirectToAction("WrongAnswer",
                                            new PictureWrongAnswerVM
                                            {
                                                EnteredName = result.EnteredName,
                                                PictureName = picture.PictureName,
                                                AnimalName = picture.AnimalName
                                            });
                }
            else
            {
                ViewBag.Picture = db.Picture(result.AnimalName);
                ViewBag.NbTests = PicturesTest.NB_TESTS;
                ViewBag.NoTest = PicturesTest.NoTest;
                ViewBag.Score = PicturesTest.Score;

                return View(result);
            }
        }

        public ActionResult WrongAnswer(PictureWrongAnswerVM viewModel)
        {
            ViewBag.NbTests = PicturesTest.NB_TESTS;
            ViewBag.NoTest = PicturesTest.NoTest;

            return View(viewModel);
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
