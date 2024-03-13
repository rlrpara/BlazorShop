using BlazorShop.Domain.Entities;

namespace BlazorShop.Domain.Interfaces;

public interface IUsuarioRepository : IBaseRepository
{
    Task<bool> Adicionar(Usuario Usuario);
    Task<bool> Atualizar(Usuario Usuario);
    Task<Usuario> ObterPorCodigo(int codigo);
    Task<Usuario> ObterPorDescricao(string descricao);
    Task<IEnumerable<Usuario>> ObterTodosAsync();
}
