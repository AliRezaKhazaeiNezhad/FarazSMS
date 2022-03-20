
using System.Collections.Generic;

namespace KhN.FarazSMS.Plugin
{
    public class PhoneBookResponseModel
    {
        public PhoneBookResponseModel()
        {

        }

        public string title { get; set; }
        public int phoneBookId { get; set; }
    }

    public class PhoneBookModel
    {
        public PhoneBookModel()
        {

        }

       public List<PhoneBookResponseModel> phoneBook { get; set; }
    }
}
