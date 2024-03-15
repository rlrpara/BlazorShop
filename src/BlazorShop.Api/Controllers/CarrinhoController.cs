using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrinhoController : ControllerBase
{
    #region [Propriedades Privadas]
    private readonly ICarrinhoService _service;
    #endregion

    #region [Métodos Privados]
    #endregion

    #region [Construtor]
    public CarrinhoController(ICarrinhoService CarrinhoService) => _service = CarrinhoService;
    #endregion

    #region [Métodos Públicos]
    /// <summary>
    /// Obtem todos os registros
    /// </summary>
    /// <response code="200">Retorna com sucesso os dados</response>
    /// <response code="401">Retorna requisição não autorizada</response>
    /// <response code="404">Retorna requisição sem dados</response>
    [HttpPost("ObterTodos")]
    public IActionResult GetObterTodos(filtroCarrinhoViewModel filtro)
    {
        var resultado = _service.ObterTodos(filtro);

        if(resultado.Count() == 0)
            return NotFound();

        return Ok(resultado);
    }

    /// <summary>
    /// Obtem um registro baseado no ID do mesmo
    /// </summary>
    /// <param name="id">Filtro ID </param>
    /// <response code="200">Retorna com sucesso o registro</response>
    /// <response code="401">Retorna requisição não autorizada</response>
    [HttpGet("{id}")]
    public IActionResult GetObterPorId(int id)
        => Ok(_service.ObterPorId(id));

    /// <summary>
    /// Insere um novo registro
    /// </summary>
    /// <remarks>
    /// Campos obrigatórios:
    ///
    ///     {
    ///         "nome": "Novo Carrinho",
    ///         "email": "email@gmail.com",
    ///         "senha": "senhateste122355",
    ///         "admin": false,
    ///         "dataCadastro": "2023-09-08T14:42:43.473Z",
    ///         "dataAtualizacao": "2023-09-08T14:42:43.473Z",
    ///         "ativo": true
    ///     }
    ///
    /// </remarks>
    /// <param name="model">Dados disponíveis para o usuário da API preencher</param>
    /// <response code="201">Registro criado com sucesso!</response>
    /// <response code="400">Retorna requisição mal sucedida com feedback</response>
    /// <response code="401">Retorna requisição não autorizada</response>
    [HttpPost()]
    [AllowAnonymous]
    public IActionResult Adicionar([FromBody] CarrinhoViewModel model)
    {
        if (model.Codigo != null && model.Codigo != 0)
            return BadRequest(new
            {
                Mensagem = "Envio de campo não permitido para criar um novo registro!",
                Dica = "Remova o campo Codigo do corpo da requisição ou iguale o valor dele a 0 ou null."
            });

        if (_service.Adicionar(model))
        {
            return Created("", model);
        }

        return BadRequest(new
        {
            Mensagem = "Registro duplicado ou inválido!",
            Dica = "Já existe com a Descricao informados ou os dados estão inválidos."
        });
    }

    /// <summary>
    /// Atualiza um registro
    /// </summary>
    /// <remarks>
    /// Campos obrigatórios:
    ///     
    ///     {
    ///         "Descricao": ""
    ///     }
    /// 
    ///     OBS: campos não utilizados onde existe dado no registro do banco, o mesmo será apagado
    /// </remarks>
    /// <param name="model">Dados disponíveis para atualização</param>
    /// <response code="200">Registro atualizado com sucesso!</response>
    /// <response code="400">Retorna requisição mal sucedida com feedback</response>
    /// <response code="401">Retorna requisição não autorizada</response>
    [HttpPut()]
    public IActionResult Atualizar([FromBody] CarrinhoViewModel model)
    {
        if (model.Codigo == null || model.Codigo < 1)
            return BadRequest(new
            {
                Mensagem = "Campo obrigatório não fornecido ou inválido!",
                Dica = "Informe um valor válido no campo Codigo do corpo da requisição."
            });

        if (_service.Alterar(model))
            return Ok(_service.ObterPorId(model.Codigo ?? 0));

        return BadRequest(new
        {
            Mensagem = "Registro não encontrado no banco de dados! ",
            Dica = "Informe um código válido"
        });
    }

    /// <summary>
    /// Remove um registro baseado no ID do mesmo
    /// </summary>
    /// <param name="id">Filtro ID </param>
    /// <response code="200">Registro removido com sucesso</response>
    /// <response code="400">Retorna requisição mal sucedida</response>
    /// <response code="401">Retorna requisição não autorizada</response>
    [HttpDelete("{id:int?}")]
    public IActionResult Delete(int? id)
    {
        if (id == null)
            return BadRequest(new
            {
                Mensagem = "Requisição sem parametro ID.",
                Dica = "Informe o ID no final da URL. Exemplo: '/api/Carrinho/42'"
            });

        if (!_service.Deletar(id ?? 0))
            return BadRequest(new
            {
                Mensagem = $"Falha ao deletar ID {id}.",
                Dica = "Talvez seu ID não exista no banco de dados..."
            });

        return Ok();
    }

    #endregion
}
