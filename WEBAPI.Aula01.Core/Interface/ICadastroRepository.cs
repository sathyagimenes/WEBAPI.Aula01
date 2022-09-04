namespace WEBAPI.Aula01.Core.Interface
{
    public interface ICadastroRepository
    {
        List<Cadastro> GetClientes();
        bool InsertCliente(Cadastro cadastroCli);
        bool DeleteCliente(string cpf);
        bool UpdateCliente(string cpf, Cadastro cadastroCli);
        Cadastro GetClienteCpf(string cpf);
    }
}
