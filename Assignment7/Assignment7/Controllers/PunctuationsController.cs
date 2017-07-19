using Assignment7.Exercises.Punctuations;
using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class PunctuationsController : Controller
    {
        private PunctuationsRepository db = new PunctuationsRepository();

        [HttpGet]
        public ActionResult Test()
        {
            if (PunctuationExercises.Score == null)
                PunctuationExercises.Init();

            return View(db.Split(PunctuationExercises.Punctuation.Text));
        }

        [HttpPost]
        public ActionResult Test(List<Character> model)
        {
            if (ModelState.IsValid)
            {
                if (PunctuationExercises.Test(model))
                {
                    PunctuationExercises.End();
                    return RedirectToAction("Index", "Scores");
                }
                else
                    return RedirectToAction("Result", new { enteredText = db.Join(db.Split(PunctuationExercises.Punctuation.Text), model) });
            }
            else
            {
                return View(db.Split(PunctuationExercises.Punctuation.Text));
            }
        }

        public ActionResult Result(string enteredText)
        {
            if (enteredText == null || PunctuationExercises.Score == null)
            {
                PunctuationExercises.End();
                return RedirectToAction("Index", "Main");
            }

            string originalText = PunctuationExercises.Punctuation.Text;
            Score score = PunctuationExercises.Score;

            PunctuationExercises.End();

            return View(new PunctuationWrongAnswer
            {
                OriginalText = originalText,
                EnteredText = enteredText,
                Score = score
            });
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
