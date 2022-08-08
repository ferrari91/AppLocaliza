using Localiza.Repository.Interface;
using Localiza.Repository.Repository;
using Localiza.Service.IService;
using Localiza.Service.Service;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Localiza.Service.Test.Service
{
    [TestClass]
    public class ServiceVeiculoTest
    {

        protected readonly RepositoryVeiculo _repository;
        protected readonly ServiceVeiculo _service;

        public ServiceVeiculoTest()
        {
            _repository     = new Mock<RepositoryVeiculo>().Object;
            _service        = new ServiceVeiculo(new Mock<IRepositoryVeiculo>().Object);
        }


        [TestMethod]
        public void ValidCombustivelTest()
        {
            var combustivel = String.Empty;
            Xunit.Assert.NotEqual(String.Empty, _service.ValidCombustivel(combustivel));
        }

        [TestMethod]
        public void GetAllRowsTest()
        {
            var rows = _repository.GetAllDatas();
            Xunit.Assert.NotEmpty(rows);
        }

        [TestMethod]
        public void GetUserByIndexTest()
        {
            var veiculo = _repository.GetByPK(-1);
            Xunit.Assert.Null(veiculo);
        }

    }
}
