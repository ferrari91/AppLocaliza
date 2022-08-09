using Localiza.Repository.Repository;
using Localiza.Service.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Localiza.Service.Test.Service
{

    [TestClass]
    public class ServiceLocacaoTest
    {
        protected readonly ServiceLocacao _service;
        protected readonly ServiceCliente _sCliente;
        protected readonly ServiceVeiculo _sVeiculo;
        protected readonly RepositoryLocacao _repositoty;
        protected readonly RepositoryVeiculo _veiculo;
        protected readonly RepositoryCliente _cliente;

        public ServiceLocacaoTest()
        {
            _repositoty = new Mock<RepositoryLocacao>().Object;
            _veiculo = new Mock<RepositoryVeiculo>().Object;
            _cliente = new Mock<RepositoryCliente>().Object;

            _sCliente = new Mock<ServiceCliente>(_cliente).Object;
            _sVeiculo = new Mock<ServiceVeiculo>(_veiculo).Object;


            _service = new Mock<ServiceLocacao>(_repositoty, _sVeiculo, _sCliente).Object;
        }

        [Theory]
        [InlineData("WWW123")]
        public void DoSimulateTest(string placa)
        {
            var simulator = new Base.Models.SimulatorLocacao
            {
                Limpo = true,
                Abastecido = true,
                Amassado = false,
                Arranhado = false,
                Retorno = DateTime.Now.AddHours(5),
                Saida = DateTime.Now
            };

            Xunit.Assert.NotNull(_service.DoSimulate(placa, simulator));
        }

    }
}
