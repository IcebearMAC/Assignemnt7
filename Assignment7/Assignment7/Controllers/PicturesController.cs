using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.Exercises;
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
            ViewBag.NbTests = PictureExercises.NB_TESTS;
            ViewBag.Score = PictureExercises.Score;

            return View(db.Pictures().OrderBy(p => p.AnimalName));
        }

        // GET: Pictures/Test
        [HttpGet]
        public ActionResult Test(bool? @continue)
        {
            if (@continue == null)
                PictureExercises.Init();

            Picture nextPicture = PictureExercises.Next();

            if (PictureExercises.Score == null)
            {
                PictureExercises.Init();
                nextPicture = PictureExercises.Next();
            }

            if (nextPicture == null)
            {
                PictureExercises.End();
                return RedirectToAction("Index", "Scores");
            }

            ViewBag.Picture = nextPicture;
            ViewBag.NbTests = PictureExercises.NB_TESTS;
            ViewBag.NoTest = PictureExercises.NoTest;
            ViewBag.Score = PictureExercises.Score;

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
                if (PictureExercises.Test(result.AnimalName, result.EnteredName))
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
                ViewBag.NbTests = PictureExercises.NB_TESTS;
                ViewBag.NoTest = PictureExercises.NoTest;
                ViewBag.Score = PictureExercises.Score;

                return View(result);
            }
        }

        public ActionResult WrongAnswer(PictureWrongAnswerVM viewModel)
        {
            ViewBag.NbTests = PictureExercises.NB_TESTS;
            ViewBag.NoTest = PictureExercises.NoTest;

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
