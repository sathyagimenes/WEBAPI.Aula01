using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WEBAPI.Aula01.Core;
using WEBAPI.Aula01.Core.Interface;

namespace WEBAPI.Aula01.Filters
{
    public class CpfValidationActionFilter : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;
        public CpfValidationActionFilter(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cadastro clienteNovo = (Cadastro)context.ActionArguments["clienteNovo"];

            if (_cadastroService.GetClienteCpf(clienteNovo.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
