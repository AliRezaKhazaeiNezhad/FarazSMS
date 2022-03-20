
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class MessageStateResponseModel
    {
        public MessageStateResponseModel()
        {

        }

        [JsonPropertyName("statusMessage")]
        public string Status { get; set; }
        [JsonPropertyName("validMessage")]
        public string Message { get; set; }
    }
}
