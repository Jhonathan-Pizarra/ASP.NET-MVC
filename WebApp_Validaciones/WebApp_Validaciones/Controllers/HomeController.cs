using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp_Validaciones.Models;

namespace WebApp_Validaciones.Controllers
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
        { //Si la propiedad IsValid del objeto ModelState almacena un true significa que todos los datos ingresados en el formulario se validaron correctamente para todas las reglas que definimos en el modelo
            if (ModelState.IsValid)
                return View("Correcto");
            else
                return View(per);
        }
        //En el caso que alguna de las validaciones no se cumple se ejecuta el else del if cargando nuevamente la vista "Index.cshtml" y con esto aparecen los mensajes de las validaciones que no se cumplen
    }
}