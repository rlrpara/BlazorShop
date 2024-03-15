using BlazorShop.ServiceWeb.Interfaces;
using BlazorShop.ServiceWeb.ViewModel;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace BlazorShop.ServiceWeb.Services;

public class ProdutoService : IProdutoService
{
    private HttpClient _httpClient;
    private ILogger _logger;

    public ProdutoService(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task<IEnumerable<ProdutoWebViewModel>> ObterTodos()
    {
        try
        {
            var produtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoWebViewModel>>("api/produtos");

            return produtos;
        }
        catch (Exception ex)
        {
            _logger.LogError("Erro ao acessar produto: api/produtos");
            throw;
        }
    }
}
