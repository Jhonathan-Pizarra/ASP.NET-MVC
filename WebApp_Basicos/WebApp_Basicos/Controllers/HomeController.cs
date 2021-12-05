using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Basicos.Controllers
{
    public class HomeController : Controller
    {

        //Usando solo el controlador:
        /*
        public string Index()
        {
            return "<html><body><h1>Club de fútbol</h1><p>Club nacido en el barrio Solanda...</p></body></html>";
        }

        public string Plantel()
        {
            return "<html><body><h1>Jugadores</h1><p>Jhonathan<br>Jefferson<br>Anthony</p></body></html>";
        }
        */

        // GET: Home
        //Usando controlador + vista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Plantel()
        {
            return View();
        }
    }
}