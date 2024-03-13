namespace BlazorShop.Service.ViewModel;

public class UsuarioAuthenticateResponseModel
{
    #region [Propriedades Privadas]
    public LoginViewModel Login { get; set; }
    public string Token { get; set; }
    #endregion

    #region [Construtor]
    public UsuarioAuthenticateResponseModel(LoginViewModel login, string token)
    {
        Login = login;
        Token = token;
    }
    #endregion
}
