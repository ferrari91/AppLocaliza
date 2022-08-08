using AppLocaliza.Authenticater;
using Localiza.Base.Models;
using Localiza.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppLocaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        protected readonly IServiceLocacao _user;

        public LocacaoController(IServiceLocacao user)
        {
            _user = user;
        }

       // [AuthorizeUser("Administrador, Operador, Cliente")]
        [HttpPost("{placa}")]
        public CadLocacao DoSimulator([FromQuery] string placa, [FromBody] SimulatorLocacao loc)
        {
            return _user.DoSimulate(placa, loc);
        }
    }
}
