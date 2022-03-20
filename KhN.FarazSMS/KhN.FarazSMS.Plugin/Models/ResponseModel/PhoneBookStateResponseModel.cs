
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class PhoneBookStateResponseModel
    {
        public PhoneBookStateResponseModel()
        {

        }

        [JsonPropertyName("status")]
        public StatusResponseModel Status { get; set; }
        [JsonPropertyName("data")]
        public PhoneBookModel Data { get; set; }
    }
}
