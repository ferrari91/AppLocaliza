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


        [HttpPost("{user}")]
        public IActionResult Login(string user, [FromBody] Usuario usuario)
        {
            if (user != usuario.usuario)
                return NotFound();

            var role = _user.GetUsuario(usuario.usuario, usuario.senha);

            if (string.IsNullOrEmpty(role))
                return NotFound();

            var token = _user.AuthenticateUser(usuario.usuario, role);

            if (string.IsNullOrEmpty(token))
                return NotFound();

            return new AuthenticationActionResult(token);
        }
    }
}
