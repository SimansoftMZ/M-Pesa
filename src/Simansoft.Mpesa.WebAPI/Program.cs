using Simansoft.Mpesa.Core.Models.Seguranca;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppInicioSessaoContext.Default);
});

var app = builder.Build();

var segurancaApi = app.MapGroup("/seguranca/provedor");
segurancaApi.MapPost("/iniciar-sessao", async (HttpRequest request) =>
{
    var body = await request.ReadFromJsonAsync<ProvedorInicioSessaoModel>();

    string token = body!.IniciarSessao();

    return !string.IsNullOrWhiteSpace(token) ? Results.Ok(token) : Results.Unauthorized();
});

app.Run();

[JsonSerializable(typeof(ProvedorInicioSessaoModel))]
internal partial class AppInicioSessaoContext : JsonSerializerContext
{

}