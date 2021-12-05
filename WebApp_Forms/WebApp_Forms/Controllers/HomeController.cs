using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp_Forms.Models;

namespace WebApp_Forms.Controllers
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
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(int.Parse(coleccion["Codigo"].ToString()));
            if (art != null)
                return View("ModificacionArticulo", art);
            else
                return View("ArticuloNoExistente");
        }

        [HttpPost]
        public ActionResult ModificacionArticulo(FormCollection coleccion)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(coleccion["Codigo"].ToString()),
                Descripcion = coleccion["Descripcion"].ToString(),
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }
    }
}