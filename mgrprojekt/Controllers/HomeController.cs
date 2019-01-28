using mgrprojekt.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mgrprojekt.Controllers
{
    public class HomeController : Controller
    {
        PrzychodniaContext db = new PrzychodniaContext();
        

        // GET: Home
        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult Onas()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View();
        }

        public ActionResult Lekarze()
        {
            return View();
        }
    }
}