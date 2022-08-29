namespace WEBAPI.Aula01
{
    public class Cadastro
    {
        public string? Nome { get; set; }

        public long Cpf { get; set; }

        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public override string ToString()
        {
            return $"Nome: {Nome}\nCpf: {Cpf}\nData de nascimento {DataNascimento}" +
                $"\nIdade: {Idade}";
        }
    }
}
