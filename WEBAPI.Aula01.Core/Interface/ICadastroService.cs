using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Aula01.Core.Interface
{
    public interface ICadastroService
    {
        List<Cadastro> GetClientes();
        bool InsertCliente(Cadastro cadastroCli);
        bool DeleteCliente(string cpf);
        bool UpdateCliente(string cpf, Cadastro cadastroCli);
        Cadastro GetClienteCpf(string cpf);
    }
}
