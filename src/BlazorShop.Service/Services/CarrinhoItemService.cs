using AutoMapper;
using BlazorShop.CrossCuttin.Util.Criptografia;
using BlazorShop.Domain.Entities;
using BlazorShop.Domain.Interfaces;
using BlazorShop.Infra.Data.Repositories;
using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.Services;

public class CarrinhoItemService : BaseService, ICarrinhoItemService
{
    #region [Private Properties]
    private readonly IMapper _mapper;
    private readonly ICarrinhoItemReposytory _carrinhoItemReposytory;
    #endregion
    
    #region [Constructor]
    public CarrinhoItemService(IBaseRepository baseRepository, IMapper mapper) : base(baseRepository)
    {
        _mapper = mapper;
        _carrinhoItemReposytory = new CarrinhoItemRepository(baseRepository);
    }
    #endregion

    #region [Public Methods]
    public IEnumerable<CarrinhoItemViewModel> ObterTodos()
        => _mapper.Map<IEnumerable<CarrinhoItemViewModel>>(_carrinhoItemReposytory.ObterTodosAsync().Result);
    public CarrinhoItemViewModel ObterPorId(int codigo)
        => _mapper.Map<CarrinhoItemViewModel>(_carrinhoItemReposytory.ObterPorCodigo(codigo).Result);
    public bool Adicionar(CarrinhoItemViewModel model)
    {
        model.DataCadastro = DateTime.Now;
        model.DataAtualizacao = DateTime.Now;
        return _carrinhoItemReposytory.Adicionar(_mapper.Map<CarrinhoItem>(model)).Result;
    }
    public bool Alterar(CarrinhoItemViewModel model)
    {
        var sistema = ObterPorId(model.Codigo ?? 0);
        if (sistema is null)
            return false;

        model.DataCadastro = sistema.DataCadastro;
        model.DataAtualizacao = DateTime.Now;
        return _carrinhoItemReposytory.Atualizar(_mapper.Map<CarrinhoItem>(model)).Result;
    }
    public bool Deletar(int codigo)
    {
        var CarrinhoItem = ObterPorId(codigo);

        if (CarrinhoItem is null) return false;

        return _carrinhoItemReposytory.Excluir<CarrinhoItem>(CarrinhoItem.Codigo ?? 0) > 0;
    }
    #endregion
}
