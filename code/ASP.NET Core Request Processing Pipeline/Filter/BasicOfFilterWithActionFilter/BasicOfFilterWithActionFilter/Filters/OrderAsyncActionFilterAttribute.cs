using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilterLearn.Filters
{
    public class OrderAsyncActionFilterAttribute : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        public OrderAsyncActionFilterAttribute(string name, int order)
        {
            Order = order;
            Name = name;
        }
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine($"Before part of OrederAsyncActionFilterAttribute executed by {Name}");

            await next();

            Debug.WriteLine($"After part of OrederAsyncActionFilterAttribute executed by {Name}");

        }
    }
}
