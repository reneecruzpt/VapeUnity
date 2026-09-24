using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VapeUnity.Models;

namespace VapeUnity.Controllers
{
    public class CarrinhoController : Controller
    {
        private static readonly List<Produtos> carrinho = new List<Produtos>();

        [HttpPost]
        public IActionResult AdicionarAoCarrinho(int produtoId, int quantidade, string produtoNome, string produtoPreco)
        {
            // Verificar se o produto já existe no carrinho
            var produtoExistente = carrinho.FirstOrDefault(p => p.Id == produtoId);

            if (produtoExistente != null)
            {
                // Atualizar a quantidade do produto existente
                produtoExistente.Quantidade += quantidade;
            }
            else
            {
                // Obter o produto do banco de dados com base no produtoId
                var produto = ObterProdutoPorId(produtoId, produtoNome, produtoPreco);

                // Verificar se o produto existe e se a quantidade é válida
                if (produto != null && quantidade > 0)
                {
                    // Definir a quantidade do produto no carrinho
                    produto.Quantidade = quantidade;

                    // Adicionar o produto ao carrinho
                    carrinho.Add(produto);
                }
            }

            // Redirecionar de volta para a página do carrinho
            return RedirectToAction("Carrinho");
        }

        [HttpPost]
        public IActionResult RemoverDoCarrinho(int produtoId)
        {
            var produtoExistente = carrinho.FirstOrDefault(p => p.Id == produtoId);
            if (produtoExistente != null)
            {
                carrinho.Remove(produtoExistente);
            }

            return RedirectToAction("Carrinho");
        }

        [HttpPost]
        public IActionResult AtualizarQuantidade(int produtoId, int quantidade)
        {
            var produtoExistente = carrinho.FirstOrDefault(p => p.Id == produtoId);
            if (produtoExistente != null)
            {
                produtoExistente.Quantidade = quantidade;
            }

            return RedirectToAction("Carrinho");
        }

        public IActionResult Carrinho()
        {
            // Calcular o preço total no lado do servidor
            decimal precoTotal = carrinho.Sum(p => p.Quantidade * decimal.Parse(p.Preco.Replace(".", ",")));

            // Converter o preço total para uma string formatada
            string precoTotalString = precoTotal.ToString("C"); // Formato de moeda

            // Passar a string do preço total para a view
            ViewBag.PrecoTotal = precoTotalString;

            return View(carrinho);
        }


        // Método auxiliar para obter um produto do banco de dados pelo seu ID
        private Produtos ObterProdutoPorId(int produtoId, string produtoNome, string produtoPreco)
        {
            // Lógica para buscar o produto no banco de dados ou em uma lista em memória
            // Substitua a lógica abaixo pela lógica de busca correta do produto
            return new Produtos
            {
                Id = produtoId,
                Nome = produtoNome,
                Descricao = "Descrição do Produto",
                Preco = produtoPreco,
                Categoria = "Categoria do Produto",
                Disponibilidade = true,
                CaminhoImagens = "/caminho/imagem.jpg"
            };
        }

        [HttpPost]
        public IActionResult FinalizarCompra(string formaPagamento)
        {
            // Lógica para processar o pagamento e finalizar a compra
            // Aqui você pode adicionar integrações com APIs de pagamento ou outras lógicas necessárias

            // Limpar o carrinho após finalizar a compra
            carrinho.Clear();

            // Redirecionar para uma página de confirmação ou para a página inicial, por exemplo
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult FinalizarCompraCheckout(CheckoutViewModel checkout)
        {
            // Mapear os dados do checkout para o modelo Encomendas
            var encomenda = new Encomendas
            {
                ClienteId = checkout.ClienteId,
                MoradaEntrega = checkout.MoradaEntrega,
                ValorTotal = checkout.ValorTotal,
                PagamentoRealizado = false,
                Status = "Pendente",
                DataEncomenda = DateTime.Now,
                Observacoes = checkout.Observacoes,
                MetodoPagamento = checkout.MetodoPagamento,
                QuantidadeItens = checkout.Itens.Count,
                ValorDesconto = checkout.ValorDesconto,
                ValorEnvio = checkout.ValorEnvio
            };

            // Mapear os dados dos itens do checkout para o modelo ItemEncomenda
            encomenda.Itens = new List<ItemEncomenda>();
            foreach (var produto in checkout.Itens)
            {
                var itemEncomenda = new ItemEncomenda
                {
                    NomeProduto = produto.NomeProduto,
                    Quantidade = produto.Quantidade,
                    PrecoUnitario = produto.PrecoUnitario
                };

                encomenda.Itens.Add(itemEncomenda);
            }

            // Salvar a encomenda no banco de dados (exemplo)
            // dbContext.Encomendas.Add(encomenda);
            // dbContext.SaveChanges();

            // Definir o prazo de pagamento de 24 horas
            DateTime prazoPagamento = DateTime.Now.AddHours(24);

            // Redirecionar para uma página de sucesso com as informações da compra
            return RedirectToAction("CompraFinalizada", new { prazoPagamento });
        }

        [HttpGet]
        public IActionResult CompraFinalizada(DateTime prazoPagamento)
        {
            // Exibir a página de sucesso com as informações da compra, incluindo o prazo de pagamento
            ViewBag.PrazoPagamento = prazoPagamento;

            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult FastCheckout()
        {
            return View();
        }
    }
}
