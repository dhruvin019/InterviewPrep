using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace practice1.Middleware2
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine($" Request: {context.Request.Method} {context.Request.Path}");

            await _next(context); // Call next middleware or controller

            stopwatch.Stop();
            Console.WriteLine($" Response: {context.Response.StatusCode}, Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
