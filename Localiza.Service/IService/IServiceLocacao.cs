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

        bool Include(CadLocacao cadLocacao);

        bool Edit(CadLocacao cadLocacao);

        bool Register(string placa, string clienteRef);

        bool Delete(int id);

        int GetLastPK();

        CadLocacao GetByIndex(int id);

        CadLocacao DoSimulate(string board, SimulatorLocacao simulator);
    }
}
