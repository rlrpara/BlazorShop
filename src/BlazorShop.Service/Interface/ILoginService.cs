using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Interface;

public interface ILoginService : IBaseService
{
    dynamic? Authenticate(UsuarioAuthenticateRequestViewModel login);
}
