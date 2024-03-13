namespace BlazorShop.Service.ViewModel;

public class CarrinhoItemViewModel
{
    public int? Codigo { get; set; }
    public int CodigoCarrinho { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; } = 1;
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool? Ativo { get; set; }
}
