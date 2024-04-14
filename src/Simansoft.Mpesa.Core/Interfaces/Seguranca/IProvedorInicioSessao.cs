using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Interfaces.Seguranca
{
    public interface IProvedorInicioSessao
    {
        public string ApiKey { get; set; }
        public string PublicKey { get; set; }

        public string IniciarSessao();
    }
}
