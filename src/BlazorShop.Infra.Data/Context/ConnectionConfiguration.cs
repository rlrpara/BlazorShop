using System.Data;

namespace BlazorShop.Infra.Data.Context;

public class ConnectionConfiguration
{
    #region [Private Properties]
    private readonly ParametrosConexao _parametrosConexao;
    #endregion

    #region [Métodos Privados]
    private IDbConnection? Inicia(IDbConnection? conexao)
    {
        try
        {
            if (conexao != null)
            {
                if (conexao.State == ConnectionState.Open) conexao.Close();
                if (conexao.State == ConnectionState.Closed) conexao.Open();
            }

            return conexao;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region [Constructor]
    public ConnectionConfiguration(ParametrosConexao parametrosConexao) => _parametrosConexao = parametrosConexao;
    #endregion

    #region Métodos Públicos
    public IDbConnection? AbrirConexao() => Inicia(new DeafultSqlConnectionFactory(_parametrosConexao).Conexao());
    #endregion
}
