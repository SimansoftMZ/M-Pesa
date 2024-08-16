using Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Base;
using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Genericos
{
    public class MensagemRespostaAssincronaModel : MensagemRespostaBaseModel
    {
        [JsonPropertyName("output_ThirdPartyReference")]
        public string? OutputThirdPartyReference { get; set; }

        [JsonPropertyName("output_ConversationID")]
        public string? OutputConversationID { get; set; }
    }
}