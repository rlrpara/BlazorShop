using System.Data;

namespace BlazorShop.Infra.Data.Interface;

public interface IConnectionFactory
{
    IDbConnection Conexao();
}
