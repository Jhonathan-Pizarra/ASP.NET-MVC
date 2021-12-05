using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApp_SQLZapateria.Models;

namespace WebApp_SQLZapateria.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            return View(mc.RecuperarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            Calzado cal = mc.Recuperar(id);
            return View(cal);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            Calzado cal = new Calzado
            {
                Codigo = int.Parse(collection["codigo"]),
                Marca = collection["marca"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            mc.Alta(cal);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            Calzado cal = mc.Recuperar(id);
            return View(cal);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            Calzado cal = new Calzado
            {
                Codigo = id,
                Marca = collection["marca"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            mc.Modificar(cal);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            Calzado cal = mc.Recuperar(id);
            return View(cal);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoCalzado mc = new MantenimientoCalzado();
            mc.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
