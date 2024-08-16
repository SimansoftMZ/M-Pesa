using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Genericos
{
    public class C2BPagamentoAssicronoResultadoModel
    {
        [JsonPropertyName("input_OriginalConversationID")]
        public string InputOriginalConversationID { get; set; } = string.Empty;

        [JsonPropertyName("input_ThirdPartyReference")]
        public string InputThirdPartyReference { get; set; } = string.Empty;

        [JsonPropertyName("input_ResultCode")]
        public string InputResultCode { get; set; } = string.Empty;

        [JsonPropertyName("input_ResultDesc")]
        public string InputResultDesc { get; set; } = string.Empty;

        [JsonPropertyName("input_ResponseTransactionStatus")]
        public string InputResponseTransactionStatus { get; set; } = string.Empty;
    }
}