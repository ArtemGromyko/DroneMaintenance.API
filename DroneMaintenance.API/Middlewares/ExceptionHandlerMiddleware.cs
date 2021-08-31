using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerManager logger)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch(ForbiddenActionException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.Forbidden);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode code)
        {
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(message);
        }
    }
}
