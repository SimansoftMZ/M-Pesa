using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class SegurancaControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        //public SegurancaControllerTests()
        //{
        //    _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        //    _client = _server.CreateClient();
        //}

        //[TestMethod]
        //public async Task IniciarSessao_Endpoint_ReturnsOkResult()
        //{
        //    // Arrange
        //    var model = new ProvedorInicioSessaoModel
        //    {
        //        // Set the properties of the model as needed for the test
        //    };
        //    var json = JsonConvert.SerializeObject(model);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    // Act
        //    var response = await _client.PostAsJsonAsync("/seguranca/provedor/iniciar-sessao", model);

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    var token = JsonConvert.DeserializeObject<string>(responseContent);
        //    Assert.NotNull(token);
        //}

        //[TestMethod]
        //public async Task IniciarSessao()
        //{
        //    // Arrange
        //    var request = new DefaultHttpContext().Request;
        //    var body = new ProvedorInicioSessaoModel();
        //    var expectedToken = "token";

        //    // Act
        //    var result = await Simansoft.Mpesa.WebAPI. Program.IniciarSessao(request, body);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var okResult = (OkObjectResult)result;
        //    Assert.Equal(expectedToken, okResult.Value);
        //}
    }
}
