using WEBAPI.Aula01.Core.Interface;

namespace WEBAPI.Aula01.Core.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadastroRepository;
        public CadastroService(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        public List<Cadastro> GetClientes()
        {
            return _cadastroRepository.GetClientes();
        }

        public bool DeleteCliente(string cpf)
        {
            return _cadastroRepository.DeleteCliente(cpf);
        }

        public Cadastro GetClienteCpf(string cpf)
        {
            return _cadastroRepository.GetClienteCpf(cpf);
        }

        public bool InsertCliente(Cadastro cadastroCli)
        {
            return _cadastroRepository.InsertCliente(cadastroCli);
        }

        public bool UpdateCliente(string cpf, Cadastro cadastroCli)
        {
            return _cadastroRepository.UpdateCliente(cpf, cadastroCli);
        }
    }
}
