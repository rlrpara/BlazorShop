using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Interface;

public interface ICarrinhoItemService : IBaseService
{
    IEnumerable<CarrinhoItemViewModel> ObterTodos();
    CarrinhoItemViewModel ObterPorId(int codigo);
    bool Adicionar(CarrinhoItemViewModel model);
    bool Alterar(CarrinhoItemViewModel model);
    bool Deletar(int codigo);
}
