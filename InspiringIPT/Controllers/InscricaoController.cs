using InspiringIPT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace InspiringIPT.Controllers
{
    public class InscricaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscrição
        [Authorize]
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var user = (from a in db.Alunos where a.UserID == userid select a.AlunoID).Single();
            IEnumerable<Lista> inscricoes =
                from i in db.Inscricao
                join c in db.Cursos on i.CursoFK equals c.CursoID
                where i.AlunoFK == user
                select new Lista
                {
                    InscricaoID = i.InscricaoID,
                    DataInscri = i.DataInscricao,
                    Curso = c.TipoCurso

                };
            var lista = inscricoes.ToList().OrderByDescending(i => i.InscricaoID);
            return View(lista);
        }

        //Lista
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Lista()
        {
            IEnumerable<Lista> inscricoes =
                from i in db.Inscricao
                join c in db.Cursos on i.CursoFK equals c.CursoID
                join a in db.Alunos on i.AlunoFK equals a.AlunoID
                select new Lista
                {
                    InscricaoID = i.InscricaoID,
                    DataInscri = i.DataInscricao,
                    Curso = c.TipoCurso,
                    Nome = a.NomeCompleto

                };

            return View(inscricoes.ToList().OrderByDescending(i => i.InscricaoID));
        }

        // GET: Inscrições/Details/5
        [Authorize]
        [Authorize(Roles = "Funcionarios")]
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

        // GET: Inscrição/Create
        //[Authorize]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult ConsultarInscricao()
        {

            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso");
            return View();
        }

        // POST: Inscrição/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult ConsultarInscricao([Bind(Include = "InscricaoID,DataInscricao,AlunoFK,CursoFK")] Inscricao inscricao)
        {
            var userid = User.Identity.GetUserId();

            // recupera o ID do utilizador
            inscricao.AlunoFK = (from a in db.Alunos where a.UserID == userid select a.AlunoID).Single();
            // regista a data em q foi efetuada a inscrição 
            inscricao.DataInscricao = DateTime.Now;
            // determina o ID da inscrição, e a ordem a começa por um
            int newID = (from ii in db.Inscricao orderby ii.InscricaoID descending select ii.InscricaoID).FirstOrDefault() + 1;
            inscricao.InscricaoID = newID;

            if (ModelState.IsValid)
            {
                
                db.Inscricao.Add(inscricao);
                db.SaveChanges();
              
                return RedirectToAction("Details", new { id = newID });
            }

            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso", inscricao.CursoFK);
            return View(inscricao);
        }

        // GET: Inscrição/Edit/5
        //[Authorize]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Edit([Bind(Include = "InscricaoID,DataInscricao,AlunoFK,CursoFK")] Inscricao inscricao)
        {
            var userid = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = inscricao.InscricaoID });
            }
            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso", inscricao.CursoFK);
            return View(inscricao);
        }

        // GET: Inscrição/Delete/5
        [Authorize]
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Delete(int? id)
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
            return View(inscricoes);
        }

        [Authorize]
        // POST: Inscrição/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricao.Find(id);
            try
            {

                db.Inscricao.Remove(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(inscricao);
            }
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