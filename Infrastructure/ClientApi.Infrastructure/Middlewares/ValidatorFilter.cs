using ClientApi.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Infrastructure.Middlewares
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(w => w.Value.Errors.Count > 0)
                                              .SelectMany(w => w.Value.Errors.Select(w => w.ErrorMessage)).ToList();

                context.Result = new BadRequestObjectResult(
                    new Response<string>
                    {
                        ErrorMessage = string.Join("", errors),
                        AnErrorOcurred = true,
                        StatusCode = 400,
                        Data = null
                    });

                return;
            }

            await next();
        }
    }
}
