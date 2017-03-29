using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public class Lista
    {
        [Display(Name = "Tipo")]
        public string Curso { get; set; }
        [Display(Name = "Aluno")]
        public string Nome { get; set; }
        
    }
}