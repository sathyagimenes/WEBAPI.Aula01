using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WEBAPI.Aula01.Core.Interface;

namespace WEBAPI.Aula01.Filters
{
    public class RegistrationValidationActionFilter : IActionFilter
    {
        public ICadastroService _cadastroService;
        public RegistrationValidationActionFilter(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string cpf = (string)context.ActionArguments["cpf"];

            if (_cadastroService.GetClienteCpf(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
