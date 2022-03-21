
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class AddNumberInPhoneBookResponseModel
    {
        public AddNumberInPhoneBookResponseModel()
        {

        }

        [JsonPropertyName("status")]
        public StatusResponseModel Status { get; set; }
        [JsonPropertyName("data")]
        public PhoneNumberResponseModel Data { get; set; }
    }
}
