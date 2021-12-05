using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp_FormsNoTipados.Models;

namespace WebApp_FormsNoTipados.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Search
        //Dentro de este método requerimos al modelo que retorne el artículo cuyo código coincide con el que ingresó el operador por teclado
        [HttpPost]
        public ActionResult Index(FormCollection coleccion) //Se ejecuta este método cuando se presiona el botón Submit
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(int.Parse(coleccion["Codigo"].ToString()));
            if (art != null)
                return View("ModificacionArticulo", art); //Si el artículo existe procedemos a llamar a la vista "ModificacionArticulo" y le pasamos la variable "art" para que la muestre
            else
                return View("ArticuloNoExistente");
        }


        [HttpPost]
        public ActionResult ModificacionArticulo(FormCollection coleccion)  //En éste método cargamos en un objeto de la clase Articulo los datos ingresados en el formulario y procedemos a pedir al modelo que efectúe los cambios en la tabla de la base de datos.
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
