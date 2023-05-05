using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace AuthorizationFilterLearn.Filter
{
    public class CustomAuthorizationFilter : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            StringValues usernames;
            StringValues passwords;
            if(context.HttpContext.Request.Headers.TryGetValue("Username", out usernames) && context.HttpContext.Request.Headers.TryGetValue("Password", out passwords))
            {
                if(usernames.FirstOrDefault().Equals("Admin") && passwords.FirstOrDefault().Equals("Admin@123"))
                {
                    return; // next filter
                }
            }
            context.Result = new UnauthorizedResult();
        }
    }
}
