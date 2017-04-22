using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InspiringIPT.Models;
using Microsoft.AspNet.Identity;

namespace InspiringIPT.Controllers
{
    public class InscricaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscricao
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var user = (from c in db.Alunos where c.UserID == userid select c.AlunoID).Single();
            IEnumerable<Lista> inscricoes =
                from r in db.Inscricao
                join q in db.Cursos on r.CursoFK equals q.CursoID
                where r.AlunoFK == user
                select new Lista
                {
                    InscricaoID = r.InscricaoID,
                    DataInscri = r.DataInscricao,
                    Curso = q.TipoCurso
                 
                };
            var lista = inscricoes.ToList().OrderByDescending(r => r.InscricaoID);
            return View(lista);
        }
        //Lista
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Lista()
        {
            IEnumerable<Lista> inscricoes =
                from r in db.Inscricao
                join q in db.Cursos on r.CursoFK equals q.CursoID
                join c in db.Alunos on r.AlunoFK equals c.AlunoID
                select new Lista
                {
                    InscricaoID = r.InscricaoID,
                    DataInscri = r.DataInscricao,
                   
                    Curso = q.TipoCurso,
                    Nome = c.NomeCompleto
                 
                };
            return View(inscricoes.ToList().OrderByDescending(r => r.InscricaoID));
        }

        // GET: Inscricao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Inscricao inscricoes = db.Inscricao.Find(id);

            if (inscricoes == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var tcurso = (from c in db.Cursos where inscricoes.CursoFK == c.CursoID select c.TipoCurso).Single();
            var nome = (from a in db.Alunos where inscricoes.AlunoFK == a.AlunoID select a.NomeCompleto).Single();
            

            ViewBag.nome = nome;
            ViewBag.tipo = tcurso;
            return View(inscricoes);
        }

        // GET: Inscricao/Create
        public ActionResult ConsultarInscricao()
        {
            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso");
            return View();
        }

        // POST: Inscricao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ConsultarInscricao([Bind(Include = "InscricaoID,DataInscricao,AlunoFK,CursoFK")] Inscricao inscricao)
        {
            var userid = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Inscricao.Add(inscricao);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso", inscricao.CursoFK);

            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Inscricao inscricoes = db.Inscricao.Find(id);
            if (inscricoes == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(inscricoes);
        }

        // POST: Inscricao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscricaoID,DataInscricao,AlunoFK,CursoFK")] Inscricao inscricao)
        {
          
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoFK = new SelectList(db.Cursos, "QuartoID", "TipoCurso", inscricao.CursoFK);
            return View(inscricao);
        }

        // GET: Inscricao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricao.Find(id);
            db.Inscricao.Remove(inscricao);
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
