using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public class TipoCurso
    {
        public TipoCurso()
        {
            // vai representar os dados da tabela do Tipo de Curso

            // criar o construtor desta classe
            // e carregar a lista dos Cursos
            Cursos = new HashSet<Cursos>();
        }
        [Key]
        public int TipoID { get; set; }
        public string Tipo { get; set; }

        // especificar que um Tipo de Curso tem nenhum ou muitos Cursos
        public ICollection<Cursos> Cursos { get; set; }
        public ICollection<OutrosCursos> OutrosCursos { get; set; }
    }
}