using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment7.Models;
using Assignment7.Repositories;

namespace Assignment7.Controllers
{
    public class WordsController : Controller
    {
        WordRepository db=new WordRepository();

        // GET: Words
        public ActionResult WordsRandom()
        {
            Word word = db.RandomWords();

            return View(model:string.Join(" ", db.Randomize(word)));
        }

        //Post : Words
        [HttpPost]
        public ActionResult WordsRight()
        {
            return View();
        }


    }
}