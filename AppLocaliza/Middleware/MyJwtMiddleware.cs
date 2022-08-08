using Localiza.Service.IService;
using Localiza.Service.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AppLocaliza.Middleware
{
    public class MyJwtMiddleware
    {
        private RequestDelegate _next;

        public MyJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IServiceUsuario service)
        {
            var cookies = context.Request.Cookies;
            if (cookies != null)
            {
                string hash = "";
                cookies.TryGetValue("Authentication", out hash);

                if (!String.IsNullOrEmpty(hash))
                    AttachUserToContext(context, service, hash);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IServiceUsuario service, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(ServiceUsuario.tokenHash);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                context.Items["Role"] = jwtToken.Claims.First(x => x.Type == "role").Value;
            }
            catch { }
        }
    }
}

