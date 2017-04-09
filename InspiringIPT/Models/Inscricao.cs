using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Inscricao
    {
        [Key]
        public int InscricaoID { get; set; }
        [Display(Name = "Data de Inscrição")]
        [Column(TypeName = "date")]
        public DateTime DataInscricao { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoFK { get; set; }
        public virtual Alunos Alunos { get; set; }

        [Display(Name = "Curso")]
        public int CursoFK { get; set; }
        public virtual Cursos Cursos { get; set; }

    }
}