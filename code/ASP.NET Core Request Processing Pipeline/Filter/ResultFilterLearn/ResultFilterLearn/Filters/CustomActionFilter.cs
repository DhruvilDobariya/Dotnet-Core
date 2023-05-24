using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ResultFilterLearn.Filters
{
    public class CustomActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine("Action filter execute before result");
            await next();
            Debug.WriteLine("Action filter execute after result");
        }
    }
}
