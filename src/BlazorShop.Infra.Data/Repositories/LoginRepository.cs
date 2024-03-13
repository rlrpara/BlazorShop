using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using System.Text;

namespace BlazorShop.Infra.Data.Repositories;

public class LoginRepository : BaseRepository, ILoginRepository
{
    #region [Private properties]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Constructor]
    public LoginRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Publick methods]
    public async Task<Login> Logar(Login login)
    {
        var sqlPesquisa = new StringBuilder();

        sqlPesquisa.AppendLine($"EMAIL = '{login.Email}' AND SENHA = '{login.Senha}'");

        return await _baseRepository.BuscarPorQueryGeradorAsync<Login>(sqlPesquisa.ToString());
    }
    #endregion
}
