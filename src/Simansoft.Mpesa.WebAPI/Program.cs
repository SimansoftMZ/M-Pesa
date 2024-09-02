using Simansoft.Mpesa.Core.Models.Seguranca;
using System;
using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.WebAPI
{
    public class Program
    {
        const string VERSAO_ACTUAL_API = "1";

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppInicioSessaoContext.Default);                
            });

            var app = builder.Build();

            var segurancaApi = app.MapGroup($"api/v{VERSAO_ACTUAL_API}/seguranca/provedor");
            segurancaApi.MapPost("/iniciar-sessao", async (HttpRequest request) =>
            {
                var body = await request.ReadFromJsonAsync<ProvedorInicioSessaoModel>().ConfigureAwait(true);

                if (body == null)
                {
                    return Results.BadRequest("Modelo vazio!");
                }

                string token = body.IniciarSessao();

                return !string.IsNullOrWhiteSpace(token) ? Results.Ok(token) : Results.Unauthorized();
            });

            app.Run();
        }
    }

    [JsonSerializable(typeof(ProvedorInicioSessaoModel))]
    internal partial class AppInicioSessaoContext : JsonSerializerContext
    {

    }
}