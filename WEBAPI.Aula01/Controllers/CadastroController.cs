using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace WEBAPI.Aula01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        //Enunciado
        // Construa um cadastro completo (CRUD) de clientes.
        // Neste cadastro, o cliente deve possuir cpf, nome,
        // data de nascimento e idade.

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
                DataNascimento = new DateTime((1960+ num), 01, 05),
                Nome = Nomes[num],
                Cpf = 12345678900 + (long)num
            })
            .ToList();
        }

        // GET api/<CadastroController>
        [HttpGet]
        public List<Cadastro> VerTudo()
        {
            return cadastrosCliente;
        }

        // GET api/<CadastroController>
        [HttpGet("{cpf}")]
        public Cadastro? Consulta(long cpf)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            if (cadastro != null)
                return cadastro;
            else
                return null;
        }

        //POST api/<CadastroController>
        [HttpPost]
        public Cadastro Inserir(Cadastro clienteNovo)
        {
            cadastrosCliente.Add(clienteNovo);
            return clienteNovo;
        }

        // PUT api/<CadastroController>
        [HttpPut]
        public Cadastro? Atualizar(long cpf, Cadastro novoCadastro)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            cadastro.Nome = novoCadastro.Nome;
            cadastro.Cpf = novoCadastro.Cpf;
            cadastro.DataNascimento = novoCadastro.DataNascimento;
            return cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == novoCadastro.Cpf);
        }

        // DELETE api/<CadastroController>
        [HttpDelete]
        public List<Cadastro> Deletar(long cpf)
        {
            var cadastro = cadastrosCliente.Find(cadastrosCliente => cadastrosCliente.Cpf == cpf);
            cadastrosCliente.Remove(cadastro);
            return cadastrosCliente;
        }
    }
}
