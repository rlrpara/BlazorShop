using AutoMapper;
using BlazorShop.CrossCuttin.Util.Criptografia;
using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using BlazorShop.Infra.Data.Repositories;
using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Services;

public class CarrinhoService : BaseService, ICarrinhoService
{
    #region [Private Properties]
    private readonly IMapper _mapper;
    private readonly ICarrinhoRepository _carrinhoRepository;
    #endregion

    #region [Constructor]
    public CarrinhoService(IBaseRepository baseRepository, IMapper mapper) : base(baseRepository)
    {
        _mapper = mapper;
        _carrinhoRepository = new CarrinhoRepository(baseRepository);
    }
    #endregion

    #region [Public Methods]
    public IEnumerable<CarrinhoComprasViewModel> ObterTodos(filtroCarrinhoViewModel filtro)
        => _mapper.Map<IEnumerable<CarrinhoComprasViewModel>>(_carrinhoRepository.ObterTodosAsync(_mapper.Map<filtroCarrinho>(filtro)).Result);
    public CarrinhoViewModel ObterPorId(int codigoCarrinho)
        => _mapper.Map<CarrinhoViewModel>(_carrinhoRepository.ObterPorCodigo(codigoCarrinho).Result);
    public bool Adicionar(CarrinhoViewModel model)
    {
        model.DataCadastro = DateTime.Now;
        model.DataAtualizacao = DateTime.Now;
        return _carrinhoRepository.Adicionar(_mapper.Map<Carrinho>(model)).Result;
    }
    public bool Alterar(CarrinhoViewModel model)
    {
        var sistema = ObterPorId(model.Codigo ?? 0);
        if (sistema is null)
            return false;

        model.DataCadastro = sistema.DataCadastro;
        model.DataAtualizacao = DateTime.Now;
        return _carrinhoRepository.Atualizar(_mapper.Map<Carrinho>(model)).Result;
    }
    public bool Deletar(int codigo)
    {
        var Usuario = ObterPorId(codigo);

        if (Usuario is null) return false;

        return _carrinhoRepository.Excluir<Usuario>(Usuario.Codigo ?? 0) > 0;
    }
    #endregion
}
