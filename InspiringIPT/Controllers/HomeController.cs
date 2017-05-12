using InspiringIPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspiringIPT.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Cursos.ToList().OrderBy(n => n.NomeCurso).Take(1));
        }

        //Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Home/IPT
        public ActionResult Ipt()
        {
            ViewBag.Message = "Saiba quem somos.";

            return View();
        }
        public ActionResult Noticia()
        {
            ViewBag.Message = "Saiba quem somos.";

            return View();
        }
        public ActionResult Agenda()
        {
            ViewBag.Message = "Saiba quem somos.";

            return View();
        }
    }
}