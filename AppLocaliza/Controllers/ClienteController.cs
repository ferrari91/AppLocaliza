using AppLocaliza.Authenticater;
using Localiza.Base.Models;
using Localiza.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLocaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IServiceCliente _user;

        public ClienteController(IServiceCliente cliente)
        {
            _user = cliente;
        }

        [HttpGet]
        [AuthorizeUser("Administrador, Operador")]
        public IEnumerable<PesCliente> Get()
        {
            return _user.GetAllRows();
        }

        [HttpPost]
        [AuthorizeUser("Administrador, Operador")]
        public void NewCliente(PesCliente cliente)
        {
             _user.Include(cliente);
        }

        [HttpGet("{id}")]
        [AuthorizeUser("Administrador, Operador")]
        public ActionResult<PesCliente> GetCliente(int id)
        {
            var user = _user.GetByIndex(id);

            if (user == null)
                return NotFound();

            return _user.GetByIndex(id);
        }

        [HttpPut("{id}")]
        [AuthorizeUser("Administrador, Operador")]
        public ActionResult PutCliente(int id, PesCliente cliente)
        {
            if (id != cliente.IdCliente)
                return BadRequest();

            _user.Edit(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeUser("Administrador")]
        public ActionResult DeleteCliente(int id)
        {
            var user = _user.GetByIndex(id);

            if (user == null)
                return BadRequest();

            _user.Delete(id);
            
            return Ok();
        }
    }
}
