namespace InspiringIPT.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InspiringIPT.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//permite a actualiza��o autom�tica da BD
        }

        protected override void Seed(InspiringIPT.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //########################################################
            //adiciona Alunos
            var alunos = new List<Alunos>
            {
                new Alunos {AlunoID=1, NomeCompleto="Arru� Valentim", Concelho="Tomar",Curso="Inform�tica", Email="arrua.afonso@gmail.com", Contacto="967325844", Sexo="Masculino", DataNascimento="05-02-1984", HabAcademicas="Licenciatura", InforCursos="Inform�tica", AreasInteresse="Inform�tica",Observacoes="Sobre o curso"},
                new Alunos {AlunoID=2, NomeCompleto="Ant�nio Valentim Afonso", Concelho="Abrantes",Curso="TIC", Email="arrua.valentim@hotmail.com", Contacto="910202099", Sexo="Masculino", DataNascimento="01-04-2000", HabAcademicas="CTesp", InforCursos="Acesso ao curso", AreasInteresse="Tecnologias",Observacoes="Nada acrescentar"},
                new Alunos {AlunoID=3, NomeCompleto="Maria Concei��o Carvalho", Concelho="Leiria",Curso="Fotogr�fia", Email="m.carvalho@hotmail.com", Contacto="930567234", Sexo="Feminino", DataNascimento="04-04-1993", HabAcademicas="12�", InforCursos="Acesso ao curso", AreasInteresse="Gest�o",Observacoes="Nada acrescentar"},
                new Alunos {AlunoID=4, NomeCompleto="Pedro Alves Pinto", Concelho="F�tima",Curso="Turismo", Email="pedro_pinto@hotmail.com", Contacto="967325844", Sexo="Masculino", DataNascimento="01-01-1998", HabAcademicas="CET", InforCursos="Medias para o ingresso a lincenciatura", AreasInteresse="Gest�o",Observacoes="Nada acrescentar"},
                new Alunos {AlunoID=5, NomeCompleto="Concei��o Sousa Carlos", Concelho="Torres Novas",Curso="Artes Gr�ficas", Email="conceicao_c@hotmail.com", Contacto="928004236", Sexo="Feminino", DataNascimento="11-11-1999", HabAcademicas="CET", InforCursos="Acesso ao curso", AreasInteresse="Tecnologias",Observacoes="Nada acrescentar"},
                new Alunos {AlunoID=6, NomeCompleto="Paulo Alexandra Costa", Concelho="Batalha",Curso="Gest�o de Recursos Humanos", Email="pcosta@hotmail.com", Contacto="967326844", Sexo="Masculino", DataNascimento="11-04-2000", HabAcademicas="12�", InforCursos="Acesso ao curso", AreasInteresse="Tecnologias",Observacoes="Nada acrescentar"}
            };
            alunos.ForEach(aa => context.Alunos.AddOrUpdate(a => a.NomeCompleto, aa));
            context.SaveChanges();

            //########################################################
            //adiciona Cursos
            var cursos = new List<Cursos>
            {

                new Cursos {CursoID=3, Curso="Engenharia Inform�tica", TipoCurso="Licenciatura", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"},
                new Cursos {CursoID=4, Curso="Fotogr�fia", TipoCurso="Licenciatura", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"},
                new Cursos {CursoID=5, Curso="Gest�o de Recursos Humanos", TipoCurso="Licenciatura", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"},
                new Cursos {CursoID=6, Curso="Turismo", TipoCurso="CTesp", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"},
                new Cursos {CursoID=7, Curso="Artes Gr�ficas", TipoCurso="CTesp", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"},
                new Cursos {CursoID=8, Curso="Conserva��o e Restauro", TipoCurso="Licenciatura", Descricao="Especializados na �rea da Engenharia de Software, design, desenvolvimento e manuten��o de software, telem�veis, tablets, consolas de jogos, sistemas embebidos, etc.)"}
            };
            cursos.ForEach(cc => context.Cursos.AddOrUpdate(c => c.Curso, cc));
            context.SaveChanges();

            //########################################################
            //adiciona Inscri��o
            var inscricoes = new List<Inscricao> {
                new Inscricao  {InscricaoID = 1, DataInscricao =  new DateTime(2017,02,05), AlunoFK = 1, CursoFK = 3 },
                new Inscricao  {InscricaoID = 2, DataInscricao =  new DateTime(2016,02,06), AlunoFK = 2, CursoFK = 4 },
                new Inscricao  {InscricaoID = 3, DataInscricao =  new DateTime(2017,04,09), AlunoFK = 3, CursoFK = 5 },
                new Inscricao  {InscricaoID = 4, DataInscricao =  new DateTime(2015,03,09), AlunoFK = 4, CursoFK = 6 },
                new Inscricao  {InscricaoID = 5, DataInscricao =  new DateTime(2017,04,22), AlunoFK = 5, CursoFK = 7 },
                new Inscricao  {InscricaoID = 6, DataInscricao =  new DateTime(2014,03,24), AlunoFK = 6, CursoFK = 8 }
            };

            inscricoes.ForEach(ii => context.Inscricao.Add(ii));
            context.SaveChanges();



        }
    }
}
