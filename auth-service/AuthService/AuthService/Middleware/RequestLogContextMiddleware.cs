using Serilog.Context;

namespace AuthService.Middleware
{
    public class RequestLogContext
    {
        private readonly RequestDelegate _next;

        public RequestLogContext(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                return _next(context);
            }
        }
    }

    public static class RequestLogContextMiddleware
    {
        public static IApplicationBuilder UseRequestLogContext(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLogContext>();
        }
    }
}
