using AppLocaliza.Authenticater;
using Localiza.Base.Models;
using Localiza.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppLocaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        protected readonly IServiceVeiculo _user;

        public VeiculoController(IServiceVeiculo user)
        {
            _user = user;
        }

        [HttpGet]
        public IEnumerable<CadVeiculo> Get()
        {
            return _user.GetAllRows();
        }

        [HttpPost]
        [AuthorizeUser("Administrador, Operador")]
        public CadVeiculo NewVeiculo(CadVeiculo veiculo)
        {
            return _user.Include(veiculo);
        }

        [HttpGet("{id}")]
        [AuthorizeUser("Administrador, Operador")]
        public ActionResult<CadVeiculo> GetVeiculo(int id)
        {
            var user = _user.GetByIndex(id);

            if (user == null)
                return NotFound();

            return _user.GetByIndex(id);
        }

        [HttpPut("{id}")]
        [AuthorizeUser("Administrador, Operador")]
        public ActionResult PutVeiculo(int id, CadVeiculo veiculo)
        {
            if (id != veiculo.IdVeiculo)
                return BadRequest();

            _user.Edit(veiculo);
            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeUser("Administrador")]
        public ActionResult DeleteVeiculo(int id)
        {
            var user = _user.GetByIndex(id);

            if (user == null)
                return BadRequest();

            _user.Delete(id);

            return Ok();
        }
    }
}
