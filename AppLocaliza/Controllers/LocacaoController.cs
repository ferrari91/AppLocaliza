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

        [AuthorizeUser("Administrador, Operador, Cliente")]
        [HttpPost("{placa}")]
        public CadLocacao DoSimulator([FromQuery] string placa, [FromBody] SimulatorLocacao loc)
        {
            return _user.DoSimulate(placa, loc);
        }

        [AuthorizeUser("Administrador, Operador")]
        [HttpPost]
        public IActionResult Include([FromQuery] string veiculo, [FromBody] string clienteRef)
        {
            var result = _user.Register(veiculo, clienteRef);

            if (!result)
            {
                return new JsonResult(new { message = "Veiculo ou Cliente não foram encontrados." })
                {
                    StatusCode = StatusCodes.Status501NotImplemented
                };
            }
                

            return new JsonResult(new { message = "Locação Registrada com Sucesso." })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        [AuthorizeUser("Administrador, Operador")]
        [HttpGet]
        public IEnumerable<CadLocacao> GetRows()
        {
            return _user.GetAllRows();
        }
    }
}
