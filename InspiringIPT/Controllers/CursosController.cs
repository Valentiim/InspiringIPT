using InspiringIPT.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspiringIPT.Controllers
{
    public class CursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cursos      
        public ActionResult Index()
        {
            return View(db.Cursos.OrderByDescending(m => m.Curso).ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var nomeIMG = (from q in db.Cursos where id == q.CursoID select q.ImagePath).Single();
            if (nomeIMG == null)
            {
                ViewBag.img = "image-not-found.jpg";
            }
            else
            {
                ViewBag.img = nomeIMG;
            }
            return View(cursos);
        }

        // GET: Cursos/Create
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Create([Bind(Include = "CursoID,TipoCurso,Curso,Descricao,ImagePath")]Cursos cursos, HttpPostedFileBase file)
        {
            TempData["AQ"] = "Tipo dos Cursos";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    cursos.ImagePath = file.FileName;
                }
                db.Cursos.Add(cursos);
                db.SaveChanges();
                TempData["AQSuccess"] = "Tipo dos Cursos acrescentado com Sucesso!";
                return RedirectToAction("Index");
            }
            TempData["AQErro"] = "Verifique se introduziu bem os dados!";
            return View(cursos);
        }
        [Authorize(Roles = "Funcionarios")]
        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(cursos);
        }
        [Authorize(Roles = "Funcionarios")]
        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Edit([Bind(Include = "CursoID,TipoCurso,Curso,Descricao,ImagePath")] Cursos cursos, HttpPostedFileBase file)
        {
            TempData["AQ"] = "Tipo dos Cursos";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    cursos.ImagePath = file.FileName;
                }
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AQSuccess"] = "Tipo dos Cursos alterado com Sucesso!";
                return RedirectToAction("Index");
            }
            TempData["AQErro"] = "Verifique se introduziu bem os dados!";
            return View(cursos);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

    