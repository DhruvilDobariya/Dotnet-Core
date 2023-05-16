using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BookAPI.Presentation.Middleware
{
    public class Performance : IMiddleware
    {
        private readonly ILogger<Performance> _logger;
        public Performance(ILogger<Performance> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await next(context);
            stopWatch.Stop();
            var jsonObject = new JsonObject();
            jsonObject.Add("IP", ipAddress);
            jsonObject.Add("RoundTripTime", stopWatch.ElapsedMilliseconds);
            jsonObject.Add("Service", context.Request.Path.Value);
            jsonObject.Add("Method", context.Request.Method);
            jsonObject.Add("StatusCode", context.Response.StatusCode);
            jsonObject.Add("DateTime", DateTime.UtcNow.ToString("dd-MM-yyyy hh:mm:ss"));

            _logger.LogInformation(JsonSerializer.Serialize(jsonObject));

        }
    }
}
