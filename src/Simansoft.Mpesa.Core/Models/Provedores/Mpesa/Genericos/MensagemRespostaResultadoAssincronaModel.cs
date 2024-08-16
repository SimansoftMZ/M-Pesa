using Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Base;
using System.Text.Json.Serialization;

namespace Simansoft.Mpesa.Core.Models.Provedores.Mpesa.Genericos
{
    public class MensagemRespostaResultadoAssincronaModel : MensagemRespostaBaseModel
    {
        [JsonPropertyName("output_OriginalConversationID")]
        public string? OutputOriginalConversationID { get; set; }

        [JsonPropertyName("output_ThirdPartyConversationID")]
        public string? OutputThirdPartyConversationID { get; set; }
    }
}