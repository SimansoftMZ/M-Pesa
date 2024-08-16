﻿using Microsoft.AspNetCore.Mvc.Testing;
using Simansoft.Mpesa.Core.Models.Seguranca;
using System.Net.Http.Json;

namespace Simansoft.Mpesa.WebAPI.Tests.Controllers
{
    [TestClass]
    public class SegurancaControllerTests : WebApplicationFactory<Program>
    {
        private HttpClient _client = new();

        [TestInitialize]
        public void Initialize()
        {
            _client = this.CreateClient();
        }

        [TestMethod]
        public async Task IniciarSessao_SeAsCredenciaisEstiveremVaziasRetornaNaoAutorizado()
        {
            // Arrange
            ProvedorInicioSessaoModel inicioSessao = new();

            // Act
            HttpResponseMessage? response = await _client.PostAsJsonAsync("/seguranca/provedor/iniciar-sessao", inicioSessao).ConfigureAwait(true);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task IniciarSessao_SeAsCredenciaisNaoForemBase64RetornaNaoAutorizado()
        {
            // Arrange
            ProvedorInicioSessaoModel inicioSessao = new();
            inicioSessao.GerarStringAleatoria();
            inicioSessao.GerarPublicKey(out _);

            // Act
            HttpResponseMessage? response = await _client.PostAsJsonAsync("/seguranca/provedor/iniciar-sessao", inicioSessao).ConfigureAwait(true);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task IniciarSessao_DeveRetornarOTokenPreenchido()
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