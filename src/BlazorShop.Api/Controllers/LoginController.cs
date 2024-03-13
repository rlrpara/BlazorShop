using BlazorShop.Service.Interface;
using BlazorShop.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region [Private properties]
        private readonly ILoginService _service;
        #endregion

        #region [Private methods]
        private string? GetToken(UsuarioAuthenticateRequestViewModel login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return null;

            UsuarioAuthenticateResponseModel? resultado = _service.Authenticate(login);

            return resultado?.Token;
        }
        #endregion

        #region [Constructor]
        public LoginController(ILoginService loginService) => _service = loginService;
        #endregion

        #region [Public methods]
        [HttpPost]
        public IActionResult Authenticate(UsuarioAuthenticateRequestViewModel login)
        {
            if (ModelState.IsValid)
            {
                var token = GetToken(login);

                if (token == null)
                    return NotFound("\"Usuário não encontrado ou aguardando ativação.\"");

                return Ok($"\"{token}\"");
            }

            return BadRequest($"Classe inválida: {ModelState}");
        }
        #endregion
    }
}
