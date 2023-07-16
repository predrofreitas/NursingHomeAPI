using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace NursingHomeAPI.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Internal Server Error",
                    Title = "Server Error",
                    Detail = "An internal server has ocurred"
                };

                var problemJson = JsonSerializer.Serialize(problem);

                await context.Response.WriteAsync(problemJson);

                context.Response.ContentType = "application/json";
            }
        }
    }
}
