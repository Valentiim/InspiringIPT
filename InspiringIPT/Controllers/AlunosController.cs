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
            var user = (from c in db.Alunos where c.UserID == userid select c).Single();
            ViewBag.aluno = user;
            return View(user);
        }

        //permissão apenas para o utilizador "funcionário"
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Listagem()
        {
            IEnumerable<ListaAlunos> aluno =
                from a in db.Alunos
                join u in db.Users on a.UserID equals u.Id
                select new ListaAlunos
                {
                    AlunoID = a.AlunoID,
                    Nome = a.NomeCompleto,
                    Concelho = a.Concelho,
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
            //se não for fornecido o id, não funciona
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //procurar pelo Aluno, cujo o ID foi fornecido
            Alunos alunos = db.Alunos.Find(id);

            //se o animal não existe a página não é encontrada
            if (alunos == null)
            {
                return RedirectToAction("Index");
            }
            return View(alunos);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            //Se o código for executado é porque o modelo não é válido
            //voltar a criar os dados do dropdown
            ViewBag.curso = new SelectList(db.Cursos, "CursoID", "nome");

            return View();
        }

        public ActionResult Create([Bind(Include = "Animal_ID,nome,especie,raca,peso,dono")] Alunos Alunos)
        {
            //valida os dados recebidos com o modelo 
            if (ModelState.IsValid)
            {
                db.Alunos.Add(Alunos);
                //confirma a alteração
                db.SaveChanges();
                //redirecciona para a pagina de inicio
                return RedirectToAction("Index");
            }
            //Se o código for executado é porque o modelo não é válido
            //voltar a criar os dados do dropdown
            ViewBag.curso = new SelectList(db.Cursos, "ClienteID", "nome", Alunos.curso);
            return View(Alunos);
        }


        // GET: Alunos/Edit/5
        [Authorize(Roles = "Funcionarios")]
        public ActionResult Edit(int? id)
        {
            //se não for fornecido o id, não funciona
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //procurar pelo Aluno, cujo o ID foi fornecido
            Alunos alunos = db.Alunos.Find(id);

            //se o animal não existe a página não é encontrada
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
            TempData["cl"] = "Alterar Perfil";
            //valida os dados recebidos com o modelo 
            if (ModelState.IsValid)
            {
                TempData["clienteSuccess"] = "O seu perfil foi alterado com sucesso!";
                //altera o estado do Obj da base da dados
                db.Entry(alunos).State = EntityState.Modified;
                //confirma a alteração
                db.SaveChanges();
                //redirecciona para a pagina de detalhes
                return RedirectToAction("Details", new { id = alunos.AlunoID });
            }
            TempData["clienteErro"] = "Por favor! Verifique se os dados introduzidos estão corretos!";
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        [Authorize]
        public ActionResult Editar()
        {
            var userid = User.Identity.GetUserId();
            var user = (from c in db.Alunos where c.UserID == userid select c.AlunoID).Single();
            ViewBag.aluno = user;
            //procurar pelo aluno, cujo o ID foi fornecido
            Alunos alunos = db.Alunos.Find(user);
            //se o aluno não existe a página não é encontrada
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
                TempData["clienteSuccess"] = "O seu perfil foi alterado com sucesso!";
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil");
            }
            TempData["clienteErro"] = "Por favor! Verifique se os dados introduzidos estão corretos!";
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