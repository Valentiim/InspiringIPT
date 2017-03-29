using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Cursos
    {
        [Key]
        public int CursoID { get; set; }
        [Display(Name = "Tipo do Curso")]
        public string TipoCurso { get; set; }
        [Display(Name = "Curso")]
        public string Curso { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Upload de Foto")]
        public string ImagePath { get; set; }

    }
}

