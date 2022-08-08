using Localiza.Repository.Interface;
using Localiza.Service.IService;
using Localiza.Service.Service;

namespace Services.Test
{
    [TestClass]
    public class UnitLocacaoTest
    {
   
        [TestMethod]
        public void ValidarCombustivel()
        {
            IServiceVeiculo _r;

            string combustivel = "G123asolina";
            var model = _r.ValidCombustivel(combustivel);

            Assert.IsTrue(false);
        }
    }
}