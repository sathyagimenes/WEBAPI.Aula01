using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WEBAPI.Aula01.Repository;


namespace WEBAPI.Aula01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CadastroController : ControllerBase
    {
        //private static readonly string[] Nomes = new[]
        //{
        //    "Harry Potter", "Hermione Granger", "Ronald Weasley", "Luna Lovegood", "Neville Longbottom"
        //};
        //private readonly ILogger<CadastroController> _logger;
        public List<Cadastro> cadastrosCliente { get; set; }
        public CadastroRepository _repositoryCadastro;

        public CadastroController(IConfiguration configuration)
        {
            cadastrosCliente = new List<Cadastro>();
            _repositoryCadastro = new CadastroRepository(configuration);
        }

        //public CadastroController(ILogger<CadastroController> logger)
        //{
        //    _logger = logger;
        //    cadastrosCliente = Enumerable.Range(0, 5).Select(num => new Cadastro
        //    {
        //        DataNascimento = new DateTime((1960 + num), 01, 05),
        //        Nome = Nomes[num],
        //        Cpf = Convert.ToString(12345678900 + num)
        //    })
        //    .ToList();
        //}

        // GET
        [HttpGet("/cliente/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cadastro>> GetClientes()
        {
            return Ok(_repositoryCadastro.GetClientes());
        }

        // GET
        [HttpGet("/cliente/{cpf}/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cadastro> GetClienteCpf(string cpf)
        {
            var cadastro = _repositoryCadastro.GetClienteCpf(cpf);
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
            if (!_repositoryCadastro.InsertCliente(clienteNovo))
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
            if (!_repositoryCadastro.UpdateCliente(cpf, novoCadastro))
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
            if (!_repositoryCadastro.DeleteCliente(cpf))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
