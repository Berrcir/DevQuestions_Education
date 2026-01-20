using CSharpFunctionalExtensions;
using DevQuestions.Application.Exceptions;
using Shared;
using System.Text.Json;

namespace DevQuestions.Web.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            _logger.LogError(exception, exception!.Message);

            var (code, errors) = exception switch
            {
                BadRequestException => (
                    StatusCodes.Status400BadRequest, JsonSerializer.Deserialize<Error[]>(exception.Message)),

                NotFoundException => (
                    StatusCodes.Status404NotFound, JsonSerializer.Deserialize<Error[]>(exception.Message)),

                _ => (StatusCodes.Status500InternalServerError, [Error.Failure(null, "Something went wrong...")]),
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = code;

            await httpContext.Response.WriteAsJsonAsync(errors);
        }
    }
}