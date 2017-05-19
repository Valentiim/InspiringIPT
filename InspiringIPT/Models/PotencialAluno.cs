using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspiringIPT.Models
{
    public partial class PotencialAluno
    {
        public PotencialAluno(){

            ListaCursosAreas = new HashSet<Cursos>();
            ListaAreas_Outras = new HashSet<OutrasAreas>();
            ListaCursos_Outros = new HashSet<OutrosCursos>();
        }
        [Key]
        public int AlunoID { get; set; }
        public int CursoID { get; set; }
        public int AreaID { get; set; }
        public int TipoID { get; set; }

        [Required (ErrorMessage ="Introduzir o seu nome completo")]
        //[RegularExpression("[A-ZÉÓÁÍÂ][a-záéíóúàèìòù]+(( [ed][aeo]?(s)?)?[ -'][A-ZÉÓÁÍÂ][a-záéíóúàèìòù]+){1, 4}")]
        [Display(Name = "Nome Completo:")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Introduzir um e-mail válido")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Concelho: ")]
        public string Concelho { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [Column(TypeName = "date")] // formata o tipo de dados na BD
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; } // o '?' torna o preenchimento do atributo facultativo

        [Required]
        [Display(Name = "Telemóvel:")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O Contacto é composto por 9 caracteres Numéricos")]
        public string Contacto { get; set; }

        [Display(Name = "Género:")]
        public string Genero { get; set; }

        [Column(TypeName = "date")]// formata o tipo de dados na BD
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataInscricao { get; set; }  // o '?' torna o preenchimento do atributo facultativo

        [Required]
        [Display(Name = "Habilitações Académicas:")]
        public string HabAcademicas { get; set; }

        public Cursos Curso { get; set; }
        [ForeignKey("Curso")]
        [Display(Name = "Cursos:")]
        public int CursosFK { get; set; }

        public Areas Area { get; set; }
        [ForeignKey("Area")]
        [Display(Name = "Areas:")]
        public int AreasFK { get; set; }

        public TipoCurso TipoC { get; set; }
        [ForeignKey("TipoC")]
        [Display(Name = "Tipos de Cursos:")]
        public int TiposCursosFK { get; set; }

        //public string UserID { get; set; }

        //herança
        public virtual ICollection<Cursos> ListaCursosAreas { get; set; }//associados o objeto potencial aluno existe um objeto Curso
        public virtual ICollection<OutrasAreas> ListaAreas_Outras { get; set; } //associados o objeto potencial aluno existe um objeto outras areas
        public virtual ICollection<OutrosCursos> ListaCursos_Outros { get; set; } //associados o objeto potencial aluno existe um objeto outros cursos

    }

}