using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Genericos
{
    public class C2BPagamentoModel
    {
        [JsonPropertyName("input_ThirdPartyReference")]
        public string InputThirdPartyReference { get; set; } = string.Empty;

        [JsonPropertyName("input_QueryReference")]
        public string InputQueryReference { get; set; } = string.Empty;

        [JsonPropertyName("input_ServiceProviderCode")]
        public string InputServiceProviderCode { get; set; } = string.Empty;
    }
}