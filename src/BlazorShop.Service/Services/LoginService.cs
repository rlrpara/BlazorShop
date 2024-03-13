using AutoMapper;
using BlazorShop.CrossCuttin.Util.Criptografia;
using BlazorShop.CrossCutting.Auth;
using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using BlazorShop.Infra.Data.Repositories;
using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Services;

public class LoginService : BaseService, ILoginService
{
    #region [Private Properties]
    private readonly IMapper _mapper;
    private readonly ILoginRepository _repository;
    #endregion

    #region [Private methods]
    private LoginViewModel ObterLogin(UsuarioAuthenticateRequestViewModel login) => new()
    {
        Email = login.Email,
        Senha = login.Senha
    };
    #endregion

    #region [Constructor]
    public LoginService(IBaseRepository baseRepository, IMapper mapper) : base(baseRepository)
    {
        _mapper = mapper;
        _repository = new LoginRepository(baseRepository);
    }
    #endregion

    #region [Public methods]
    public dynamic? Authenticate(UsuarioAuthenticateRequestViewModel login)
    {
        login.Senha = new EncryptDecrypt().Encrypt(login.Senha);

        var usuario = _repository.Logar(_mapper.Map<Login>(ObterLogin(login))).Result;

        if (usuario is null || !usuario.Ativo)
            return null;

        return new UsuarioAuthenticateResponseModel(_mapper.Map<LoginViewModel>(usuario), TokenService.GenerateToken(usuario));
    }

    #endregion
}
