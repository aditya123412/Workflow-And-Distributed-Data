
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataCommonClasses.Middleware
{

    public class LoggingMiddleWare : IMiddleware
    {
        private readonly ILogger<LoggingMiddleWare> _logger;
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.OnStarting(() =>
            {
                _logger.LogInformation("Request Path: {Path}", context.Request.Path, context.TraceIdentifier, context.Request, DateTime.UtcNow);
                _logger.LogInformation("Response Status Code: {StatusCode}", context.Response.StatusCode, DateTime.UtcNow);
                return Task.CompletedTask;
            });
            return next(context);
        }
    }
    public static class LoggingMiddlewareExtensions
    {
        public static IServiceCollection AddLoggingMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<LoggingMiddleWare>();
        }
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleWare>();
        }
    }
}
