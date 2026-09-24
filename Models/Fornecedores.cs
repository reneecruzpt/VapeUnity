using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Fornecedores")]
    public class Fornecedores
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Morada")]
        [Display(Name = "Morada")]
        public string? Morada { get; set; }

        [Column("Telemovel")]
        [Display(Name = "Telemovel")]
        public string? Telemovel { get; set; }

        [Column("Nif")]
        [Display(Name = "Nif")]
        public string? Nif { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}
