using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Base
{
    public class MensagemRespostaBaseModel
    {
        [JsonPropertyName("output_ResponseCode")]
        public string? OutputResponseCode { get; set; }

        [JsonPropertyName("output_ResponseDesc")]
        public string? OutputResponseDesc { get; set; }


    }
}