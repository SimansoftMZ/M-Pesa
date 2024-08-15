using Simansoft.Mpesa.Core.Models.Seguranca;

namespace Simansoft.Mpesa.Core.Tests.Models.Seguranca
{
    [TestClass]
    public class ProvedorInicioSessaoModelTests
    {
        [TestMethod]
        public void IniciarSessao_DeveRetornarOToken()
        {
            ProvedorInicioSessaoModel inicioSessao = new();
            inicioSessao.GerarApiKey(22);
            inicioSessao.GerarPublicKey(out _);            
            
            string token = inicioSessao.IniciarSessao();

            // Assert
            Assert.IsNotNull(token);
            Assert.AreNotEqual(string.Empty, token);
        }
    }
}