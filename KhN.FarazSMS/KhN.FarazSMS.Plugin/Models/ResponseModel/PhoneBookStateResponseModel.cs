
using System.Collections.Generic;

namespace KhN.FarazSMS.Plugin
{
    public class PhoneBookStateResponseModel
    {
        public PhoneBookStateResponseModel()
        {

        }

        public StatusResponseModel status { get; set; }
        public PhoneBookModel data { get; set; }
    }
}
