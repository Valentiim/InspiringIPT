using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public class ListaAlunos
    {
        public int AlunoID { get; set; }
        [Display(Name = "Aluno")]
        public string Nome { get; set; }
        [Display(Name = "E-Mail")]
        public string EMAIL { get; set; }
        [Display(Name = "Concelho")]
        public string Concelho { get; set; }
        [Display(Name = "Data de Nascimento")]
        public string Data_Nascimento { get; set; }
        [Display(Name = "Contacto")]
        public string Contacto { get; set; }
        [Display(Name = "Género")]
        public string Genero { get; set; }
        [Display(Name = "Data da Inscrição")]
        public string Data_Inscricao { get; set; }
        [Display(Name = "Habilitações Académicas")]
        public string Habilitacoes { get; set; }
        
     
    }
}