using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace ResourceFilterLearn.Filters
{
    // Action filter is applied to individual actions or controllers and offer specific customization.
    // Where resource filter operate on the entire request/response pipeline and provide global behavior and cross-cutting concern handling.
    public class CustomResourceFilter : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Debug.WriteLine("Resource filter executed before action method");
            await next();
            Debug.WriteLine("Resource filter executed after action method");
        }
    }
}
