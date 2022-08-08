using Localiza.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Service.IService
{
    public interface IServiceLocacao
    {
        List<CadLocacao> GetAllRows();

        CadLocacao Include(CadLocacao cadLocacao);

        void Edit(CadLocacao cadLocacao);

        void Delete(int id);

        int GetLastPK();

        CadLocacao GetByIndex(int id);

        CadLocacao DoSimulate(int veiculoId, DateTime entrance, DateTime exit, bool full = true, bool clenead = true, bool scratch = false, bool kneaded = false);
    }
}
