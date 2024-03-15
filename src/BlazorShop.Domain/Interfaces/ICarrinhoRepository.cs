using BlazorShop.Domain.Entities;

namespace BlazorShop.Domain.Interfaces;

public interface ICarrinhoRepository : IBaseRepository
{
    Task<bool> Adicionar(Carrinho Carrinho);
    Task<bool> Atualizar(Carrinho Carrinho);
    Task<Carrinho> ObterPorCodigo(int codigo);
    Task<Carrinho> ObterPorDescricao(string descricao);
    Task<IEnumerable<dadosCarrinhoCompras>> ObterTodosAsync(filtroCarrinho filtro);
}
