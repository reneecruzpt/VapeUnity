using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("DadosTemporarios")]
    public class DadosTemporarios
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Email")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Column("Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

    }
}
