using Microsoft.AspNetCore.Mvc;

namespace AppLocaliza.Authenticater
{
    public class AuthenticationActionResult : IActionResult
    {
        public string Authentication { get; }
        public AuthenticationActionResult(string authentication)
        {
            Authentication = authentication;
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Cookies.Append("Authentication", Authentication);
            context.HttpContext.Response.Redirect("Logged");
            return Task.CompletedTask;
        }
    }
}
