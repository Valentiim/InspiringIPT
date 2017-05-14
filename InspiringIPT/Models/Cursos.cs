using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            // inicialização da lista de um Curso
            ListaAreaAluno = new HashSet<PotencialAluno>();
      

        }
        [Key]
        public int CursoID { get; set; }

        [Display(Name = "Nome do Curso:")]
        public string NomeCurso { get; set; }

        [Display(Name = "Sigla do Curso:")]
        public string SiglaCurso { get; set; }

        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        // **************************
        // criar a chave forasteira, e cria um atributo
        // relaciona o objeto Cursos com um objeto Área
        [Display(Name = "Áreas:")]
        public int AreaFK { get; set; }
        public virtual Areas Areas { get; set; }

        [Display(Name = "Tipo do Curso:")]
        public int TipoCursoFK { get; set; }
        public TipoCurso TipoCurso { get; set; }

        [Display(Name = "Escola:")]
        public int EscolaFK { get; set; }
        public Escola Escola { get; set; }
   
        public virtual ICollection<PotencialAluno> ListaAreaAluno { get; set; }
       

    }
}

