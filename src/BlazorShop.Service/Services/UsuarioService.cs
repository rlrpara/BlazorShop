using AutoMapper;
using BlazorShop.CrossCuttin.Util.Criptografia;
using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using BlazorShop.Infra.Data.Repositories;
using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Services;

public class UsuarioService : BaseService, IUsuarioService
{
    #region [Propriedades Privadas]
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _repository;
    #endregion

    #region [Métodos Privado]
    #endregion

    #region [Consturtor]
    public UsuarioService(IBaseRepository baseRepository, IMapper mapper)
        : base(baseRepository)
    {
        _mapper = mapper;
        _repository = new UsuarioRepository(baseRepository);
    }
    #endregion

    #region [Métodos Públicos]
    public IEnumerable<UsuarioViewModel> ObterTodos()
        => _mapper.Map<IEnumerable<UsuarioViewModel>>(_repository.ObterTodosAsync().Result);
    public UsuarioViewModel ObterPorId(int codigo)
    {
        var usuario = _repository.ObterPorCodigo(codigo).Result;

        usuario.Senha = new EncryptDecrypt().Decrypt(usuario.Senha);

        return _mapper.Map<UsuarioViewModel>(usuario);
    }
    public bool Adicionar(UsuarioViewModel model)
    {
        model.Senha = !string.IsNullOrWhiteSpace(model.Senha) ? new EncryptDecrypt().Encrypt(model.Senha) : "";
        model.DataCadastro = DateTime.Now;
        model.DataAtualizacao = DateTime.Now;
        return _repository.Adicionar(_mapper.Map<Usuario>(model)).Result;
    }
    public bool Alterar(UsuarioViewModel model)
    {
        var sistema = ObterPorId(model.Codigo ?? 0);
        if (sistema is null)
            return false;

        if (!string.IsNullOrWhiteSpace(model.Senha) && new EncryptDecrypt().Encrypt(model.Senha) != sistema.Senha)
            model.Senha = new EncryptDecrypt().Encrypt(model.Senha);

        model.DataCadastro = sistema.DataCadastro;
        model.DataAtualizacao = DateTime.Now;
        return _repository.Atualizar(_mapper.Map<Usuario>(model)).Result;
    }
    public bool Deletar(int codigo)
    {
        var Usuario = ObterPorId(codigo);

        if (Usuario is null) return false;

        return _repository.Excluir<Usuario>(Usuario.Codigo ?? 0) > 0;
    }
    #endregion
}
