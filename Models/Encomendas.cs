using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VapeUnity.Models
{
    public class Encomendas
    {
        [Key]
        public int? Id { get; set; }

        [Column("ClienteId")]
        [Display(Name = "Cliente Id")]
        public int? ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Clientes? Cliente { get; set; }

        [Column("MoradaEntrega")]
        [Display(Name = "Morada de Entrega")]
        public string? MoradaEntrega { get; set; }

        [Column("Itens")]
        [Display(Name = "Itens da Encomenda")]
        public List<ItemEncomenda>? Itens { get; set; }

        [Column("ValorPorItem")]
        [Display(Name = "Valor por Item")]
        public decimal? ValorPorItem { get; set; }

        [Column("ValorTotal")]
        [Display(Name = "Valor Total")]
        public decimal? ValorTotal { get; set; }

        [Column("PagamentoRealizado")]
        [Display(Name = "Pagamento Realizado")]
        public bool? PagamentoRealizado { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Column("DataEncomenda")]
        [Display(Name = "Data da Encomenda")]
        public DateTime? DataEncomenda { get; set; }

        [Column("DataEntrega")]
        [Display(Name = "Data de Entrega")]
        public DateTime? DataEntrega { get; set; }

        [Column("Observacoes")]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [Column("EnderecoEntrega")]
        [Display(Name = "Endereço de Entrega")]
        public EnderecoEntrega? EnderecoEntrega { get; set; }

        [Column("MetodoPagamento")]
        [Display(Name = "Método de Pagamento")]
        public string? MetodoPagamento { get; set; }

        [Column("QuantidadeItens")]
        [Display(Name = "Quantidade de Itens")]
        public int? QuantidadeItens { get; set; }

        [Column("ValorDesconto")]
        [Display(Name = "Valor do Desconto")]
        public decimal? ValorDesconto { get; set; }

        [Column("ValorEnvio")]
        [Display(Name = "Valor do Envio")]
        public decimal? ValorEnvio { get; set; }

        [Column("InformacoesEntrega")]
        [Display(Name = "Informações de Entrega")]
        public InformacoesEntrega? InformacoesEntrega { get; set; }
    }

    public class ItemEncomenda
    {
        [Key]
        public int? Id { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Nome do Produto")]
        public string? NomeProduto { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Column("PrecoUnitario")]
        [Display(Name = "Preço Unitário")]
        public decimal? PrecoUnitario { get; set; }
    }

    public class EnderecoEntrega
    {
        [Key]
        public int? Id { get; set; }

        public int? ClienteId { get; set; }

        [Column("Rua")]
        [Display(Name = "Rua")]
        public string? Rua { get; set; }

        [Column("Numero")]
        [Display(Name = "Número")]
        public string? Numero { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Column("Pais")]
        [Display(Name = "País")]
        public string? Pais { get; set; }
    }

    public class InformacoesEntrega
    {
        [Key]
        public int? Id { get; set; }

        public int? ClienteId { get; set; }

        [Column("Transportadora")]
        [Display(Name = "Transportadora")]
        public string? Transportadora { get; set; }

        [Column("NumeroRastreamento")]
        [Display(Name = "Número de Rastreamento")]
        public string? NumeroRastreamento { get; set; }
    }
}
