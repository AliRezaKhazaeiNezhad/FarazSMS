
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class DataResponseModel
    {
        public DataResponseModel()
        {

        }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("country_state_id")]
        public string Id { get; set; }
    }
}
