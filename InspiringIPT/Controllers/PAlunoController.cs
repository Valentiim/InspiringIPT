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
    public class PAlunoController : Controller
    {
        // Cria uma referência à BD
        private ApplicationDbContext db = new ApplicationDbContext();
        //// GET: Alunos
        //[Authorize(Roles = "Funcionarios")]
        //public ActionResult Perfil()
        //{
        //    var userid = User.Identity.GetUserId();
        //    var user = (from a in db.PotencialAluno where a.UserID == userid select a).Single();
        //    ViewBag.aluno = user;
        //    return View(user);
        //}
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Lista()
        {
            IEnumerable<ListaAlunos> aluno =
                from a in db.PotencialAluno
                join u in db.Users on a.UserID equals u.Id
                select new ListaAlunos
                {
                    AlunoID = a.AlunoID,
                    Nome = a.NomeCompleto,
                    Concelho = a.Concelho,
                    Data_Nascimento = a.DataNascimento,
                    EMAIL = u.Email,
                    Contacto = a.Contacto,
                    Genero = a.Genero,
                    Data_Inscricao = a.DataInscricao,
                    Habilitacoes = a.HabAcademicas,
                   
                };
            return View(aluno.ToList());
        }

        // GET: Alunos/Details/5
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            PotencialAluno alunos = db.PotencialAluno.Find(id);
            if (alunos == null)
            {
                return RedirectToAction("Index");
            }
            return View(alunos);
        }
        // GET: Alunos/Create
        public ActionResult Create()
        {
            return PartialView();
        }


        ////[Authorize(Roles = "Funcionarios")]
        //public ActionResult Index()
        //{
        //    var alunos = from m in db.PotencialAluno
        //                 select m;

        //    return View(alunos);
        //}

        // GET: Alunos/Edit/5
        //[Authorize(Roles = "Funcionarios")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            PotencialAluno alunos = db.PotencialAluno.Find(id);
            if (alunos == null)
            {
                return RedirectToAction("Index");
            }
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        //[Authorize(Roles = "Funcionarios")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,NomeCompleto,Email,Concelho,DataNascimento,Contacto,Genero,DataInscricao,HabAcademicas,UserID")] PotencialAluno alunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = alunos.AlunoID });
            }
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        [Authorize]
        public ActionResult Editar()
        {
            var userid = User.Identity.GetUserId();
            var user = (from a in db.PotencialAluno where a.UserID == userid select a.AlunoID).Single();
            ViewBag.aluno = user;
            PotencialAluno alunos = db.PotencialAluno.Find(user);
            if (alunos == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Funcionarios")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "AlunoID,NomeCompleto,Email,Concelho,DataNascimento,Contacto,Genero,DataInscricao,HabAcademicas,UserID")] PotencialAluno alunos)
        {
           
            alunos.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil");
            }
           
            return View(alunos);
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
