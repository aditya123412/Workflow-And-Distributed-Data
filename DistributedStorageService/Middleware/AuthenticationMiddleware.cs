namespace DistributedStorageService.Middleware
{
    public class AuthenticationMiddleware : IMiddleware
    {
        private readonly ILogger<AuthenticationMiddleware> _logger;
        public AuthenticationMiddleware(ILogger<AuthenticationMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Example authentication logic
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            // Log the authenticated request
            _logger.LogInformation("Authenticated request from {IP}", context.Connection.RemoteIpAddress);
            // Call the next middleware in the pipeline
            await next(context);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IServiceCollection AddAuthenticationMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<AuthenticationMiddleware>();
        }
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}