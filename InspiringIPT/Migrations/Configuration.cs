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
            AutomaticMigrationsEnabled = true;//permite a actualização automática da BD
        }

        protected override void Seed(InspiringIPT.Models.ApplicationDbContext context)
        {

            //########################################################
            //adiciona os Potenciais Alunos
            var alunos = new List<PotencialAluno>
            {
                new PotencialAluno {AlunoID=1, NomeCompleto="Arruá Valentim Afonso",Email="arrua.afonso@gmail.com",Concelho="Tomar",DataNascimento = "05-02-2000",Contacto="967325844",Genero="Masculino", DataInscricao = ("11-05-2017"),HabAcademicas="Licenciatura", },
                new PotencialAluno {AlunoID=2, NomeCompleto="João Gomes Cravid",Email="jgomesc@gmail.com",Concelho="Tomar",DataNascimento = "25,04,1999",Contacto="910202099",Genero="Masculino", DataInscricao = ("11-05-2017"),HabAcademicas="Licenciatura"},
                new PotencialAluno {AlunoID=3, NomeCompleto="Paulo Duque Júnior",Email="pauloj@gmail.com",Concelho="Tomar",DataNascimento = ("15-02-2001"),Contacto="967386733",Genero="Masculino", DataInscricao = ("11-05-2017"),HabAcademicas="Licenciatura"},
                new PotencialAluno {AlunoID=4, NomeCompleto="Ana Maria Conceição Lima",Email="a.lima@gmail.com",Concelho="Tomar",DataNascimento = ("01-06-1998"),Contacto="917834672",Genero="Feminino", DataInscricao = ("11-05-2017"),HabAcademicas="TeSPs"},
            };
            alunos.ForEach(aa => context.PotencialAluno.AddOrUpdate(a => a.NomeCompleto, aa));
            context.SaveChanges();

            //########################################################
            //adiciona Cursos
            var cursos = new List<Cursos>
            {

                new Cursos {CursoID=1, NomeCurso="Engenharia Informática", SiglaCurso="EI", Descricao="Falta descrever", EscolaFK=5, AreaFK=2,TipoCursoFK=4},
                new Cursos {CursoID=2, NomeCurso="Gestão Turística e Cultural", SiglaCurso="GTC", Descricao="Falta descrer",EscolaFK=3, AreaFK=5,TipoCursoFK=2},
                new Cursos {CursoID=3, NomeCurso="Design e Tecnologia das Artes Gráficas", SiglaCurso="DTAG", Descricao="Falta descrer",EscolaFK=4, AreaFK=4,TipoCursoFK=3},
                new Cursos {CursoID=4, NomeCurso="Engenharia Electrotécnica e de Computadores", SiglaCurso="EEC", Descricao="Falta descrer", EscolaFK=6, AreaFK=3,TipoCursoFK=5}

            };
            cursos.ForEach(cc => context.Cursos.AddOrUpdate(c => c.NomeCurso, cc));
            context.SaveChanges();

            

        //########################################################
        //adiciona as Áreas
        var areas = new List<Areas> {
                new Areas  {AreaID = 1, NomeArea = "Engenharia e Tecnologia"},
                new Areas  {AreaID = 2, NomeArea = "Gestão"},
                new Areas  {AreaID = 3, NomeArea = "Design"},
                new Areas  {AreaID = 4, NomeArea = "Turismo"}

            };
            areas.ForEach(arar => context.Areas.AddOrUpdate(ar => ar.NomeArea, arar));
            context.SaveChanges();

            //########################################################
            //adiciona os Tipo do Curso
            var tiposcursos = new List<TipoCurso> {
                new TipoCurso  {TipoID = 1, Tipo = "Licenciatura"},
                new TipoCurso  {TipoID = 2, Tipo = "Mestrado"},
                new TipoCurso  {TipoID = 3, Tipo = "TeSPs"},
                new TipoCurso  {TipoID = 4, Tipo = "M23"}
            };

            tiposcursos.ForEach(tt => context.TipoCurso.AddOrUpdate(t => t.Tipo, tt));
            context.SaveChanges();

            //########################################################
            //adiciona as Escolas
            var escolas = new List<Escola> {
                new Escola  {EscolaID = 1, NomeEscola = "Escola Superior de Tecnologia de Tomar", SiglaEscola="ESTT"},
                new Escola  {EscolaID = 2, NomeEscola = "Escola Superior de Gestão de Tomar",SiglaEscola="ESGT"},
                new Escola  {EscolaID = 3, NomeEscola = "Escola Superior de Tecnologia de Abrantes",SiglaEscola="ESTA"}
               
            };

            escolas.ForEach(ee => context.Escola.AddOrUpdate(e => e.NomeEscola, ee));
            context.SaveChanges();

            //########################################################
            //adiciona as outras areas 
            var outrasareas = new List<OutrasAreas> {
                new OutrasAreas  {OutrasID = 1, DescriArea = "Falta descrever", PotencialAlunoFK=1, AreaFK=3},
                new OutrasAreas  {OutrasID = 2, DescriArea = "Falta descrever", PotencialAlunoFK=1, AreaFK=6},
                new OutrasAreas  {OutrasID = 3, DescriArea = "Falta descrever", PotencialAlunoFK=1, AreaFK=5},
                new OutrasAreas  {OutrasID = 4, DescriArea = "Falta descrever", PotencialAlunoFK=1, AreaFK=8}
            };

            outrasareas.ForEach(oa => context.OutrasAreas.Add(oa));
            context.SaveChanges();

            //########################################################
            //adiciona as outras areas 
            var outroscursos = new List<OutrosCursos> {
                new OutrosCursos  {OutrosID = 1, OutrasFormacoes = "Falta descrever", PotencialAlunoFK=1, TipoCursoFK=6},
                new OutrosCursos  {OutrosID = 2, OutrasFormacoes = "Falta descrever", PotencialAlunoFK=1, TipoCursoFK=2},
                new OutrosCursos  {OutrosID = 3, OutrasFormacoes = "Falta descrever", PotencialAlunoFK=1, TipoCursoFK=3},
                new OutrosCursos  {OutrosID = 4, OutrasFormacoes = "Falta descrever", PotencialAlunoFK=1, TipoCursoFK=7}
            };

            outroscursos.ForEach(oc => context.OutrosCursos.Add(oc));
            context.SaveChanges();


        }
    }
}
