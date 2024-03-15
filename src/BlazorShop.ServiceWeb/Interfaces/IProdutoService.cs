using BlazorShop.ServiceWeb.ViewModel;

namespace BlazorShop.ServiceWeb.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoWebViewModel>> ObterTodos();
}
