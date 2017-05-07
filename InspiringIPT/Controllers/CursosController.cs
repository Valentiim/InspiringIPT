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
        // Cria uma referência à BD
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

            { 
                return View(cursos);
            }
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
        public ActionResult Create([Bind(Include = "CursoID,TipoCurso,Curso,Descricao")]Cursos cursos, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
               
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
        public ActionResult Edit([Bind(Include = "CursoID,TipoCurso,Curso,Descricao")] Cursos cursos, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

    