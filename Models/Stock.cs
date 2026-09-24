using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [ForeignKey("Produtos")]
        [Column("Produto")]
        [Display(Name = "Produto")]
        public int Produto { get; set; }
        public virtual Produtos Produtos { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Column("Fornecedor")]
        [Display(Name = "Fornecedor")]
        [ForeignKey("Fornecedores")]
        public int Fornecedor { get; set; }
        public virtual Fornecedores Fornecedores { get; set; }
    }
}
