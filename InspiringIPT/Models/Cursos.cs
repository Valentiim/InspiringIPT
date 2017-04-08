using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Alunos = new HashSet<Alunos>();
        }
        [Key]
        public int CursoID { get; set; }
        [Display(Name = "Tipo do Curso")]
        public string TipoCurso { get; set; }
        [Display(Name = "Curso")]
        public string Curso { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<Alunos> Alunos { get; set; }
       

    }
}

