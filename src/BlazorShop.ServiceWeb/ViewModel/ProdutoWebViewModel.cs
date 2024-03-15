namespace BlazorShop.ServiceWeb.ViewModel;

public class ProdutoWebViewModel
{
    public int? Codigo { get; set; }
    public int CodigoCategoria { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public decimal Preco { get; set; } = 0;
    public int Quantidade { get; set; } = 1;
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool? Ativo { get; set; }
}
