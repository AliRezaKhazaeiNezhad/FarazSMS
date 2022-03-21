
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class PhoneNumberResponseModel
    {
        public PhoneNumberResponseModel()
        {

        }

        [JsonPropertyName("response")]
        public string Response { get; set; }
    }
}
