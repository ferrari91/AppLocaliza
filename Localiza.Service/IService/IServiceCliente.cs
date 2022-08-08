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

        bool Include(PesCliente pesCliente);

        PesCliente GetByIndex(int index);

        bool Edit(PesCliente pesCliente);

        bool Delete(int index);
    }
}
