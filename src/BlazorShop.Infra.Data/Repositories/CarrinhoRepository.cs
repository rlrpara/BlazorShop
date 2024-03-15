using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using System.Text;

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
    public async Task<IEnumerable<dadosCarrinhoCompras>> ObterTodosAsync(filtroCarrinho filtro)
    {
        var sqlPesquisa = new StringBuilder();

        sqlPesquisa.AppendLine($"SELECT carrinho.id as CodigoCarrinho,");
        sqlPesquisa.AppendLine($"       categoria.id as CodigoCategoria,");
        sqlPesquisa.AppendLine($"       categoria.nome as NomeCategoria,");
        sqlPesquisa.AppendLine($"       produto.id as CodigoProduto,");
        sqlPesquisa.AppendLine($"       produto.nome as NomeProduto,");
        sqlPesquisa.AppendLine($"       produto.descricao as DescricaoProduto,");
        sqlPesquisa.AppendLine($"       carrinho_item.quantidade as Quantidade,");
        sqlPesquisa.AppendLine($"       produto.preco as ValorUnitario,");
        sqlPesquisa.AppendLine($"       (carrinho_item.quantidade * produto.preco) as ValorTotal");
        sqlPesquisa.AppendLine($"  FROM carrinho_item");
        sqlPesquisa.AppendLine($"  JOIN carrinho  ON carrinho.id = carrinho_item.id_carrinho");
        sqlPesquisa.AppendLine($"  JOIN produto   ON produto.id = carrinho_item.id_produto");
        sqlPesquisa.AppendLine($"  JOIN categoria ON categoria.id = produto.id_categoria");
        if(filtro.CodigoCarrinho > 0)
            sqlPesquisa.AppendLine($" where carrinho.id = {filtro.CodigoCarrinho}");

        return await _baseRepository.BuscarTodosPorQueryAsync<dadosCarrinhoCompras>(sqlPesquisa.ToString());
    }
    public async Task<bool> Adicionar(Carrinho Carrinho)
        => await _baseRepository.Adicionar(Carrinho) > 0;
    public async Task<bool> Atualizar(Carrinho Carrinho)
        => await _baseRepository.AtualizarAsync(Carrinho.Codigo ?? 0, Carrinho) > 0;
    #endregion
}
