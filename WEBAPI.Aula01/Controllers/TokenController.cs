using Microsoft.AspNetCore.Mvc;
using WEBAPI.Aula01.Core.Interface;

namespace WEBAPI.Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        public ICadastroService _cadastroService;
        public ITokenService _tokenService;
        public TokenController(ICadastroService cadastroService, ITokenService tokenService)
        {
            _cadastroService = cadastroService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateToken(string cpf)
        {
            var client = _cadastroService.GetClienteCpf(cpf);
            if (client == null)
            {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateToken(client.Nome, client.Permissao));
        }
    }
}
