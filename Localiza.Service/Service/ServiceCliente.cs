using Localiza.Base.Models;
using Localiza.Repository.Interface;
using Localiza.Service.IService;

namespace Localiza.Service.Service
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IRepositoryCliente _r;

        public ServiceCliente(IRepositoryCliente r)
        {
            _r = r;
        }

        public void Delete(int index)
        {
            _r.Delete(index);
        }

        public void Edit(PesCliente pesCliente)
        {
            _r.Edit(pesCliente);
        }

        public List<PesCliente> GetAllRows()
        {
            return _r.GetAllDatas();
        }

        public PesCliente GetByIndex(int index)
        {
           return _r.GetByPK(index);
        }

        public PesCliente Include(PesCliente pesCliente)
        {
            if (_r.GetAllDatas().Count() == 0)
                pesCliente.IdCliente = 1;
            else
            {
                var LastPK = _r.GetAllDatas().OrderBy(x => x.IdCliente).Last();
                pesCliente.IdCliente = LastPK.IdCliente + 1;
            }

            return _r.Include(pesCliente);
        }
    }
}
