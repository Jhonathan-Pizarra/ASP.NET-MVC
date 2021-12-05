using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_SQLSupermercado.Models;

namespace WebApp_SQLSupermercado.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View();
            MantenimientoArticulo ma = new MantenimientoArticulo();
            return View(ma.RecuperarTodos());
        }

        //POST:  tiene por objetivo mostrar la vista con un formulario HTML que permita ingresar los datos de un artículo
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection) //recibe como parámetro los datos cargados en el formulario.
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"]),
                Descripcion = collection["descripcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Alta(art);
            return RedirectToAction("Index");
        } //No se asocia una vista a esta acción ya que mediante el método RedirectToAction se solicita la ejecución de otra acción, en éste caso la acción "Index" que tiene por objetivo mostrar el listado completo de artículos.

        //PUT
        public ActionResult Modificacion(int cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(cod);
            return View(art);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"].ToString()),
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }


        //Delete
        public ActionResult Baja(int cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(cod);
            return RedirectToAction("Index");
        }
    }
}