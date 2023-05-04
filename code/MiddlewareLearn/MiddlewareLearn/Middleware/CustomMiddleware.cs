namespace MiddlewareLearn.Middleware
{
    // using IMiddleware interface
    public class CustomMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public CustomMiddleware(ILogger<CustomMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Custom middleware run before action method");
            await next(context);
            _logger.LogInformation("Custom middleware run after action method");
        }
    }

    // using RequestDelegate
    //public class CustomMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly ILogger _logger;
    //    public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger) 
    //    {
    //        _next = next;
    //        _logger = logger;
    //    }
    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        _logger.LogInformation("Custom middleware run before action method");
    //        await _next(context);
    //        _logger.LogInformation("Custom middleware run after action method");
    //    }
    //}
}
