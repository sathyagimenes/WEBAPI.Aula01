using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace WEBAPI.Aula01.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem503 = new ProblemDetails()
            {
                Status = 503,
                Title = "Serviço Indisponível",
                Detail = "Erro inesperado ao se comunicar com o banco de dados",
                Type = context.Exception.GetType().Name
            };
            var problem417 = new ProblemDetails()
            {
                Status = 417,
                Title = "Erro inesperado no sistema",
                Type = context.Exception.GetType().Name
            };
            var problem500 = new ProblemDetails()
            {
                Status = 500,
                Title = "Erro inesperado",
                Detail = "Tente novamente",
                Type = context.Exception.GetType().Name
            };
            switch (context.Exception)
            {
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(problem503);
                    break;
                case NullReferenceException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    context.Result = new ObjectResult(problem417);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problem500);
                    break;
            }
        }
    }
}
