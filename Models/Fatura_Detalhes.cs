using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Fatura_Detalhes")]
    public class Fatura_Detalhes

    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Id_Fatura")]
        [Display(Name = "Id_Fatura")]
        [ForeignKey("Fat")]
        public int Id_Fatura { get; set; }

        public virtual Faturas Fat { get; set; }

        [Column("Id_Produto")]
        [Display(Name = "Id_Produto")]
        [ForeignKey("Prod")]
        public int Id_Produto { get; set; }

        public virtual Produtos Prod { get; set; }

        [Column("Preco")]
        [Display(Name = "Preco")]
        public float? Preco { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Column("Total")]
        [Display(Name = "Total")]
        public float? Total { get; set; }

    }
}
