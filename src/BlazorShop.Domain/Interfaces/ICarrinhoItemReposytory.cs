using BlazorShop.Domain.Entities;

namespace BlazorShop.Domain.Interfaces;

public interface ICarrinhoItemReposytory : IBaseRepository
{
    Task<CarrinhoItem> ObterPorCodigo(int codigo);
    Task<CarrinhoItem> ObterPorDescricao(string descricao);
    Task<IEnumerable<CarrinhoItem>> ObterTodosAsync();
    Task<bool> Adicionar(CarrinhoItem CarrinhoItem);
    Task<bool> Atualizar(CarrinhoItem CarrinhoItem);
}
