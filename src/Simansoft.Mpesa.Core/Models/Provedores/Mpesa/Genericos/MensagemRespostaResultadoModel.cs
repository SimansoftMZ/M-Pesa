using Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Base;
using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Genericos
{
    public class MensagemRespostaResultadoModel : MensagemRespostaBaseModel
    {
        [JsonPropertyName("output_ConversationID")]
        public string? OutputConversationID { get; set; }

        [JsonPropertyName("output_ThirdPartyReference")]
        public string? OutputThirdPartyReference { get; set; }

        [JsonPropertyName("output_ResponseTransactionStatus")]
        public string? OutputResponseTransactionStatus { get; set; }
    }
}