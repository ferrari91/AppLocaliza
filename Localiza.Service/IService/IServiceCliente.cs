using Localiza.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Service.IService
{
    public interface IServiceCliente
    {
        List<PesCliente> GetAllRows();

        PesCliente Include(PesCliente pesCliente);

        PesCliente GetByIndex(int index);

        void Edit(PesCliente pesCliente);

        void Delete(int index);
    }
}
