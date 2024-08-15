using Simansoft.Mpesa.Core.Interfaces.Seguranca;
using Simansoft.Mpesa.Core.Models.Seguranca;
using System.Security.Cryptography;

namespace Simansoft.Mpesa.Core.Tests.Models.Seguranca
{
    [TestClass]
    public class ProvedorInicioSessaoModelTests
    {
        [TestMethod]
        public void IniciarSessao_ShouldEncryptApiKeyAndReturnToken()
        {
            // Arrange
            IProvedorInicioSessao inicioSessao = new ProvedorInicioSessaoModel();

            inicioSessao.GerarApiKey(22);
            inicioSessao.GerarPublicKey(out _);            
            // Act
            string token = inicioSessao.IniciarSessao();

            // Assert
            Assert.IsNotNull(token);
            //Assert.IsNotEmpty(token);
        }
    }
}