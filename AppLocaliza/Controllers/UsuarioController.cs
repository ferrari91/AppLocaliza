using AppLocaliza.Authenticater;
using Localiza.Base.Models;
using Localiza.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppLocaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected readonly IServiceUsuario _user;

        public UsuarioController(IServiceUsuario user)
        {
            _user = user;
        }


        [HttpPost]
        public void Include(SegUsuario usuario)
        {
             _user.Include(usuario);
        }


        [HttpGet("{login}, {pass}")]
        public IActionResult Login(string login, string pass)
        {
            var role = _user.GetUsuario(login, pass);

            if (string.IsNullOrEmpty(role))
                return NotFound();

            var token = _user.AuthenticateUser(login, role);

            if (string.IsNullOrEmpty(token))
                return NotFound();

            return new AuthenticationActionResult(token);
        }
    }
}
