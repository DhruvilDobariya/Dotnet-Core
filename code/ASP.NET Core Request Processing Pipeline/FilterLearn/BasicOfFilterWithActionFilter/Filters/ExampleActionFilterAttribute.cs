﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BasicOfFilterWithActionFilter.Filters
{
    public class ExampleActionFilterAttribute : Attribute, IActionFilter // Or we can use ActionFilterAttribute class
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Before part of ExampleActionFilterAttribute executed");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("After part of ExampleActionFilterAttribute executed");
        }
    }
}
