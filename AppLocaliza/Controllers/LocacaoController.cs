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
        [HttpPost("{idVeiculo}, {saida}, {retorno}, {cheio}, {limpo}, {arranhao}, {amassado}")]
        public CadLocacao DoSimulator(int idVeiculo, DateTime saida, DateTime retorno, bool cheio = true, bool limpo = true, bool arranhao = false, bool amassado = false)
        {
            return _user.DoSimulate(idVeiculo, saida, retorno, cheio, limpo, arranhao, amassado);
        }
    }
}
