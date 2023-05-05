using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BasicOfFilterWithActionFilter.Filters
{
    public class ExampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Before part of ExampleActionFilter executed");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("After part of ExampleActionFilter executed");
        }

    }
}
