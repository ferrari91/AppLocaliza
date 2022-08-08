using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AppLocaliza.Authenticater
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
    {
        private string? _role;

        public AuthorizeUserAttribute()
        {
            _role = null;
        }

        public AuthorizeUserAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["Role"]?.ToString();

            if(!string.IsNullOrEmpty(_role))
            {
                if (user == null)
                {
                    context.Result = new JsonResult(new { message = "Você não tem nível de acesso para continuar." })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };

                    return;
                }

                string[] roles = _role.Split(new char[] { ' ', ',' });
                for (int i = 0; i < roles.Length; i++)
                {
                    if (user == roles[i])
                        return;
                }

                context.Result = new JsonResult(new { message = "Você não tem nível de acesso para continuar." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            
         
        }
    }
}
