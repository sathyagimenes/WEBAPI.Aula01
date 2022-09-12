using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Aula01.Core
{
    public class Cadastro
    {
        public long Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        [Required]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public int Idade { get; private set; }

        [Required]
        public string Permissao { get; set; }

        public Cadastro(long id, string cpf, string nome, DateTime dataNascimento, int idade, string permissao)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = ObterIdade();
            Permissao = permissao;
        }

        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }
}
