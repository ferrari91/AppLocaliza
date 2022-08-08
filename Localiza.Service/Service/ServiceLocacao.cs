using Localiza.Base.Models;
using Localiza.Repository.Interface;
using Localiza.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Service.Service
{
    public class ServiceLocacao : IServiceLocacao
    {
        protected readonly IRepositoryLocacao _r;
        protected readonly IServiceVeiculo _v;
        protected readonly IServiceCliente _c;

        public ServiceLocacao(IRepositoryLocacao r, IServiceVeiculo v, IServiceCliente c)
        {
            _r = r;
            _v = v;
            _c = c;
        }

        public bool Delete(int id)
        {
            return _r.Delete(id);
        }

        public CadLocacao DoSimulate(string placa, SimulatorLocacao doLocacao)
        {
            try
            {
                var veiculo = _v.GetByBoard(placa);
                var hours = Convert.ToDecimal(doLocacao.Saida.Subtract(doLocacao.Retorno).TotalHours);
                var value = veiculo.Valor;

                var fixedPrice = (value * hours);

                var totalPrice = fixedPrice;

                if (!doLocacao.Abastecido)
                    totalPrice += (fixedPrice * 30) / 100;
                if (!doLocacao.Limpo)
                    totalPrice += (fixedPrice * 30) / 100;
                if (doLocacao.Arranhado)
                    totalPrice += (fixedPrice * 30) / 100;
                if (doLocacao.Amassado)
                    totalPrice += (fixedPrice * 30) / 100;

                return new CadLocacao
                {
                    IdLocacao = GetLastPK(),
                    CodigoVeiculo = veiculo.IdVeiculo,
                    Abastecido = doLocacao.Abastecido,
                    Limpo = doLocacao.Limpo,
                    Arranhado = doLocacao.Arranhado,
                    Amassado = doLocacao.Amassado,
                    Retorno = doLocacao.Retorno,
                    Saida = doLocacao.Saida,
                    Total = totalPrice
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(CadLocacao cadLocacao)
        {
            return _r.Edit(cadLocacao);
        }

        public List<CadLocacao> GetAllRows()
        {
            return _r.GetAllDatas();
        }

        public CadLocacao GetByIndex(int id)
        {
            return _r.GetByPK(id);
        }

        public int GetLastPK()
        {
            var allLocates = _r.GetAllDatas();

            if (allLocates.Count() == 0)
                return 1;

            return allLocates.OrderBy(x => x.IdLocacao).Last().IdLocacao + 1;
        }

        public bool Include(CadLocacao cadLocacao)
        {
            return _r.Include(cadLocacao);
        }

        public bool Register(string placa, string clienteRef)
        {
            var veiculo = _v.GetAllRows().Where(x => x.Placa == placa).First();
            var cliente = _c.GetAllRows().Where(x => x.Nome == clienteRef || x.Documento == clienteRef).First();

            if (cliente == null || veiculo == null)
                return false;

            return Include(
                new CadLocacao
                {
                    IdLocacao = GetLastPK(),
                    CodigoCliente = cliente.IdCliente,
                    CodigoVeiculo = veiculo.IdVeiculo,
                    Saida = DateTime.Now
                }
                );
        }
    }
}
