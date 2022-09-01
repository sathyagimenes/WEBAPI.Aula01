using Dapper;
using Microsoft.Data.SqlClient;

namespace WEBAPI.Aula01.Repository
{
    public class CadastroRepository
    {
        private readonly IConfiguration _configuration;

        public CadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cadastro> GetClientes()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Cadastro>(query).ToList();
        }

        public bool InsertCliente(Cadastro cadastroCli)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastroCli.Cpf);
            parameters.Add("nome", cadastroCli.Nome);
            parameters.Add("dataNascimento", cadastroCli.DataNascimento);
            parameters.Add("idade", cadastroCli.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(string cpf)
        {
            var query = "DELETE FROM Clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCliente(string cpf, Cadastro cadastroCli)
        {
            var query = @"UPDATE Clientes SET 
                        cpf = @novoCpf,
                        nome = @nome,
                        dataNascimento = @dataNascimento,
                        idade = @idade
                        WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("novoCpf", cadastroCli.Cpf);
            parameters.Add("nome", cadastroCli.Nome);
            parameters.Add("dataNascimento", cadastroCli.DataNascimento);
            parameters.Add("idade", cadastroCli.Idade);
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
        public Cadastro GetClienteCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new
            {
                cpf
            });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cadastro>(query, parameters);
        }
    }
}


