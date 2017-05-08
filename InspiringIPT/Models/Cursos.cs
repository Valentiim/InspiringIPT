using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Cursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursos()
        {
            Inscricao = new HashSet<Inscricao>();
        }
        [Key]
        public int CursoID { get; set; }
        [Display(Name = "Tipo do Curso")]
        public string TipoCurso { get; set; }
        [Display(Name = "Curso")]
        public string Curso { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual ICollection<Inscricao> Inscricao { get; set; }
       

    }
}

