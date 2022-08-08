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
        protected readonly IRepositoryVeiculo _v;

        public ServiceLocacao(IRepositoryLocacao r, IRepositoryVeiculo v)
        {
            _r = r;
            _v = v;
        }

        public void Delete(int id)
        {
            _r.Delete(id);
        }

        public CadLocacao DoSimulate(int veiculoId, DateTime entrance, DateTime exit, bool full = true, bool clenead = true, bool scratch = false, bool kneaded = false)
        {
            var veiculo = _v.GetByPK(veiculoId);

            if (veiculo == null)
                return null;

            var hours = Convert.ToDecimal(exit.Subtract(entrance).TotalHours);
            var value = veiculo.Valor;

            var fixedPrice = (value * hours);

            var totalPrice = fixedPrice;

            if (!full)
                totalPrice += (fixedPrice * 30) / 100;
            if (!clenead)
                totalPrice += (fixedPrice * 30) / 100;
            if (scratch)
                totalPrice += (fixedPrice * 30) / 100;
            if (kneaded)
                totalPrice += (fixedPrice * 30) / 100;

            return new CadLocacao
            {
                IdLocacao = GetLastPK(),
                CodigoVeiculo = veiculoId,
                Abastecido = full,
                Limpo = clenead,
                Arranhado = scratch,
                Amassado = kneaded,
                Retorno = exit,
                Saida = entrance,
                Total = totalPrice
            };
        }

        public void Edit(CadLocacao cadLocacao)
        {
            _r.Edit(cadLocacao);
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

        public CadLocacao Include(CadLocacao cadLocacao)
        {
            return _r.Include(cadLocacao);
        }
    }
}
