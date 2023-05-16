using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookAPI.Presentation.Filters
{
    public class ModelValidationFilter : Attribute, IAsyncActionFilter
    {
        #region Public Methods
        /// <summary>
        /// It validate model
        /// </summary>
        /// <param name="context">context contains information about current action</param>
        /// <param name="next">next is delegate which continue the sequence of request-response pipeline</param>
        /// <returns>This method is asynchronous so, it return Task</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == "POST" || context.HttpContext.Request.Method == "PUT")
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
            await next();
        }
        #endregion
    }
}
