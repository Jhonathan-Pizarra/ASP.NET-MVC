using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp_ListaErrores.Models;

namespace WebApp_ListaErrores.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Persona per = new Persona();
            return View(per);
        }

        [HttpPost]
        public ActionResult Index(Persona per)
        {
            if (ModelState.IsValid)
                return View("Correcto");
            else
                return View(per);
        }
    }
}