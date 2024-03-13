using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Interface;

public interface ICarrinhoService : IBaseService
{
    IEnumerable<CarrinhoViewModel> ObterTodos();
    CarrinhoViewModel ObterPorId(int codigo);
    bool Adicionar(CarrinhoViewModel model);
    bool Alterar(CarrinhoViewModel model);
    bool Deletar(int codigo);
}
