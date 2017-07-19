using Assignment7.Exercises.Colors;
using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class ColorController : Controller
    {

        ColorRepository cr = new ColorRepository();
        RandomColorsVM RandomColors = new RandomColorsVM();

        // GET: Color
        public ActionResult Index()
        {
            ViewBag.NbTests = ColorExercises.NB_TESTS;
            ViewBag.Score = ColorExercises.Score;

            return View(cr.Colors().OrderBy(c => c.Name));
        }

        //GET: Pictures/Test
        [HttpGet]
        public ActionResult Test(bool? @continue)
        {
            if (@continue == null)
                ColorExercises.Init();

            List<Color> nextColorList = ColorExercises.Next();

            if (ColorExercises.Score == null)
            {
                ColorExercises.Init();
                nextColorList = ColorExercises.Next();
            }

            if (nextColorList == null)
            {
                ColorExercises.End();
                return RedirectToAction("Index", "Scores");
            }

            ViewBag.ColorList = nextColorList;
            ViewBag.NbTests = ColorExercises.NB_TESTS;
            ViewBag.NoTest = ColorExercises.NoTest;
            ViewBag.Score = ColorExercises.Score;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test([Bind(Include = "ColorName,EnteredName")] ColorResult result)
        {
            if (ModelState.IsValid && result.EnteredName != null && result.ColorName.Length > 0)
                if (ColorExercises.Test(result.ColorName, result.EnteredName))
                    return RedirectToAction("Test", new { @continue = true });
                else
                {
                    Color color = cr.Color(result.ColorName);
                    return RedirectToAction("WrongAnswer",
                                            new ColorWrongAnswerVM
                                            {
                                                EnteredName = result.EnteredName,
                                                ColorName = color.Name,
                                            });
                }
            else
            {
                ViewBag.ColorList = cr.Color(result.ColorName);
                ViewBag.NbTests = ColorExercises.NB_TESTS;
                ViewBag.NoTest = ColorExercises.NoTest;
                ViewBag.Score = ColorExercises.Score;

                return View(result);
            }
        }

        public ActionResult WrongAnswer(ColorWrongAnswerVM viewModel)
        {
            ViewBag.NbTests = ColorExercises.NB_TESTS;
            ViewBag.NoTest = ColorExercises.NoTest;

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cr.Dispose();
            }
            base.Dispose(disposing);
        }
        //public ActionResult NewQuestion()
        //{
        //    List<Color> rColor = cr.Randomize().ToList();

        //    RandomColors.Color1 = rColor[0];
        //    RandomColors.Color2 = rColor[1];
        //    RandomColors.Color3 = rColor[2];
        //    RandomColors.Color4 = rColor[3];

        //    return View(RandomColors);
        //}

        //[HttpPost]
        //public ActionResult NewQuestion(int? choiceID, int? answerID)
        //{
        //   cr.CheckAnswer(choiceID, answerID);
        //    while (cr.colorScore.NumOfQuestions < 4)
        //    {
        //        return RedirectToAction("NewQuestion");
        //    }
        //    return RedirectToAction("ShowResults");
        //}

        //public ActionResult ShowResults()
        //{
        //    return View();
        //}
    }
}