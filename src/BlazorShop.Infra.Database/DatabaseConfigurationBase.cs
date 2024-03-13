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
}
