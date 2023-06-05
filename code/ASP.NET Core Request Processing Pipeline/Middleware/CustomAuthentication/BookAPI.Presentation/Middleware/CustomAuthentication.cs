
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookAPI.Presentation.Middleware
{
    public class CustomAuthentication : IMiddleware
    {
        private readonly IConfiguration _configuration;
        public CustomAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool isAnonymous = context.GetEndpoint().Metadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
            if (!isAnonymous)
            {
                var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var secretKey = new SymmetricSecurityKey(secretKeyBytes);

                var validationParameter = new TokenValidationParameters()
                {
                    IssuerSigningKey = secretKey,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidAudience = _configuration["JWT:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                try
                {
                    StringValues token;
                    if (context.Request.Headers.TryGetValue("Authorization", out token))
                    {
                        SecurityToken securityToken;
                        var claimsPrincipal = tokenHandler.ValidateToken(token.FirstOrDefault().Split(" ")[1], validationParameter, out securityToken);
                        context.User = claimsPrincipal;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    // if token is not valid then it throw exception
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid token");
                    return;
                }
            }
            await next(context);
        }
    }
}
