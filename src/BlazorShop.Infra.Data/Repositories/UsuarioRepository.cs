using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;

namespace BlazorShop.Infra.Data.Repositories;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    #region [Propriedades Privadas]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Métodos Privados]
    #endregion

    #region [Construtor]
    public UsuarioRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Métodos Públicos]
    public async Task<Usuario> ObterPorCodigo(int codigo)
        => await _baseRepository.BuscarPorIdAsync<Usuario>(codigo);
    public async Task<Usuario> ObterPorDescricao(string descricao)
        => await _baseRepository.BuscarPorQueryGeradorAsync<Usuario>($"DESCRICAO = '{descricao}'");
    public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        => await _baseRepository.BuscarTodosPorQueryGeradorAsync<Usuario>();
    public async Task<bool> Adicionar(Usuario Usuario)
        => await _baseRepository.Adicionar(Usuario) > 0;
    public async Task<bool> Atualizar(Usuario Usuario)
        => await _baseRepository.AtualizarAsync(Usuario.Codigo ?? 0, Usuario) > 0;
    #endregion
}
