using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ResultFilterLearn.Filters
{
    public class CustomResultFilter : IAsyncResultFilter
    {
        // Action filter is execute before and after action method.
        // Where Result filter is execute before and after action result not action method.
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Debug.WriteLine("Result filter execute before result");
            await next();
            Debug.WriteLine("Result filter execute after result");
        }
    }
}
