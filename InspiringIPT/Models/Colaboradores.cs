namespace InspiringIPT.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Colaboradores
    {

        [Key]
        public int ColaboradorID { get; set; }

        [Required]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O NIF tem de ter 9 caracteres Numéricos")]
        [Display(Name = "NIF: ")]
        public string NIF { get; set; }

        [Required]
        [Display(Name = "Nome: ")]
        public string NomeProprio { get; set; }

        [Required]
        [Display(Name = "Apelido: ")]
        public string Apelido { get; set; }
        [Required]
        [Display(Name = "Localidade: ")]
        public string Localidade { get; set; }
        [Required]
        [Display(Name = "Telemóvel: ")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O Contacto é composto por 9 caracteres Numéricos")]
        public string Contacto { get; set; }

        public string UserID { get; set; }
        
    }
}

