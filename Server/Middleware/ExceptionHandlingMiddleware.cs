using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AutoRepair.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                LogError(context, ex);
                await HandleException(context, ex);
            }
        }

        private static void LogError(HttpContext context, Exception exception)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<ExceptionHandlingMiddleware>>();
            var request = context.Request;
            var response = context.Response;

            logger.LogError($"Request {{method}} {{url}} => {{statusCode}}. Exception - {{exception}}",
                request.Method,
                request.Path.Value,
                response.StatusCode,
                exception.Message);
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "GE" });
 
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
 
            return context.Response.WriteAsync(errorMessage);
        }
    }
}