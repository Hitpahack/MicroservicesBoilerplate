using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OrderService.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log request details
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            var stopwatch = Stopwatch.StartNew();
            await _next(context); // Call the next middleware
            stopwatch.Stop();

            // Log response details
            _logger.LogInformation($"Response: {context.Response.StatusCode} - Took {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
