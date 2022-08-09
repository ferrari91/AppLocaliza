using Localiza.Repository.Repository;
using Localiza.Service.Service;
using Moq;
using Xunit;

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
            _service        = new Mock<ServiceVeiculo>(_repository).Object;
        }


        [Theory]
        [InlineData("Gasolina")]
        [InlineData("Alcool")]
        [InlineData("Diesel")]
        [InlineData("Hibrido")]
        public void ValidCombustivelTest(string value)
        {
            Xunit.Assert.NotEqual("", _service.ValidCombustivel(value));
        }

        [Fact]
        public void GetAllRowsTest()
        {
            var rows = _repository.GetAllDatas();
            Xunit.Assert.NotEmpty(rows);
        }

        [Theory]
        [InlineData(1)]
        public void GetUserByIndexTest(int index)
        {
            var veiculo = _repository.GetByPK(index);
            Xunit.Assert.NotNull(veiculo);
        }

        [Theory]
        [InlineData("WWW123")]
        public void GetByBoardTest(string value)
        {
            Xunit.Assert.NotNull(_service.GetByBoard(value));
        }
    }
}
