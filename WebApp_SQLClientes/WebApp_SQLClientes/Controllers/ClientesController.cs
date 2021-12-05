using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_SQLClientes.Controllers
{
    public class ClientesController : Controller
    {
        //Get
        public ActionResult Listado()
        {
            return View();
        }

        //POST
        public ActionResult Alta()
        {
            return View();
        }
    }
}