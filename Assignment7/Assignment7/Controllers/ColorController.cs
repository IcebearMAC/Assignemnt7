using Assignment7.Repositories;
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

        // GET: Color
        public ActionResult Index()
        {
            return View();
        }

        
    }
}