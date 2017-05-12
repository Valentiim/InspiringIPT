using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace InspiringIPT.Models
{
    public partial class PotencialAluno
    {
        public PotencialAluno(){
            // inicialização da lista de Consultas de um Aluno
            Cursos = new HashSet<Cursos>();
        }
        [Key]
        public int AlunoID { get; set; }
        public int CursoID { get; set; }
        public int AreaID { get; set; }
        public int TipoID { get; set; }

        [Required (ErrorMessage ="Introduzir o seu nome nome completo")]
        [Display(Name = "Nome Completo:")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Introduzir um e-mail válido")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }
        [Display(Name = "Concelho: ")]
        public string Concelho { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        //[Column(TypeName = "date")] // formata o tipo de dados na BD
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataNascimento { get; set; }
        [Required]
        [Display(Name = "Telemóvel:")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O Contacto é composto por 9 caracteres Numéricos")]
        public string Contacto { get; set; }
        [Display(Name = "Género:")]
        public string Genero { get; set; }
      /*  [Column(TypeName = "date")]*/ // formata o tipo de dados na BD
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataInscricao { get; set; }  // o '?' torna o preenchimento do atributo facultativo
        [Required]
        [Display(Name = "Habilitações Académicas:")]
        public string HabAcademicas { get; set; }

        public Cursos Curso { get; set; }
        [ForeignKey("Curso")]
        public int CursosFK { get; set; }

        public Areas Area { get; set; }
        [ForeignKey("Area")]
        public int AreasFK { get; set; }

        public TipoCurso TipoC { get; set; }
        [ForeignKey("TipoC")]
        public int TiposCursosFK { get; set; }


        public string UserID { get; set; }



        //herança
        public virtual ICollection<Cursos> Cursos { get; set; }
        //public virtual ICollection<OutrasAreas> OutrasAreas { get; set; }
        //public virtual ICollection<OutrosCursos> OutrosCursos { get; set; }
    }

}