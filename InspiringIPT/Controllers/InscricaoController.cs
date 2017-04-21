using InspiringIPT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var user = (from c in db.Alunos where c.UserID == userid select c.AlunoID).Single();
            IEnumerable<Lista> inscricoes =
                from r in db.Inscricao
                join q in db.Cursos on r.CursoFK equals q.CursoID
                where r.AlunoFK == user
                select new Lista
                {
                    InscricaoID = r.InscricaoID,
                    DataInscri = r.DataInscricao,
                    Curso = q.TipoCurso,
                   
                };
            var lista = inscricoes.ToList().OrderByDescending(r => r.InscricaoID);
            return View(lista);
        }
        //Lista
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Lista()
        {
            IEnumerable<Lista> reservas =
                from r in db.Inscricao
                join q in db.Cursos on r.CursoFK equals q.CursoID
                join c in db.Alunos on r.AlunoFK equals c.AlunoID
                select new Lista
                {
                    InscricaoID = r.InscricaoID,
                    Nome = c.NomeCompleto,
                    Curso = q.TipoCurso,
                    DataInscri = r.DataInscricao,
                 
              
                };

            return View(reservas.ToList().OrderByDescending(r => r.InscricaoID));
        }
        // GET: Inscrição/Details/5
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
            var tcurso = (from q in db.Cursos where inscricoes.CursoFK == q.CursoID select q.TipoCurso).Single();
            var nome = (from c in db.Alunos where inscricoes.AlunoFK == c.AlunoID select c.NomeCompleto).Single();
           

            ViewBag.nome = nome;
            ViewBag.tipo = tcurso;
            return View(inscricoes);

        }

        // GET: Inscrição/Create
        [Authorize]
        public ActionResult CriarInscricao()
        {

            ViewBag.CursoFK = new SelectList(db.Cursos, "CursoID", "TipoCurso");
            return View();
        }


        // GET: Inscrição/Edit/5
        [Authorize]
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



        // GET: Inscrições/Delete/5
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
