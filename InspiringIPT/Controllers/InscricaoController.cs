using InspiringIPT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspiringIPT.Controllers
{
    public class InscricaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscricao
        [Authorize]
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

        // GET: Inscrições/Details/5
        [Authorize]
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
            var tcurso = (from q in db.Cursos where inscricoes.CursoFK == q.CursoID select q.TipoCurso).Single();
            var nome = (from c in db.Alunos where inscricoes.AlunoFK == c.AlunoID select c.NomeCompleto).Single();

            ViewBag.nome = nome;
            ViewBag.tipo = tcurso;
            return View(inscricoes);

        }

        // GET: Inscrição/Create
        //[Authorize]
        public ActionResult ConsultarInscricao()
        {

            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso");
            return View();
        }

        // POST: Inscrição/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ConsultarInscricao([Bind(Include = "InscricaoID,DataInscricao,AlunoFK,CursoFK")] Inscricao inscricao)
        {
            var userid = User.Identity.GetUserId();

            // recupera o ID do utilizador
            inscricao.AlunoFK = (from c in db.Alunos where c.UserID == userid select c.AlunoID).Single();
            // regista a data em q foi efetuada a inscrição 
            inscricao.DataInscricao = DateTime.Now;
            // determina o ID da inscrição
            int newID = (from rr in db.Inscricao orderby rr.InscricaoID descending select rr.InscricaoID).FirstOrDefault() + 1;
            inscricao.InscricaoID = newID;

            if (ModelState.IsValid)
            {
                db.Inscricao.Add(inscricao);
                db.SaveChanges();
                // falta notificar utilizador q a inscrição foi efetuada com sucesso
                return RedirectToAction("Details", new { id = newID });
            }

            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso", inscricao.CursoFK);
            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
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
        [Authorize]
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

        // GET: Reservas/Delete/5
        [Authorize]
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
        // POST: Reservas/Delete/5
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