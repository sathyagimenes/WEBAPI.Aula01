using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Aula01.Core.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string nome, string permissao);
    }
}
