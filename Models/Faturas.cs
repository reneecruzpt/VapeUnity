using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Faturas")]
    public class Faturas
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Id_Cliente")]
        [Display(Name = "Id_Cliente")]
        [ForeignKey("Cli")]
        public int Id_Cliente { get; set; }

        public virtual Clientes Cli { get; set; }

        [Column("Total")]
        [Display(Name = "Total")]
        public float? Total { get; set; }
    }
}
