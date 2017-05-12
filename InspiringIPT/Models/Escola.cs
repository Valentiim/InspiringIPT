using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspiringIPT.Models
{
    public partial class Escola
    {
        public Escola()
        {
            // vai representar os dados da tabela da Escola

            // criar o construtor desta classe
            // e carregar a lista dos Cursos
            Cursos = new HashSet<Cursos>();
        }
        [Key]
        public int EscolaID { get; set; }
        public string NomeEscola { get; set; }
        public string SiglaEscola { get; set; }

        // especificar que uma Escola tem um ou muitos Cursos
        public ICollection<Cursos> Cursos { get; set; }

    }
}