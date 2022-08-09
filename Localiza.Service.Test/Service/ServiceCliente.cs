using Localiza.Repository.Repository;
using Localiza.Service.Service;
using Moq;
using Xunit;

namespace Localiza.Service.Test.Service
{
    [TestClass]
    public class ServiceClienteTest
    {
        protected readonly ServiceCliente _service;
        protected readonly RepositoryCliente _repositoty;

        public ServiceClienteTest()
        {
            _repositoty = new Mock<RepositoryCliente>().Object;
            _service = new Mock<ServiceCliente>(_repositoty).Object;
        }

        [Fact]
        public void GetAllRowsTest()
        {
            Xunit.Assert.NotEmpty(_service.GetAllRows());
        }

        [Fact]
        public void IncludeTest()
        {
            Xunit.Assert.True(_service.Include(new Base.Models.PesCliente
            {
                Nome = "Teste"
            }));
        }

        [Fact]
        public void GetLastPkTest()
        {
            Xunit.Assert.Equal(null, _service.GetByIndex(0));
        }
    }
}
