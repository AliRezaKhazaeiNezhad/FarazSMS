
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class CountryStateResponseModel
    {
        public CountryStateResponseModel()
        {

        }

        [JsonPropertyName("status")]
        public StatusResponseModel Status { get; set; }
        [JsonPropertyName("data")]
        public List<DataResponseModel> Data { get; set; }
    }
}
