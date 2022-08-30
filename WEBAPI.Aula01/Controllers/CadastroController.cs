using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace WEBAPI.Aula01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CadastroController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
            "Harry Potter", "Hermione Granger", "Ronald Weasley", "Luna Lovegood", "Neville Longbottom"
        };
        private readonly ILogger<CadastroController> _logger;
        public List<Cadastro> cadastrosCliente { get; set; }

        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
            cadastrosCliente = Enumerable.Range(0, 5).Select(num => new Cadastro
            {
                DataNascimento = new DateTime((1960 + num), 01, 05),
                Nome = Nomes[num],
                Cpf = Convert.ToString(12345678900 + num)
            })
            .ToList();
        }

        // GET api/<CadastroController>
        [HttpGet("/cliente/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cadastro>> VerTudo()
        {
            return Ok(cadastrosCliente);
        }

        // GET api/<CadastroController>
        [HttpGet("/cliente/{cpf}/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cadastro> Consulta(string cpf)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            return Ok(cadastro);
        }

        //POST api/<CadastroController>
        [HttpPost("/cliente/inserção")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> Inserir(Cadastro clienteNovo)
        {
            cadastrosCliente.Add(clienteNovo);
            return CreatedAtAction(nameof(Inserir), clienteNovo);
        }

        // PUT api/<CadastroController>
        [HttpPut("/cliente/{cpf}/atualização")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> Atualizar(string cpf, Cadastro novoCadastro)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            cadastro.Nome = novoCadastro.Nome;
            cadastro.Cpf = novoCadastro.Cpf;
            cadastro.DataNascimento = novoCadastro.DataNascimento;
            return Ok(cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == novoCadastro.Cpf));
        }

        // DELETE api/<CadastroController>
        [HttpDelete("/cliente/{cpf}/remoção")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Deletar(string cpf)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            cadastrosCliente.Remove(cadastro);
            return NoContent();
        }
    }
}
