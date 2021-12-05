using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_RegistroCivil.Models;

namespace WebApp_RegistroCivil.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        {
            MantenimientoPersona m = new MantenimientoPersona();
            Persona per = m.Retornar(int.Parse(coleccion["Codigo"].ToString()));
            if (per != null)
                return View("EditarPersona", per);
            else
                return RedirectToAction("Index");
        }
    }
}