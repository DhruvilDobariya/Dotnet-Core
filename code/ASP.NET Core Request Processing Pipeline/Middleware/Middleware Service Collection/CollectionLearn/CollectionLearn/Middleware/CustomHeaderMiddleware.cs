namespace CollectionLearn.Middleware
{
    public class CustomHeaderMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            context.Response.Headers.Add("Name", "Dhruvil A. Dobariya");
        }
    }
}
