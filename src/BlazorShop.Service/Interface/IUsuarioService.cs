using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Interface;

public interface IUsuarioService : IBaseService
{
    IEnumerable<UsuarioViewModel> ObterTodos();
    UsuarioViewModel ObterPorId(int codigo);
    bool Adicionar(UsuarioViewModel model);
    bool Alterar(UsuarioViewModel model);
    bool Deletar(int codigo);
}
