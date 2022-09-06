using Microsoft.AspNetCore.Mvc;
using WEBAPI.Aula01.Core;
using WEBAPI.Aula01.Core.Interface;
using WEBAPI.Aula01.Filters;

namespace WEBAPI.Aula01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogActionFilter))]
    public class CadastroController : ControllerBase
    {
        public List<Cadastro> cadastrosCliente { get; set; }
        public ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        // GET
        [HttpGet("/cliente/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cadastro>> GetClientes()
        {
            return Ok(_cadastroService.GetClientes());
        }

        // GET
        [HttpGet("/cliente/{cpf}/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[TypeFilter(typeof(LogActionFilter))]
        public ActionResult<Cadastro> GetClienteCpf(string cpf)
        {
            var cadastro = _cadastroService.GetClienteCpf(cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            return Ok(cadastro);
        }

        // POST
        [HttpPost("/cliente/inserção")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> InsertCliente(Cadastro clienteNovo)
        {
            if (!_cadastroService.InsertCliente(clienteNovo))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InsertCliente), clienteNovo);
        }

        // PUT
        [HttpPut("/cliente/{cpf}/atualização")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCliente(string cpf, Cadastro novoCadastro)
        {
            if (!_cadastroService.UpdateCliente(cpf, novoCadastro))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE
        [HttpDelete("/cliente/{cpf}/remoção")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCliente(string cpf)
        {
            if (!_cadastroService.DeleteCliente(cpf))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
