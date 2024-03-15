using BlazorShop.CrossCuttin.Util.Criptografia;
using BlazorShop.Domain.Entities;

namespace BlazorShop.Infra.Database;

public class DatabaseConfigurationBase
{
    public IEnumerable<Usuario> ObterUsuarioPadrao() =>
    [
        new()
        {
            Nome = "ADMIN",
            Email = "useradmin@blazorshop.com.br",
            Senha = new EncryptDecrypt().Encrypt("blazorshop784512"),
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Admin = true,
            Ativo = true,
        },
    ];
    public IEnumerable<Categoria> ObterCategoria() =>
    [
        new()
        {
            Nome = "Beleza",
            IconCSS = "fas fa-spa",
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Ativo = true
        },
        new()
        {
            Nome = "Alimentos",
            IconCSS = "fas fa-spa",
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Ativo = true
        }
    ];
    public IEnumerable<Produtos> ObterProdutos() =>
    [
        new Produtos()
        {
            Nome = "Glossier - Beleza Kit",
            Descricao = "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele.",
            ImagemUrl = "/imagens/beleza/beleza1.png",
            Preco = 100,
            Quantidade = 100,
            CodigoCategoria = 1,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Ativo = true
        },
        new Produtos()
        {
            Nome = "Coca-Cola",
            Descricao = "Descrição da coca-cola",
            ImagemUrl = "/imagens/beleza/coca-cola1.png",
            Preco = 7,
            Quantidade = 300,
            CodigoCategoria = 2,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Ativo = true
        }
    ];
    public IEnumerable<Carrinho> ObterCarrinho() =>
    [
        new Carrinho()
        {
            CodigoUsuario = 1,
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
        }
    ];
    public IEnumerable<CarrinhoItem> ObterCarrinhoItem() => new List<CarrinhoItem>()
    {
        new()
        {
            CodigoCarrinho = 1,
            CodigoProduto = 1,
            Quantidade = 1,
            Ativo = true,
        },
        new()
        {
            CodigoCarrinho = 1,
            CodigoProduto = 2,
            Quantidade = 5,
            Ativo = true,
        }
    };
}
