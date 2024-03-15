namespace BlazorShop.Domain.Entities;

public class dadosCarrinhoCompras
{
    public int CodigoCarrinho { get; set; }
    public int CodigoCategoria { get; set; }
    public string? NomeCategoria { get; set; }
    public int CodigoProduto { get; set; }
    public string? NomeProduto { get; set; }
    public string? DescricaoProduto { get; set; }
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
}
