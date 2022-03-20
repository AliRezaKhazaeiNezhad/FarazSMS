
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KhN.FarazSMS.Plugin
{
    public class PhoneBookResponseModel
    {
        public PhoneBookResponseModel()
        {

        }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("phoneBookId")]
        public int Id { get; set; }
    }

    public class PhoneBookModel
    {
        public PhoneBookModel()
        {

        }

        [JsonPropertyName("phoneBook")]
       public List<PhoneBookResponseModel> PhoneBook { get; set; }
    }
}
