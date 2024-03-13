using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;

namespace BlazorShop.Infra.Data.Repositories;

public class CarrinhoItemRepository : BaseRepository, ICarrinhoItemReposytory
{
    #region [Propriedades Privadas]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Métodos Privados]
    #endregion

    #region [Construtor]
    public CarrinhoItemRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Métodos Públicos]
    public async Task<CarrinhoItem> ObterPorCodigo(int codigo)
        => await _baseRepository.BuscarPorIdAsync<CarrinhoItem>(codigo);
    public async Task<CarrinhoItem> ObterPorDescricao(string descricao)
        => await _baseRepository.BuscarPorQueryGeradorAsync<CarrinhoItem>($"DESCRICAO = '{descricao}'");
    public async Task<IEnumerable<CarrinhoItem>> ObterTodosAsync()
        => await _baseRepository.BuscarTodosPorQueryGeradorAsync<CarrinhoItem>();
    public async Task<bool> Adicionar(CarrinhoItem CarrinhoItem)
        => await _baseRepository.Adicionar(CarrinhoItem) > 0;
    public async Task<bool> Atualizar(CarrinhoItem CarrinhoItem)
        => await _baseRepository.AtualizarAsync(CarrinhoItem.Codigo ?? 0, CarrinhoItem) > 0;
    #endregion
}
