using Simansoft.Mpesa.Core.Models.Seguranca;

namespace Simansoft.Mpesa.Core.Tests.Models.Seguranca
{
    [TestClass]
    public class ProvedorInicioSessaoModelTests
    {
        [TestMethod]
        public void IniciarSessao_SeAsCredenciaisEstiveremVaziasDeveRetornarOTokenVazio()
        {
            // Arrange
            ProvedorInicioSessaoModel inicioSessao = new();

            // Act
            string token = inicioSessao.IniciarSessao();

            // Assert
            Assert.AreEqual(string.Empty, token);
        }

        [TestMethod]
        public void IniciarSessao_DeveRetornarOTokenPreenchido()
        {
            // Arrange
            ProvedorInicioSessaoModel inicioSessao = new();
            inicioSessao.GerarApiKey(22);
            inicioSessao.GerarPublicKey(out _);

            // Act
            string token = inicioSessao.IniciarSessao();

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(token));
            Assert.IsTrue(inicioSessao.EStringBase64(token));
        }
    }
}