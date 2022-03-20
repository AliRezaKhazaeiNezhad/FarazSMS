
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class StatusResponseModel
    {
        public StatusResponseModel()
        {

        }

        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("errorMessage")]
        public string Message { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
    }
}
