using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WEBAPI.Aula01.Core;
using WEBAPI.Aula01.Core.Interface;

namespace WEBAPI.Aula01.Infra.Repository
{
    public class CadastroRepository : ICadastroRepository
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
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @idade, @permissao)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastroCli.Cpf);
            parameters.Add("nome", cadastroCli.Nome);
            parameters.Add("dataNascimento", cadastroCli.DataNascimento);
            parameters.Add("dataNascimento", cadastroCli.DataNascimento);
            parameters.Add("idade", cadastroCli.Idade);
            parameters.Add("permissao", cadastroCli.Permissao);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        public bool DeleteCliente(string cpf)
        {
            var query = "DELETE FROM Clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
        }
        public bool UpdateCliente(string cpf, Cadastro cadastroCli)
        {
            var query = @"UPDATE Clientes SET 
                        cpf = @novoCpf,
                        nome = @nome,
                        dataNascimento = @dataNascimento,
                        idade = @idade,
                        permissao = @permissao
                        WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("novoCpf", cadastroCli.Cpf);
            parameters.Add("nome", cadastroCli.Nome);
            parameters.Add("dataNascimento", cadastroCli.DataNascimento);
            parameters.Add("idade", cadastroCli.Idade);
            parameters.Add("cpf", cpf);
            parameters.Add("permissao", cadastroCli.Permissao);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
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


