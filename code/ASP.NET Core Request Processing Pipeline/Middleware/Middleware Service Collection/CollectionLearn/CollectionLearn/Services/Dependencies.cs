using CollectionLearn.BL;
using CollectionLearn.BL.Services;
using CollectionLearn.DAL;
using CollectionLearn.DAL.Services;
using CollectionLearn.Middleware;

namespace CollectionLearn.Services
{
    public static class Dependencies
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IBLUserHandler, BLUserHandler>();
            // other services...
        }

        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<IDBUserContext, DBUserContext>();
            // other services...
        }

        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<CustomHeaderMiddleware>();
            // other middleware...
        }
    }
}
