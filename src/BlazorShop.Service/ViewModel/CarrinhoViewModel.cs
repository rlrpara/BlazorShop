namespace BlazorShop.Service.ViewModel;

public class CarrinhoViewModel
{
    public CarrinhoViewModel()
    {
        ListaCarrinhoItem = [];
    }

    public int? Codigo { get; set; }
    public int? CodigoUsuario { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool Ativo { get; set; }

    public List<CarrinhoItemViewModel> ListaCarrinhoItem { get; set; }
}
