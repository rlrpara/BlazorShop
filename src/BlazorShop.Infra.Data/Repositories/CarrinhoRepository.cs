using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;

namespace BlazorShop.Infra.Data.Repositories;

public class CarrinhoRepository : BaseRepository, ICarrinhoRepository
{
    #region [Propriedades Privadas]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Métodos Privados]
    #endregion

    #region [Construtor]
    public CarrinhoRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Métodos Públicos]
    public async Task<Carrinho> ObterPorCodigo(int codigo)
        => await _baseRepository.BuscarPorIdAsync<Carrinho>(codigo);
    public async Task<Carrinho> ObterPorDescricao(string descricao)
        => await _baseRepository.BuscarPorQueryGeradorAsync<Carrinho>($"DESCRICAO = '{descricao}'");
    public async Task<IEnumerable<Carrinho>> ObterTodosAsync()
        => await _baseRepository.BuscarTodosPorQueryGeradorAsync<Carrinho>();
    public async Task<bool> Adicionar(Carrinho Carrinho)
        => await _baseRepository.Adicionar(Carrinho) > 0;
    public async Task<bool> Atualizar(Carrinho Carrinho)
        => await _baseRepository.AtualizarAsync(Carrinho.Codigo ?? 0, Carrinho) > 0;
    #endregion
}
