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
    public class AlunosController : Controller
    {
        // Cria uma referência à BD
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Alunos
        [Authorize]
        public ActionResult Perfil()
        {
            var userid = User.Identity.GetUserId();
            var user = (from a in db.Alunos where a.UserID == userid select a).Single();
            ViewBag.aluno = user;
            return View(user);
        }
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Lista()
        {
            IEnumerable<ListaAlunos> aluno =
                from a in db.Alunos
                join u in db.Users on a.UserID equals u.Id
                select new ListaAlunos
                {
                    AlunoID = a.AlunoID,
                    Nome = a.NomeCompleto,
                    Concelho = a.Concelho,
                    Curso = a.Curso,
                    EMAIL = a.Email,
                    Contacto = a.Contacto,
                    Sexo = a.Sexo,
                    Data_Nascimento = a.DataNascimento,
                    Habilitacoes = a.HabAcademicas,
                    Informacoes = a.InforCursos,
                    Areas = a.AreasInteresse,
                    Obs = a.Observacoes,
                };
            return View(aluno.ToList());
        }
        public ActionResult Index()
        {
            return RedirectToAction("Perfil");
        }

        // GET: Alunos/Details/5
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Alunos alunos = db.Alunos.Find(id);
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

        // GET: Alunos/Edit/5
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return RedirectToAction("Index");
            }
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Funcionarios")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,NomeCompleto,Concelho,Email,Contacto,Sexo,DataNascimento,HabAcademicas,InforCursos,AreasInteresse,Observacoes,UserID")] Alunos alunos)
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
            var user = (from a in db.Alunos where a.UserID == userid select a.AlunoID).Single();
            ViewBag.aluno = user;
            Alunos alunos = db.Alunos.Find(user);
            if (alunos == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(alunos);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Funcionarios")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "AlunoID,NomeCompleto,Concelho,Email,Contacto,Sexo,DataNascimento,HabAcademicas,InforCursos,AreasInteresse,Observacoes,UserID")] Alunos alunos)
        {
            TempData["cl"] = "Alterar Perfil";
            alunos.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                TempData["clienteSuccess"] = "Perfil Alterado com sucesso!";
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil");
            }
            TempData["clienteErro"] = "Verifique se introduziu bem os dados!";
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
