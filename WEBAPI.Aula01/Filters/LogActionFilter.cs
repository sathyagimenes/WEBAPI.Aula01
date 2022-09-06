using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEBAPI.Aula01.Filters
{
    public class LogActionFilter : IActionFilter
    {
        Stopwatch stopwatch = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"Tempo de processamento: {stopwatch.Elapsed.Milliseconds} milissegundos");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
        }
    }
}
