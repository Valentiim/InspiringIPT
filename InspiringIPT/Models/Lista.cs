using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public class Lista
    {
        [Display(Name = "Id Inscrição")]
        public int InscricaoID { get; set; }

        [Display(Name = "Aluno")]
        public string Nome { get; set; }

        [Display(Name = "Curso")]
        public string Curso { get; set; }

        [Display(Name = "Data de Inscrição")]
        public DateTime DataInscri { get; set; }

        
       
       

    }
}