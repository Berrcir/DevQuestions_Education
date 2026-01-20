using DevQuestions.Web.Middlewares;

namespace DevQuestions.Web.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this WebApplication app) =>
            app.UseMiddleware<ExceptionsMiddleware>();
    }
}