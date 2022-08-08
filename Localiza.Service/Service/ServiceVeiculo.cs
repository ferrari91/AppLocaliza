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
    public class ServiceVeiculo : IServiceVeiculo
    {
        protected readonly IRepositoryVeiculo _r;

        public ServiceVeiculo(IRepositoryVeiculo repository)
        {
            _r = repository;
        }

        public void Delete(int index)
        {
            _r.Delete(index);
        }

        public void Edit(CadVeiculo cadVeiculo)
        {
            cadVeiculo.Combustivel = ValidCombustivel(cadVeiculo.Combustivel);
            _r.Edit(cadVeiculo);
        }

        public List<CadVeiculo> GetAllRows()
        {
            return _r.GetAllDatas();
        }

        public CadVeiculo GetByIndex(int index)
        {
            return _r.GetByPK(index);
        }

        public string ValidCombustivel( string combustivel)
        {
            string[] models = { "Gasolina", "Alcool", "Diesel", "Híbrido" };

            for(int i = 0; i < models.Length; i++)
            {
                if (combustivel.Contains(models[i]))
                    return models[i];
            }

            return models[0];
        }



        public CadVeiculo Include(CadVeiculo cadVeiculo)
        {
            cadVeiculo.Combustivel = ValidCombustivel(cadVeiculo.Combustivel);

            if (_r.GetAllDatas().Count() == 0)
                cadVeiculo.IdVeiculo = 1;
            else
            {
                var LastPK = _r.GetAllDatas().OrderBy(x => x.IdVeiculo).Last();
                cadVeiculo.IdVeiculo = LastPK.IdVeiculo + 1;
            }

            return _r.Include(cadVeiculo);
        }

        public bool isTrue(bool value)
        {
            return value;
        }
    }
}
