using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace InspiringIPT.Models
{
    public partial class Alunos
    {
        public Alunos(){
            Inscricao = new HashSet<Inscricao>();
        }
        [Key]
        public int AlunoID { get; set; }
        [Required (ErrorMessage ="Introduzir o seu nome nome completo")]
        [Display(Name = "Nome Completo:")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Introduzir o seu concelho")]
        [Display(Name = "Concelho: ")]
        public string Concelho { get; set; }
        [Required(ErrorMessage = "Introduzir um e-mail válido")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telemóvel:")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O Contacto é composto por 9 caracteres Numéricos")]
        public string Contacto { get; set; }
        [Required]
        [Display(Name = "Curso:")]
        public string Curso { get; set; }
        [Required]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataNascimento { get; set; }
        [Required]
        [Display(Name = "Hab. Académicas:")]
        public string HabAcademicas { get; set; }
        [Display(Name = "Informações sobre Curso:")]
        public string InforCursos { get; set; }
        [Display(Name = "Áreas de interesse:")]
        public string AreasInteresse { get; set; }
        [Display(Name = "Obs:")]
        public string Observacoes { get; set; }
        public string UserID { get; set; }

        public class AlunoDBContext : DbContext
        {
            public DbSet<Alunos> Alunos { get; set; }
        }
        //herança
        public virtual ICollection<Inscricao> Inscricao { get; set; }

    }

}