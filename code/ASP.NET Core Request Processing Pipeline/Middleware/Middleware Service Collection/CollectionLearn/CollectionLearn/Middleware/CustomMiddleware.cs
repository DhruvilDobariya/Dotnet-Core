namespace CollectionLearn.Middleware
{
    public static class CustomMiddleware
    {
        public static void UseCustomHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomHeaderMiddleware>();
            // other middleware which have same behavior...
        }
        // other middleware methods...
    }
}
