using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Interface;

public interface ICarrinhoService : IBaseService
{
    IEnumerable<CarrinhoComprasViewModel> ObterTodos(filtroCarrinhoViewModel filtro);
    CarrinhoViewModel ObterPorId(int codigo);
    bool Adicionar(CarrinhoViewModel model);
    bool Alterar(CarrinhoViewModel model);
    bool Deletar(int codigo);
}
