using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Periodicos()
        {
            return View();
        }

        public ActionResult Buscadores()
        {
            return View();
        }

        public ActionResult Blogs()
        {
            return View();
        }
    }
}