using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }

        [Display(Name = "Preço")]
        [RegularExpression(@"^\d{1,3}(\.\d{3})*(,\d{2})?$", ErrorMessage = "O campo Preço deve ser um número válido.")]
        public string? Preco { get; set; }


        [Column("Categoria")]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }

        [Column("Disponibilidade")]
        [Display(Name = "Disponibilidade")]
        public bool Disponibilidade { get; set; }

        [Column("CaminhoImagens")]
        [Display(Name = "CaminhoImagens")]
        public string? CaminhoImagens { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

    }
}
