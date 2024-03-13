using BlazorShop.Domain.Interfaces;
using BlazorShop.Service.Interface;

namespace BlazorShop.Service.Services;

public class BaseService : IBaseService
{
    #region [Propriedades Privadas]
    protected readonly IBaseRepository _baseRepository;
    #endregion

    #region [Construtor]
    public BaseService(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Métodos Públicos]
    public async Task<int> AdicionarAsync<T>(T entidade) where T : class
    {
        try
        {
            return await _baseRepository.Adicionar(entidade);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<int> AtualizarAsync<T>(int id, T entidade) where T : class
    {
        try
        {
            return await _baseRepository.AtualizarAsync(id, entidade);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<T> BuscarPorIdAsync<T>(int id) where T : class
    {
        try
        {
            return await _baseRepository.BuscarPorIdAsync<T>(id);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<T> BuscarPorQueryAsync<T>(string? query)
    {
        try
        {
            return await _baseRepository.BuscarPorQueryAsync<T>(query);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<T> BuscarPorQueryGeradorAsync<T>(string? sqlWhere = null) where T : class
    {
        try
        {
            return await _baseRepository.BuscarPorQueryGeradorAsync<T>(sqlWhere);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<IEnumerable<T>> BuscarTodosPorQueryAsync<T>(string? query = null) where T : class
    {
        try
        {
            return await _baseRepository.BuscarTodosPorQueryAsync<T>(query);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<IEnumerable<T>> BuscarTodosPorQueryGeradorAsync<T>(string? sqlWhere = null) where T : class
    {
        try
        {
            return await _baseRepository.BuscarTodosPorQueryGeradorAsync<T>(sqlWhere);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<int> ExcluirAsync<T>(int id) where T : class
    {
        try
        {
            return await _baseRepository.ExcluirAsync<T>(id);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<int?> ObterUltimoRegistroAsync<T>() where T : class
    {
        try
        {
            return await _baseRepository.ObterUltimoRegistroAsync<T>();
        }
        catch
        {
            return default(dynamic);
        }
    }
    public async Task<IEnumerable<T>> QueryAsync<T>(string? where) where T : class
    {
        try
        {
            return await _baseRepository.QueryAsync<T>(where);
        }
        catch
        {
            return default(dynamic);
        }
    }
    public Task<int> QueryCount<TEntity>(string? where) where TEntity : class
    {
        try
        {
            return _baseRepository.QueryCount<TEntity>(where);
        }
        catch
        {
            return default(dynamic);
        }
    }
    #endregion
}
