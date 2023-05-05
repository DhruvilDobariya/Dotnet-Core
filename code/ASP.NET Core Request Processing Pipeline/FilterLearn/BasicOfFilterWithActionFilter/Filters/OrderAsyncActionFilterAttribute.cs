using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BasicOfFilterWithActionFilter.Filters
{
    public class OrderAsyncActionFilterAttribute : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;

        public OrderAsyncActionFilterAttribute(string name, int order)
        {
            Order = order;
            Name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine($"Before part of OrederAsyncActionFilterAttribute executed by {Name}");

            await next();

            Debug.WriteLine($"After part of OrederAsyncActionFilterAttribute executed by {Name}");

        }
    }
}
