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

        public DateTime DataInscricao { get; set; }

        public int aluno { get; set; }
       
        public virtual Alunos Alunos { get; set; }
       
        public virtual Cursos Cursos { get; set; }

    }
}