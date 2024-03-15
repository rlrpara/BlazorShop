using BlazorShop.Domain.Interfaces;
using BlazorShop.Infra.Data.Repositories;
using BlazorShop.Service.Interface;
using BlazorShop.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorShop.CrossCutting.Iot;

public static class NativeInjector
{
    public static void RegisterServices(this IServiceCollection services)
    {

        #region Services
        services.AddTransient<IBaseService, BaseService>();
        services.AddTransient<IUsuarioService, UsuarioService>();
        services.AddTransient<ILoginService, LoginService>();
        services.AddTransient<ICarrinhoService, CarrinhoService>();
        #endregion

        #region Repositories
        services.AddTransient<IBaseRepository, BaseRepository>();
        services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
        services.AddTransient<ICarrinhoItemReposytory, CarrinhoItemRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IProdutoRepository, ProdutoRepository>();
        services.AddTransient<ILoginRepository, LoginRepository>();
        services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
        #endregion
    }
}
