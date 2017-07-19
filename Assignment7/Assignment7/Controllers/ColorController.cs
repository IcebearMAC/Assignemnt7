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
            return View();
        }

        public ActionResult NewQuestion()
        {
            List<Color> rColor = cr.Randomize().ToList();

            RandomColors.Color1 = rColor[0];
            RandomColors.Color2 = rColor[1];
            RandomColors.Color3 = rColor[2];
            RandomColors.Color4 = rColor[3];

            return View(RandomColors);
        }

        [HttpPost]
        public ActionResult NewQuestion(int? choiceID, int? answerID)
        {
           cr.CheckAnswer(choiceID, answerID);
            while (cr.colorScore.NumOfQuestions < 4)
            {
                return RedirectToAction("NewQuestion");
            }
            return RedirectToAction("ShowResults");
        }

        public ActionResult ShowResults()
        {
            return View();
        }
    }
}