using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Simansoft.Mpesa.Core.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Simansoft.Mpesa.WebAPI.Tests.Controllers
{
    [TestClass]
    public class SegurancaControllerTests : WebApplicationFactory<Program>
    {
        private HttpClient _client = new();

        [TestInitialize]
        public void Initialize()
        {
            // Cria um cliente HTTP para enviar requisições ao servidor simulado
            _client = this.CreateClient();
        }

        [TestMethod]
        public async Task IniciarSessao_ReturnaToken_QuandoRequestValido()
        {
            // Arrange
            ProvedorInicioSessaoModel inicioSessao = new();
            inicioSessao.GerarApiKey(22);
            inicioSessao.GerarPublicKey(out _);

            // Act
            HttpResponseMessage? response = await _client.PostAsJsonAsync("/seguranca/provedor/iniciar-sessao", inicioSessao).ConfigureAwait(true);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // Act
            string token = (await response.Content.ReadAsStringAsync().ConfigureAwait(true)).Trim('\"');

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(token));
            Assert.IsTrue(inicioSessao.EStringBase64(token));
        }
    }
}