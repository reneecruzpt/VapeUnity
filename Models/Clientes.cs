using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("UserId")] // Adicione a coluna UserId
        [Display(Name = "UserId")]
        public string? UserId { get; set; } // Propriedade para armazenar o ID do usuário

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Apelido")]
        [Display(Name = "Apelido")]
        public string? Apelido { get; set; }

        [Column("Morada")]
        [Display(Name = "Morada")]
        public string? Morada { get; set; }

        [Column("Nif")]
        [Display(Name = "Nif")]
        public string? Nif { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

    }
}
