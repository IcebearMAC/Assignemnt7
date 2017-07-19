using Assignment7.Exercises.Calculus;
using Assignment7.Models;
using Assignment7.Repositories;
using Assignment7.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class CalculusController : Controller
    {

        // GET: Calculus
        public ActionResult Index()
        {
            return View();
        }

        //private CalculusRepository db = new CalculusRepository();

        [HttpGet]
        public ActionResult Test()
        {
            CalculusExercises.Init();
            ViewData["firstnumber"] = CalculusExercises.FirstNumber;
            ViewData["secondnumber"] = CalculusExercises.SecondNumber;
            ViewData["viewoperator"] = CalculusExercises.ViewOperator;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test([Bind(Include = "pupilAnswer")] CalculusResults result)
        {
            if (ModelState.IsValid && result.pupilAnswer != null)
                if (CalculusExercises.Test(result.pupilAnswer))
                {
                    CalculusExercises.End();
                    return RedirectToAction("Index", "Scores");
                }
                else
                {
                    return RedirectToAction("WrongAnswer",
                                            new CalculusWrongAnswerVM
                                            {
                                                PupilAnswer = result.pupilAnswer,
                                                Answer = CalculusExercises.Answer
                                            });
                }
            else
            {
                ViewData["firstnumber"] = CalculusExercises.FirstNumber;
                ViewData["secondnumber"] = CalculusExercises.SecondNumber;
                ViewData["viewoperator"] = CalculusExercises.ViewOperator;

                return View();
            }
        }

        public ActionResult WrongAnswer(CalculusWrongAnswerVM viewModel)
        {
            CalculusExercises.End();

            return View(viewModel);
        }
    
    }
}
