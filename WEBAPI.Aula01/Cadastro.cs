using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Aula01
{
    public class Cadastro
    {
        [Required]
        public string? Nome { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        [Required]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime DataNascimento { get; set; }
        
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
    }
}
