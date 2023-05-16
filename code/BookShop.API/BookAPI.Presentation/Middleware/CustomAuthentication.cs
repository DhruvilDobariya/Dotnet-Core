using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookAPI.Presentation.Middleware
{
    /// <summary>
    /// Authenticate Jwt token
    /// </summary>
    public class CustomAuthentication : IMiddleware
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public CustomAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Public Methods
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            StringValues keys;
            if (context.Request.Headers.TryGetValue("Authorization", out keys))
            {
                var key = keys.FirstOrDefault().Split(" ")[1];
                var secretKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var validationParameter = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidAudience = _configuration["JWT:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    SecurityToken securityToken;
                    tokenHandler.ValidateToken(key, validationParameter, out securityToken);
                }
                catch
                {
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
            }
            await next(context);
        }
        #endregion
    }
}
