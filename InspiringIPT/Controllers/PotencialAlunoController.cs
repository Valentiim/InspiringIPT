using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InspiringIPT.Models;

namespace InspiringIPT.Controllers
{
    public class PotencialAlunoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PotencialAluno
        public ActionResult Index()
        {
            var potencialAluno = db.PotencialAluno.Include(p => p.Area).Include(p => p.Curso).Include(p => p.TipoC);
            return View(potencialAluno.ToList());
        }

        // GET: PotencialAluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotencialAluno potencialAluno = db.PotencialAluno.Find(id);
            if (potencialAluno == null)
            {
                return HttpNotFound();
            }
            return View(potencialAluno);
        }

        // GET: PotencialAluno/Create
        public ActionResult Create()
        {
            ViewBag.AreasFK = new SelectList(db.Areas, "AreaID", "NomeArea");
            ViewBag.CursosFK = new SelectList(db.Cursos, "CursoID", "NomeCurso");
            ViewBag.TiposCursosFK = new SelectList(db.TipoCurso, "TipoID", "Tipo");
            return View();
        }

        // POST: PotencialAluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoID,CursoID,AreaID,TipoID,NomeCompleto,Email,Concelho,DataNascimento,Contacto,Genero,DataInscricao,HabAcademicas,CursosFK,AreasFK,TiposCursosFK")] PotencialAluno potencialAluno)
        {
            if (ModelState.IsValid)
            {
                db.PotencialAluno.Add(potencialAluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreasFK = new SelectList(db.Areas, "AreaID", "NomeArea", potencialAluno.AreasFK);
            ViewBag.CursosFK = new SelectList(db.Cursos, "CursoID", "NomeCurso", potencialAluno.CursosFK);
            ViewBag.TiposCursosFK = new SelectList(db.TipoCurso, "TipoID", "Tipo", potencialAluno.TiposCursosFK);
            return View(potencialAluno);
        }

        // GET: PotencialAluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotencialAluno potencialAluno = db.PotencialAluno.Find(id);
            if (potencialAluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreasFK = new SelectList(db.Areas, "AreaID", "NomeArea", potencialAluno.AreasFK);
            ViewBag.CursosFK = new SelectList(db.Cursos, "CursoID", "NomeCurso", potencialAluno.CursosFK);
            ViewBag.TiposCursosFK = new SelectList(db.TipoCurso, "TipoID", "Tipo", potencialAluno.TiposCursosFK);
            return View(potencialAluno);
        }

        // POST: PotencialAluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,CursoID,AreaID,TipoID,NomeCompleto,Email,Concelho,DataNascimento,Contacto,Genero,DataInscricao,HabAcademicas,CursosFK,AreasFK,TiposCursosFK")] PotencialAluno potencialAluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potencialAluno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreasFK = new SelectList(db.Areas, "AreaID", "NomeArea", potencialAluno.AreasFK);
            ViewBag.CursosFK = new SelectList(db.Cursos, "CursoID", "NomeCurso", potencialAluno.CursosFK);
            ViewBag.TiposCursosFK = new SelectList(db.TipoCurso, "TipoID", "Tipo", potencialAluno.TiposCursosFK);
            return View(potencialAluno);
        }

        // GET: PotencialAluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotencialAluno potencialAluno = db.PotencialAluno.Find(id);
            if (potencialAluno == null)
            {
                return HttpNotFound();
            }
            return View(potencialAluno);
        }

        // POST: PotencialAluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PotencialAluno potencialAluno = db.PotencialAluno.Find(id);
            db.PotencialAluno.Remove(potencialAluno);
            db.SaveChanges();
            return RedirectToAction("Index");
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
