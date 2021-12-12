using ClientApi.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ClientApi.Infrastructure.Middlewares
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(new Response<string>() 
            {
                ErrorMessage = context.Exception.Message,
                StatusCode = 400,
                AnErrorOcurred = true,
                Data = null
            });

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
