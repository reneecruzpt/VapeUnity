namespace VapeUnity.Models
{
    public class CheckoutViewModel
    {
        // Dados da encomenda
        public int? ClienteId { get; set; }
        public string? MoradaEntrega { get; set; }
        public List<ItemEncomenda>? Itens { get; set; }
        public decimal? ValorTotal { get; set; }
        public string? MetodoPagamento { get; set; }
        public string? Observacoes { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorEnvio { get; set; }
        public int? Quantidade { get; set; }
        // Dados da fatura
        public int? Id_Cliente { get; set; }
        public float? Total { get; set; }
    }
}
