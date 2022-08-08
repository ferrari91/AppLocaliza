using Localiza.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Service.IService
{
    public interface IServiceVeiculo
    {
        List<CadVeiculo> GetAllRows();

        bool Include(CadVeiculo cadVeiculo);

        CadVeiculo GetByIndex(int index);

        bool Edit(CadVeiculo cadVeiculo);

        bool Delete(int index);

        string ValidCombustivel(string combustivel);

        CadVeiculo GetByBoard(string board);

    }
}
