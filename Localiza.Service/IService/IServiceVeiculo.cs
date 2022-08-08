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

        CadVeiculo Include(CadVeiculo cadVeiculo);

        CadVeiculo GetByIndex(int index);

        void Edit(CadVeiculo cadVeiculo);

        void Delete(int index);

        string ValidCombustivel(string combustivel);

        bool isTrue(bool value);
    }
}
