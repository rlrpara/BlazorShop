using BlazorShop.Domain.Entities;

namespace BlazorShop.Domain.Interfaces;

public interface ILoginRepository : IBaseRepository
{
    Task<Login> Logar(Login login);
}
